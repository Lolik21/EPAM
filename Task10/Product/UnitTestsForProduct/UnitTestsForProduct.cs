using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestsForProduct
{
    using System.Reflection;
    using Product;

    [TestClass]
    public class UnitTestsForProduct
    {
        [TestMethod]
        public void ReflectionCreateSignAndRaise()
        {
            Product mySuperProduct = ReflectionHelper.ActivateProduct();
            var isChange = false;
            var isChanged = false;
            ReflectionHelper.AssignToEvent(
                mySuperProduct,
                (sender, args) => { isChanged = true; },
                (sender, args) => { isChange = true; });

            ReflectionHelper.RaiseEvent(mySuperProduct, 100);

            Assert.AreEqual(mySuperProduct.Price, 100);
            Assert.IsTrue(isChange);
            Assert.IsTrue(isChanged);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssignToEventNull()
        {
            Product mySuperProduct = ReflectionHelper.ActivateProduct();
            var isChange = false;
            var isChanged = false;
            ReflectionHelper.AssignToEvent(
                null,
                (sender, args) => { isChanged = true; },
                (sender, args) => { isChange = true; });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RaiseEventNull()
        {
            Product mySuperProduct = ReflectionHelper.ActivateProduct();
            var isChange = false;
            var isChanged = false;
            ReflectionHelper.AssignToEvent(
                mySuperProduct,
                (sender, args) => { isChanged = true; },
                (sender, args) => { isChange = true; });

            ReflectionHelper.RaiseEvent(null, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(TargetInvocationException))]
        public void InvalidPriceSet()
        {
            Product mySuperProduct = ReflectionHelper.ActivateProduct();
            var isChange = false;
            var isChanged = false;
            ReflectionHelper.AssignToEvent(
                mySuperProduct,
                (sender, args) => { isChanged = true; },
                (sender, args) => { isChange = true; });

            ReflectionHelper.RaiseEvent(mySuperProduct, -100);
        }
    }
}
