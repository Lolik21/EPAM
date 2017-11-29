namespace Repository
{
    using Common;

    /// <summary>
    /// The Repository interface.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Adds product to repository collection.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        void Add(AbstractProduct product);

        /// <summary>
        /// Deletes product from repository collection.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        void SellProduct(AbstractProduct product);

        /// <summary>
        /// Deletes product by Id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        void Delete(uint id);

        /// <summary>
        /// Updates product from repository collection.
        /// according to ID
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        void Update(AbstractProduct product);

        /// <summary>
        /// Gets product by id.
        /// </summary>
        /// <param name="id">
        /// The id of product.
        /// </param>
        /// <returns>
        /// The <see cref="AbstractProduct"/>.
        /// </returns>
        AbstractProduct Get(uint id);
    }
}