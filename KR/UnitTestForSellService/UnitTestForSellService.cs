using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestForSellService
{
    using Common;
    using Repository;
    using WebStore;
    using WebStore.Exceptions;

    [TestClass]
    public class UnitTestForSellService
    {
        private IRepository _repository;

        [TestInitialize]
        public void Init()
        {
            this._repository = new ListRepository();
        }

        [TestMethod]
        public void AddNormalProduct()
        {
            ConcreteProduct product = new ConcreteProduct()
            {
                Name = "My Super Product",
                Description = "Description of my super product",
                Weight = 100,
                Price = 100,
                Count = 50,
                Height = 100,
                Width = 100
            };

            SellService sellService = new SellService(this._repository);

            sellService.AddProduct(product);

            Assert.AreEqual(product, this._repository.Get(0));
        }

        [TestMethod]
        public void AddNormalProductEventsAddCheck()
        {
            ConcreteProduct product = new ConcreteProduct()
            {
                Name = "My Super Product",
                Description = "Description of my super product",
                Weight = 100,
                Price = 100,
                Count = 50,
                Height = 100,
                Width = 100,
            };

            SellService sellService = new SellService(this._repository);

            bool isAddCalled = false;
            bool isAddedCalled = false;

            sellService.OnAddProduct += (sender, args) => { isAddCalled = true; };
            sellService.OnAddedProduct += (sender, args) => { isAddedCalled = true; };

            sellService.AddProduct(product);

            Assert.IsTrue(isAddCalled);
            Assert.IsTrue(isAddedCalled);

            Assert.AreEqual(product, this._repository.Get(0));
        }

        [TestMethod]
        public void AddNormalProductCountAddCheck()
        {
            ConcreteProduct product = new ConcreteProduct()
            {
                Name = "My Super Product",
                Description = "Description of my super product",
                Weight = 100,
                Price = 100,
                Count = 50,
                Height = 100,
                Width = 100
            };

            SellService sellService = new SellService(this._repository);

            sellService.AddProduct(product);
            sellService.AddProduct(product);

            Assert.AreEqual(product, this._repository.Get(0));
            Assert.AreEqual((uint)100, this._repository.Get(0).Count);
        }

        [TestMethod]
        public void AddTwoNormalProducts()
        {
            ConcreteProduct product = new ConcreteProduct()
            {
                Name = "My Super Product",
                Description = "Description of my super product",
                Weight = 100,
                Price = 100,
                Count = 50,
                Height = 100,
                Width = 100
            };

            ConcreteProduct product2 = new ConcreteProduct()
            {
                Name = "My Super Product 2",
                Description = "Description of my super product",
                Weight = 100,
                Price = 100,
                Count = 50,
                Height = 100,
                Width = 100
            };

            SellService sellService = new SellService(this._repository);

            sellService.AddProduct(product);
            sellService.AddProduct(product2);

            Assert.AreEqual(product, this._repository.Get(0));
            Assert.AreEqual(product2, this._repository.Get(1));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStringException))]
        public void InvalidProductBadNameSymbols()
        {
            ConcreteProduct product = new ConcreteProduct()
            {
                Name = "My Super Product$$$",
                Description = "Description of my super product",
                Weight = 100,
                Price = 100,
                Count = 50,
                Height = 100,
                Width = 100
            };
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStringException))]
        public void InvalidProductBadNameLength()
        {
            ConcreteProduct product = new ConcreteProduct()
            {
                Name = "My",
                Description = "Description of my super product",
                Weight = 100,
                Price = 100,
                Count = 50,
                Height = 100,
                Width = 100
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InvalidProductBadNameNull()
        {
            ConcreteProduct product = new ConcreteProduct()
            {
                Name = null,
                Description = "Description of my super product",
                Weight = 100,
                Price = 100,
                Count = 50,
                Height = 100,
                Width = 100
            };
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyStringException))]
        public void InvalidProductBadNameEmpty()
        {
            ConcreteProduct product = new ConcreteProduct()
            {
                Name = string.Empty,
                Description = "Description of my super product",
                Weight = 100,
                Price = 100,
                Count = 50,
                Height = 100,
                Width = 100
            };
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStringException))]
        public void InvalidProductDescSymbols()
        {
            ConcreteProduct product = new ConcreteProduct()
            {
                Name = "My Super Product",
                Description = "Description of my super product@@",
                Weight = 100,
                Price = 100,
                Count = 50,
                Height = 100,
                Width = 100
            };
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStringException))]
        public void InvalidProductDescLength()
        {
            ConcreteProduct product = new ConcreteProduct()
            {
                Name = "My Super Product",
                Description = "Des",
                Weight = 100,
                Price = 100,
                Count = 50,
                Height = 100,
                Width = 100
            };
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidWeightException))]
        public void InvalidProductWeight0()
        {
            ConcreteProduct product = new ConcreteProduct()
            {
                Name = "My Super Product",
                Description = "Description of my super product",
                Weight = 0,
                Price = 100,
                Count = 50,
                Height = 100,
                Width = 100
            };
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidWeightException))]
        public void InvalidProductWeightLessThan0()
        {
            ConcreteProduct product = new ConcreteProduct()
            {
                Name = "My Super Product",
                Description = "Description of my super product",
                Weight = -1000,
                Price = 100,
                Count = 50,
                Height = 100,
                Width = 100
            };
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidSizeException))]
        public void InvalidProductHeight()
        {
            ConcreteProduct product = new ConcreteProduct()
            {
                Name = "My Super Product",
                Description = "Description of my super product",
                Weight = 100,
                Price = 100,
                Count = 50,
                Height = -100,
                Width = 100
            };
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidSizeException))]
        public void InvalidProductWidth()
        {
            ConcreteProduct product = new ConcreteProduct()
            {
                Name = "My Super Product",
                Description = "Description of my super product",
                Weight = 100,
                Price = 100,
                Count = 50,
                Height = 100,
                Width = -100
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddInvalidProductNull()
        {
            ConcreteProduct product = null;

            SellService sellService = new SellService(this._repository);

            sellService.AddProduct(product);
        }

        [TestMethod]
        public void SellNormalProduct()
        {
            ConcreteProduct product = new ConcreteProduct()
            {
                Name = "My Super Product",
                Description = "Description of my super product",
                Weight = 100,
                Price = 100,
                Count = 50,
                Height = 100,
                Width = 100
            };

            SellService sellService = new SellService(this._repository);

            sellService.AddProduct(product);
            sellService.SellProduct(product);
            
            Assert.AreEqual((uint)49, this._repository.Get(0).Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SellNullProduct()
        {
            ConcreteProduct product = new ConcreteProduct()
            {
                Name = "My Super Product",
                Description = "Description of my super product",
                Weight = 100,
                Price = 100,
                Count = 50,
                Height = 100,
                Width = 100
            };

            ConcreteProduct product2 = null;

            SellService sellService = new SellService(this._repository);

            sellService.AddProduct(product);
            sellService.SellProduct(product2);
        }

        [TestMethod]
        public void SellNormalProductEventCheck()
        {
            ConcreteProduct product = new ConcreteProduct()
            {
                Name = "My Super Product",
                Description = "Description of my super product",
                Weight = 100,
                Price = 100,
                Count = 50,
                Height = 100,
                Width = 100
            };

            SellService sellService = new SellService(this._repository);

            bool isSellChecked = false;
            bool isSoldChecked = false;

            sellService.OnSellProduct += (sender, args) => { isSellChecked = true; };
            sellService.OnSoldProduct += (sender, args) => { isSoldChecked = true; };

            sellService.AddProduct(product);
            sellService.SellProduct(product);

            Assert.IsTrue(isSellChecked);
            Assert.IsTrue(isSoldChecked);
            Assert.AreEqual((uint)49, this._repository.Get(0).Count);
        }

        [TestMethod]
        public void DeleteNormalProduct()
        {
            ConcreteProduct product = new ConcreteProduct()
            {
                Name = "My Super Product",
                Description = "Description of my super product",
                Weight = 100,
                Price = 100,
                Count = 50,
                Height = 100,
                Width = 100
            };

            SellService sellService = new SellService(this._repository);

            sellService.AddProduct(product);
            sellService.DeleteProduct(0);

            Assert.IsNull(this._repository.Get(0));
        }

        [TestMethod]
        [ExpectedException(typeof(DeleteNotCompletedException))]
        public void DeleteUnExcitedProduct()
        {
            ConcreteProduct product = new ConcreteProduct()
            {
                Name = "My Super Product",
                Description = "Description of my super product",
                Weight = 100,
                Price = 100,
                Count = 50,
                Height = 100,
                Width = 100
            };

            SellService sellService = new SellService(this._repository);

            sellService.AddProduct(product);
            sellService.DeleteProduct(510);
        }

        [TestMethod]
        public void UpdateNormalProduct()
        {
            ConcreteProduct product = new ConcreteProduct()
            {
                Name = "My Super Product",
                Description = "Description of my super product",
                Weight = 100,
                Price = 100,
                Count = 50,
                Height = 100,
                Width = 100
            };

            ConcreteProduct product2 = new ConcreteProduct()
            {
                Name = "My Super Product 2",
                Description = "Description of my super product",
                Weight = 100,
                Price = 100,
                Count = 50,
                Height = 100,
                Width = 100,
                Id = 0
            };

            SellService sellService = new SellService(this._repository);

            sellService.AddProduct(product);
            sellService.UpdateProduct(product2);

            Assert.AreEqual(product2, this._repository.Get(0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateNullProduct()
        {
            ConcreteProduct product = new ConcreteProduct()
            {
                Name = "My Super Product",
                Description = "Description of my super product",
                Weight = 100,
                Price = 100,
                Count = 50,
                Height = 100,
                Width = 100
            };

            ConcreteProduct product2 = null;

            SellService sellService = new SellService(this._repository);

            sellService.AddProduct(product);
            sellService.UpdateProduct(product2);
        }

        [TestMethod]
        public void UpdateNormalProductEventsCheck()
        {
            ConcreteProduct product = new ConcreteProduct()
            {
                Name = "My Super Product",
                Description = "Description of my super product",
                Weight = 100,
                Price = 100,
                Count = 50,
                Height = 100,
                Width = 100
            };

            ConcreteProduct product2 = new ConcreteProduct()
            {
                Name = "My Super Product 2",
                Description = "Description of my super product",
                Weight = 100,
                Price = 100,
                Count = 50,
                Height = 100,
                Width = 100,
                Id = 0
            };

            SellService sellService = new SellService(this._repository);

            bool isUpdateChecked = false;
            bool isUpdatedChecked = false;

            sellService.OnUpdateProduct += (sender, args) => { isUpdateChecked = true; };
            sellService.OnUpdatedProduct += (sender, args) => { isUpdatedChecked = true; };

            sellService.AddProduct(product);
            sellService.UpdateProduct(product2);

            Assert.IsTrue(isUpdatedChecked);
            Assert.IsTrue(isUpdateChecked);
            Assert.AreEqual(product2, this._repository.Get(0));
        }

    }
}
