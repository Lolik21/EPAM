// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleDependencyInjector.cs" company="My company">
//   free to copy
// </copyright>
// <summary>
//   The simple di.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epam_9
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Instrumentation;
    using System.Reflection;

    using Epam_9.Exceptions;

    /// <summary>
    /// The simple di.
    /// </summary>
    public class SimpleDependencyInjector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleDependencyInjector"/> class.
        /// </summary>
        public SimpleDependencyInjector()
        {
            this.TypeContainers = new List<Container>();
        }

        /// <summary>
        /// Gets list of the classType containers.
        /// </summary>
        public List<Container> TypeContainers { get; }

        /// <summary>
        /// Register's class classType.
        /// </summary>
        /// <param name="type">
        /// The class classType.
        /// </param>
        /// <param name="interfaceType">
        /// The interface classType.
        /// </param>
        /// <param name="key">
        /// The key to access.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throw's when dependency is already registered
        /// </exception>
        public void Register(Type type, Type interfaceType = null, string key = null)
        {
            this.ValidateTypes(type, interfaceType);

            Container container = this.TypeContainers.FirstOrDefault(c => c.Class == type && 
                c.Key == key && c.Interface == interfaceType);

            if (container != null)
            {
                throw new ContainerAlreadyExistsException(nameof(container));
            }

            this.RegisterNew(type, interfaceType, key);
        }

        /// <summary>
        /// Resolve's classType.
        /// </summary>
        /// <param name="type">
        /// The class classType.
        /// </param>
        /// <returns>
        /// The <see cref="object"/> that dependency represents.
        /// </returns>
        public object Resolve(Type type)
        {
            if (type.IsInterface)
            {
                return this.ResolveFromInterface(type);
            }

            return this.ResolveFromClass(type);
        }

        /// <summary>
        /// Resolve's classType using key.
        /// </summary>
        /// <param name="type">
        /// The class classType.
        /// </param>
        /// <param name="key">
        /// The key to access.
        /// </param>
        /// <returns>
        /// The <see cref="object"/> that dependency represents.
        /// </returns>
        public object Resolve(Type type, string key)
        {
            Container container = this.TypeContainers.FirstOrDefault(c => c.Class == type && c.Key == key);
            if (container == null)
            {
                return null;
            }

            return Activator.CreateInstance(type);
        }

        /// <summary>
        /// Resolve's dependency using interface.
        /// </summary>
        /// <param name="type">
        /// The class classType.
        /// </param>
        /// <param name="interfaceType">
        /// The interface classType.
        /// </param>
        /// <returns>
        /// The <see cref="object"/> that dependency represents.
        /// </returns>
        public object Resolve(Type type, Type interfaceType)
        {
            foreach (var typeConteiner in this.TypeContainers)
            {
                if (typeConteiner.Interface == interfaceType && typeConteiner.Class == type)
                {
                    return Activator.CreateInstance(type);
                }
            }

            return null;
        }

        /// <summary>
        /// Call's constructor with max parameters.
        /// ONLY FOR INTERFACE PROPERTIES
        /// </summary>
        /// <param name="objToCreateType">
        /// The object to create type.
        /// </param>
        /// <returns>
        /// The <see cref="object"/> with injected dependencies.
        /// </returns>
        public object CallCtor(Type objToCreateType)
        {
            List<Type> maxCtorTypes = this.GetMaxParamConstructor(objToCreateType);

            if (maxCtorTypes.Count <= 0)
            {
                return Activator.CreateInstance(objToCreateType);
            }

            object[] objs = this.GetParams(maxCtorTypes);

            return Activator.CreateInstance(objToCreateType, objs);
        }

        /// <summary>
        /// Creates object and injects dependency to property.
        /// </summary>
        /// <param name="objToCreateType">
        /// The object to create type.
        /// </param>
        /// <returns>
        /// The <see cref="object"/> with injected property.
        /// </returns>
        public object CreateAndPropInjection(Type objToCreateType)
        {
            object obj = this.CallCtor(objToCreateType);

            this.SimplePropInjection(obj, objToCreateType);

            return obj;
        }

        /// <summary>
        /// Injects property to object instance.
        /// ONLY FOR INTERFACE PROPERTIES
        /// </summary>
        /// <param name="obj">
        /// The object instance to inject property.
        /// </param>
        /// <param name="objToCreateType">
        /// The object to create type information.
        /// </param>
        public void SimplePropInjection(object obj, Type objToCreateType)
        {
            var properties = objToCreateType.GetProperties();

            foreach (var propertyInfo in properties)
            {
                var cont = this.TypeContainers.FirstOrDefault(c => c.Interface == propertyInfo.PropertyType);
                if (cont != null)
                {
                    propertyInfo.SetValue(obj, this.Resolve(cont.Class, cont.Interface));
                }
            }
        }

        /// <summary>
        /// Resolve's from class classType.
        /// </summary>
        /// <param name="classType">
        /// The class classType.
        /// </param>
        /// <returns>
        /// The <see cref="object"/> that dependency represents.
        /// </returns>
        private object ResolveFromClass(Type classType)
        {
            foreach (var conteiner in this.TypeContainers)
            {
                if (conteiner.Class == classType)
                {
                    return Activator.CreateInstance(classType);
                }
            }

            return null;
        }

        /// <summary>
        /// Resolve's from interface classType.
        /// </summary>
        /// <param name="typeInterface">
        /// The interface classType.
        /// </param>
        /// <returns>
        /// The <see cref="object"/> that dependency represents.
        /// </returns>
        private object ResolveFromInterface(Type typeInterface)
        {
            foreach (var conteiner in this.TypeContainers)
            {
                if (conteiner.Interface == typeInterface)
                {
                    return Activator.CreateInstance(conteiner.Interface);
                }
            }

            return null;
        }

        /// <summary>
        /// Get's max parameter constructor.
        /// </summary>
        /// <param name="objToCreateType">
        /// The object to create classType.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>List</cref>
        ///     </see>
        ///     that contains constructor
        /// parameters types.
        /// </returns>
        private List<Type> GetMaxParamConstructor(Type objToCreateType)
        {
            ConstructorInfo[] infos = objToCreateType.GetConstructors();
            List<Type> paramTypes = new List<Type>();

            foreach (var constructorInfo in infos)
            {
                var parameters = constructorInfo.GetParameters();

                if (parameters.Length > paramTypes.Count)
                {
                    paramTypes.Clear();
                    foreach (var parameterInfo in parameters)
                    {
                        paramTypes.Add(parameterInfo.ParameterType);
                    }
                }
            }

            return paramTypes;
        }

        /// <summary>
        /// Get's constructor parameters.
        /// </summary>
        /// <param name="maxCtorTypes">
        /// The max constructor parameters types.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>object[]</cref>
        ///     </see>
        ///     that contains parameters for constructor.
        /// </returns>
        /// <exception cref="InstanceNotFoundException">
        /// Throw's when method cannot find dependencies that suits for
        /// constructor creation
        /// </exception>
        private object[] GetParams(List<Type> maxCtorTypes)
        {
            List<object> objects = new List<object>();

            foreach (var type in maxCtorTypes)
            {
                var cont = this.TypeContainers.FirstOrDefault(c => c.Interface == type);
                if (cont == null)
                {
                    throw new InvalidConstructorException("Cannot create instance with constructor with max parameters");
                }

                objects.Add(this.Resolve(cont.Class, cont.Interface));
            }

            return objects.ToArray();
        }

        /// <summary>
        /// Check's class to realize interfaces.
        /// </summary>
        /// <param name="typeClass">
        /// The type Class.
        /// </param>
        /// <param name="typeInterface">
        /// The type Interface.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throw's when class do not implements interface
        /// </exception>
        private void CheckClassInterfaces(Type typeClass, Type typeInterface)
        {
            Type[] types = typeClass.GetInterfaces();
            bool isPresent = false;
            foreach (var type in types)
            {
                if (type == typeInterface)
                {
                    isPresent = true;
                }
            }

            if (isPresent == false)
            {
                throw new ClassDoNotImplementInterfaceException(nameof(typeInterface));
            }
        }

        /// <summary>
        /// Validates types.
        /// </summary>
        /// <param name="type">
        /// The classType of class.
        /// </param>
        /// <param name="interfaceType">
        /// The classType of interface.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throw's when i classType is not interface
        /// or class classType is interface
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Throw's when class classType is null
        /// </exception>
        private void ValidateTypes(Type type, Type interfaceType)
        {
            if (interfaceType != null)
            {
                if (!interfaceType.IsInterface)
                {
                    throw new InvalidTypeException(nameof(interfaceType));
                }

                this.CheckClassInterfaces(type, interfaceType);
            }

            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (type.IsInterface)
            {
                throw new InvalidTypeException(nameof(type));
            }
        }

        /// <summary>
        /// Register's new dependency.
        /// </summary>
        /// <param name="classType">
        /// The class classType.
        /// </param>
        /// <param name="interfaceType">
        /// The interface classType.
        /// </param>
        /// <param name="key">
        /// The key too access.
        /// </param>
        private void RegisterNew(Type classType, Type interfaceType, string key)
        {
            var container = new Container()
            {
                Class = classType,
                Key = key,
                Interface = interfaceType
            };
            this.TypeContainers.Add(container);
        }
    }
}