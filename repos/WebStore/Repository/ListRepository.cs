using System.Collections.Generic;

namespace Repository
{
    using Common;

    /// <summary>
    /// The list repository.
    /// </summary>
    public class ListRepository : IRepository
    {
        /// <summary>
        /// The products list.
        /// </summary>
        private List<Product> _products;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListRepository"/> class.
        /// </summary>
        public ListRepository()
        {
            this._products = new List<Product>();
        }

        /// <summary>
        /// Adds product to list of the products.
        /// </summary>
        /// <param name="product">
        /// The product to add.
        /// </param>
        public void Add(Product product)
        {
            if (this._products.Contains(product))
            {
                this._products.Find(p => p.Equals(product)).Count++;
            }
            else
            {
                this._products.Add(product);
                product.ID = (uint)this._products.IndexOf(product);
            }         
        }

        /// <summary>
        /// Deletes product from list.
        /// </summary>
        /// <param name="product">
        /// The product to delete.
        /// </param>
        public void Delete(Product product)
        {
            Product findedProduct = this._products.Find(p => p == product);

            if (findedProduct.Count > 0)
            {
                findedProduct.Count--;
            }
            else
            {
                this._products.Remove(findedProduct);
            }
        }
    }
}
