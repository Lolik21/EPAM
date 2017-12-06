using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProjectExpression
{
    using System.Linq;
    using System.Linq.Expressions;
    using MyExpression;

    [TestClass]
    public class TestsForExpression
    {
        [TestMethod]
        public void TestForExpression()
        {
            Type userType = typeof(User);

            var ctorInformation = userType.GetConstructors().FirstOrDefault();
            var propNameInfo = userType.GetProperty("Name");
            var propSurNameInfo = userType.GetProperty("SurName");

            Assert.IsNotNull(propSurNameInfo);
            Assert.IsNotNull(propNameInfo);
            Assert.IsNotNull(ctorInformation);

            var nameArg = Expression.Parameter(typeof(string), "Name");
            var surNameArg = Expression.Parameter(typeof(string), "SurName");
            var result = Expression.Variable(typeof(User), "result");
            var initResult = Expression.Assign(result, Expression.New(ctorInformation));
            var prop1 = Expression.Property(result, propNameInfo);
            var prop2 = Expression.Property(result, propSurNameInfo);

            BlockExpression bodyExpression = Expression.Block(
                new[] { result },
                initResult,
                Expression.Assign(prop1, nameArg),
                Expression.Assign(prop2, surNameArg),
                result);


            var lambda = Expression.Lambda(bodyExpression, nameArg, surNameArg);

            var func = (Func<string, string, User>)lambda.Compile();

            string str1 = "Ilya";
            string str2 = "Kremniou";

            User user = func(str1, str2);

            Assert.AreEqual("Ilya", user.Name);
            Assert.AreEqual("Kremniou", user.SurName);
        }
    }
}
