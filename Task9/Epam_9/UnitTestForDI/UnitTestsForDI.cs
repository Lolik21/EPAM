using System;
using System.Management.Instrumentation;
using System.Security.Policy;
using Epam_9;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestForDI
{
    using Epam_9.Exceptions;

    [TestClass]
    public class UnitTestsForDI
    {

        class MyClass2 : IClass2
        {
            public MyClass2()
            {
                IsEnabled = true;
            }

            public bool IsEnabled { get; }
        }

        class MyClass3 : IClass3
        {
            public MyClass3()
            {
                IsEnabled = true;
            }

            public bool IsEnabled { get; }
        }

        class MyClass : IClass
        {
            public MyClass()
            {
                IsEnabled = true;
            }

            public bool IsEnabled { get; }
        }

        interface IClass
        {
            bool IsEnabled { get; }
        }

        interface IClass2
        {
            bool IsEnabled { get; }
        }

        interface IClass3
        {
            bool IsEnabled { get; }
        }

        class TestClass
        {
            public TestClass(IClass iclass, IClass2 iclass2)
            {
                IsGood = iclass.IsEnabled & iclass2.IsEnabled;
            }

            public bool IsGood { get; }
        }

        class TestClass2
        {
            public IClass Property1 { get; set; }
            public IClass2 Property2 { get; set; }
        }


        [TestMethod]
        public void RegisterAndResolveToItself()
        {
            SimpleDependencyInjector di = new SimpleDependencyInjector();

            di.Register(typeof(MyClass));

            MyClass myClass = di.Resolve(typeof(MyClass)) as MyClass;

            Assert.AreEqual(true, myClass.IsEnabled);
        }

        [TestMethod]
        [ExpectedException(typeof(ContainerAlreadyExistsException))]
        public void RegisterTwoTimesToItself()
        {
            SimpleDependencyInjector di = new SimpleDependencyInjector();

            di.Register(typeof(MyClass));
            di.Register(typeof(MyClass));
        }

        [TestMethod]
        public void RegisterAndResolveToInterface()
        {
            SimpleDependencyInjector di = new SimpleDependencyInjector();

            di.Register(typeof(MyClass),typeof(IClass));

            IClass iClass = di.Resolve(typeof(MyClass),typeof(IClass)) as MyClass;

            Assert.AreEqual(true, iClass.IsEnabled);
        }

        [TestMethod]
        [ExpectedException(typeof(ContainerAlreadyExistsException))]
        public void RegisterTwoTimesToInterface()
        {
            SimpleDependencyInjector di = new SimpleDependencyInjector();

            di.Register(typeof(MyClass), typeof(IClass));
            di.Register(typeof(MyClass), typeof(IClass));
        }

        [TestMethod]
        public void RegisterAndResolveTwoClassesToInterface()
        {
            SimpleDependencyInjector di = new SimpleDependencyInjector();

            di.Register(typeof(MyClass), typeof(IClass));
            di.Register(typeof(MyClass2), typeof(IClass2));

            IClass iClass = di.Resolve(typeof(MyClass), typeof(IClass)) as MyClass;
            IClass2 iClass2 = di.Resolve(typeof(MyClass2), typeof(IClass2)) as MyClass2;

            Assert.AreEqual(true, iClass.IsEnabled);
            Assert.AreEqual(true, iClass2.IsEnabled);
        }

        [TestMethod]
        public void RegisterAndResolveWithKey()
        {
            SimpleDependencyInjector di = new SimpleDependencyInjector();

            di.Register(typeof(MyClass), typeof(IClass),"key");

            IClass iClass = di.Resolve(typeof(MyClass),"key") as MyClass;

            Assert.AreEqual(true, iClass.IsEnabled);
        }

        [TestMethod]
        public void RegisterAndResolveWithNotExistedKey()
        {
            SimpleDependencyInjector di = new SimpleDependencyInjector();

            di.Register(typeof(MyClass), typeof(IClass), "key");

            IClass iClass = di.Resolve(typeof(MyClass), "key1") as MyClass;

            Assert.AreEqual(null, iClass);
        }

        [TestMethod]
        public void RegisterAndResolveWithNotExistedType()
        {
            SimpleDependencyInjector di = new SimpleDependencyInjector();

            di.Register(typeof(MyClass), typeof(IClass));

            IClass iClass = di.Resolve(typeof(MyClass2), typeof(IClass)) as MyClass;

            Assert.AreEqual(null, iClass);
        }

        [TestMethod]
        public void RegisterAndResolveWithNotExistedInterface()
        {
            SimpleDependencyInjector di = new SimpleDependencyInjector();

            di.Register(typeof(MyClass), typeof(IClass));

            IClass iClass = di.Resolve(typeof(MyClass), typeof(IClass2)) as MyClass;

            Assert.AreEqual(null, iClass);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidConstructorException))]
        public void InjectionFaiedInstanseNotFounded()
        {
            SimpleDependencyInjector di = new SimpleDependencyInjector();

            di.Register(typeof(MyClass), typeof(IClass));

            TestClass testClass = di.CallCtor(typeof(TestClass)) as TestClass;

            Assert.AreEqual(true,testClass.IsGood);
        }

        [TestMethod]
        public void InjectionGood()
        {
            SimpleDependencyInjector di = new SimpleDependencyInjector();

            di.Register(typeof(MyClass), typeof(IClass));
            di.Register(typeof(MyClass2), typeof(IClass2));

            TestClass testClass = di.CallCtor(typeof(TestClass)) as TestClass;

            Assert.AreEqual(true, testClass.IsGood);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidConstructorException))]
        public void InjectionFailDependencyNotFound()
        {
            SimpleDependencyInjector di = new SimpleDependencyInjector();

            di.Register(typeof(MyClass), typeof(IClass));
            di.Register(typeof(MyClass3), typeof(IClass3));

            TestClass testClass = di.CallCtor(typeof(TestClass)) as TestClass;
        }


        [TestMethod]
        [ExpectedException(typeof(ClassDoNotImplementInterfaceException))]
        public void RegisterWithClassNotImplementsInterface()
        {
            SimpleDependencyInjector di = new SimpleDependencyInjector();

            di.Register(typeof(MyClass), typeof(IClass));
            di.Register(typeof(MyClass2), typeof(IClass3));
        }

        [TestMethod]
        public void PropertyInjectionGood()
        {
            SimpleDependencyInjector di = new SimpleDependencyInjector();

            di.Register(typeof(MyClass), typeof(IClass));
            di.Register(typeof(MyClass2), typeof(IClass2));

            TestClass2 testClass = di.CreateAndPropInjection(typeof(TestClass2)) as TestClass2;

            Assert.AreEqual(true,testClass.Property1.IsEnabled);
            Assert.AreEqual(true, testClass.Property2.IsEnabled);
        }

        [TestMethod]
        public void PropertyInjectionNotFoundDependency()
        {
            SimpleDependencyInjector di = new SimpleDependencyInjector();

            TestClass2 testClass = di.CreateAndPropInjection(typeof(TestClass2)) as TestClass2;

            Assert.AreEqual(null, testClass.Property1);
            Assert.AreEqual(null, testClass.Property2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidTypeException))]
        public void InvalidInterfaceTypeTest()
        {
            SimpleDependencyInjector di = new SimpleDependencyInjector();     

            di.Register(typeof(MyClass), typeof(MyClass));
        }

    }
}
