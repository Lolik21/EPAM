using System.Collections.Generic;

namespace Repository
{
    using System;

    using Common;

    /// <summary>
    /// The list repository.
    /// </summary>
    public class ListRepository : IRepository
    {
        /// <summary>
        /// The products list.
        /// </summary>
        private readonly List<AbstractProduct> _products;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListRepository"/> class.
        /// </summary>
        public ListRepository()
        {
            this._products = new List<AbstractProduct>();
        }

        /// <summary>
        /// Adds product to list of the products.
        /// </summary>
        /// <param name="product">
        /// The product to add.
        /// </param>
        public void Add(AbstractProduct product)
        {
            if (this._products.Contains(product))
            {
                this._products.Find(p => p.Equals(product)).Count += product.Count;
            }
            else
            {
                this._products.Add(product);
                product.Id = (uint)this._products.IndexOf(product);
            }         
        }

        /// <summary>
        /// Deletes product from list.
        /// </summary>
        /// <param name="product">
        /// The product to delete.
        /// </param>
        public void SellProduct(AbstractProduct product)
        {
            AbstractProduct foundProduct = this._products.Find(p => p.Equals(product));
            if (foundProduct.Count > 0)
            {
                foundProduct.Count--;
            }
        }

        /// <summary>
        /// Deletes product by Id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Delete(uint id)
        {
            this._products.RemoveAt((int)id);
        }

        /// <summary>
        /// Updates product from repository
        /// according to ID
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        public void Update(AbstractProduct product)
        {
            AbstractProduct foundProduct = this._products.Find(p => p.Id == product.Id);
            if (foundProduct != null)
            {
                this._products.RemoveAt((int)foundProduct.Id);
                this._products.Insert((int)foundProduct.Id, product);
            }
        }

        /// <summary>
        /// Gets product by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="AbstractProduct"/>.
        /// </returns>
        public AbstractProduct Get(uint id)
        {
            return this._products.Find(p => p.Id == id);
        }
    }
}
