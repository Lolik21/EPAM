using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestForSellService
{
    using Common;

    using Repository;

    using WebStore;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IRepository repository = new ListRepository();

            SellService sellService = new SellService(repository);

            Product product = new Product
                                  {
                                      ID = -1;
                                  }
            
        }
    }
}
