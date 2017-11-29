namespace WebStore
{
    using System;
    using Common;
    using Repository;

    using WebStore.Exceptions;

    /// <summary>
    /// The sell service.
    /// </summary>
    public class SellService
    {
        /// <summary>
        /// The repository that's store products.
        /// </summary>
        private readonly IRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SellService"/> class.
        /// </summary>
        /// <param name="repository">
        /// The repository.
        /// </param>
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
        /// The on delete product event.
        /// </summary>
        public event EventHandler<ProductEventArgs> OnDeleteProduct;

        /// <summary>
        /// The on deleted product event.
        /// </summary>
        public event EventHandler<ProductEventArgs> OnDeletedProduct;

        /// <summary>
        /// The on update product event.
        /// </summary>
        public event EventHandler<ProductEventArgs> OnUpdateProduct;

        /// <summary>
        /// The on updated product event.
        /// </summary>
        public event EventHandler<ProductEventArgs> OnUpdatedProduct;

        /// <summary>
        /// Adds product to repository.
        /// </summary>
        /// <param name="product">
        /// The product to add.
        /// </param>
        public void AddProduct(AbstractProduct product)
        {
            this.OnAddProduct?.Invoke(this, new ProductEventArgs { Product = product });
            Validator validator = new Validator();
            validator.ValidateLink(product);
            this._repository.Add(product);
            this.OnAddedProduct?.Invoke(this, new ProductEventArgs { Product = product });
        }

        /// <summary>
        /// Sells products from repository.
        /// Invokes events when sell and when sold.
        /// </summary>
        /// <param name="product">
        /// The product to sell.
        /// </param>
        public void SellProduct(AbstractProduct product)
        {
            this.OnSellProduct?.Invoke(this, new ProductEventArgs { Product = product });
            Validator validator = new Validator();
            validator.ValidateLink(product);
            this._repository.SellProduct(product);
            this.OnSoldProduct?.Invoke(this, new ProductEventArgs { Product = product });
        }

        /// <summary>
        /// Deletes product from repository by id.
        /// Invokes events when deleted and when delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void DeleteProduct(uint id)
        {
            this.OnDeleteProduct?.Invoke(this, new ProductEventArgs { Product = this._repository.Get(id) });
            try
            {
                this._repository.Delete(id);
                this.OnDeletedProduct?.Invoke(this, new ProductEventArgs { Product = this._repository.Get(id) });
            }
            catch (ArgumentOutOfRangeException exception)
            {
                throw new DeleteNotCompletedException("Fail to delete", exception);
            }                  
        }

        /// <summary>
        /// Updates product from repository.
        /// Invokes events when update and when updated.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        public void UpdateProduct(AbstractProduct product)
        {
            this.OnUpdateProduct?.Invoke(this, new ProductEventArgs { Product = product });
            Validator validator = new Validator();
            validator.ValidateLink(product);
            this._repository.Update(product);
            this.OnUpdatedProduct?.Invoke(this, new ProductEventArgs { Product = product });
        }
    }
}
