namespace WebStore
{
    using System;

    using Common;

    /// <summary>
    /// The product event args.
    /// </summary>
    public class ProductEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        public Product Product { get; set; }
    }
}