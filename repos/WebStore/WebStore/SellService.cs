namespace WebStore
{
    using System;

    using Common;

    using Repository;

    /// <summary>
    /// The sell service.
    /// </summary>
    public class SellService
    {
        /// <summary>
        /// The repository that's store products.
        /// </summary>
        private readonly IRepository _repository;

        public SellService(IRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// The on sell product event.
        /// </summary>
        public event EventHandler<ProductEventArgs> OnSellProduct;

        /// <summary>
        /// The on sold product event.
        /// </summary>
        public event EventHandler<ProductEventArgs> OnSoldProduct;

        /// <summary>
        /// The on add product event.
        /// </summary>
        public event EventHandler<ProductEventArgs> OnAddProduct;

        /// <summary>
        /// The on added product event.
        /// </summary>
        public event EventHandler<ProductEventArgs> OnAddedProduct;

        /// <summary>
        /// Adds product to repository.
        /// </summary>
        /// <param name="product">
        /// The product to add.
        /// </param>
        public void AddProduct(Product product)
        {
            this.OnAddProduct?.Invoke(this, new ProductEventArgs { Product = product });
            Validator validator = new Validator();
            validator.ValidateLink(product);
            this._repository.Add(product);
            this.OnAddedProduct?.Invoke(this, new ProductEventArgs { Product = product });
        }

        /// <summary>
        /// Sells products from repository.
        /// </summary>
        /// <param name="product">
        /// The product to sell.
        /// </param>
        public void SellProduct(Product product)
        {
            this.OnSellProduct?.Invoke(this, new ProductEventArgs { Product = product });
            Validator validator = new Validator();
            validator.ValidateLink(product);
            this._repository.Delete(product);
            this.OnSoldProduct?.Invoke(this, new ProductEventArgs { Product = product });
        }
    }
}
