namespace Product
{
    using System;
    using System.Reflection;

    /// <summary>
    /// The reflection helper.
    /// </summary>
    public static class ReflectionHelper
    {
        private const string PRICE_CHANGE_NAME = "OnPriceChange";
        private const string PRICE_CHANGED_NAME = "OnPriceChanged";
        private const string PRICE_PROP_NAME = "Price";

        /// <summary>
        /// Activates product instance.
        /// </summary>
        /// <returns>
        /// The <see cref="Product"/> instance.
        /// </returns>
        public static Product ActivateProduct()
        {
            return Activator.CreateInstance<Product>();
        }

        /// <summary>
        /// Assigns handlers to event.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        /// <param name="priceChangedHandler">
        /// The price changed handler.
        /// </param>
        /// <param name="priceChangeHandler">
        /// The price change handler.
        /// </param>
        public static void AssignToEvent(
            Product product,
            EventHandler priceChangedHandler,
            EventHandler priceChangeHandler)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            Type productType = product.GetType();
            EventInfo changeEventInfo = productType.GetEvent(PRICE_CHANGE_NAME);
            EventInfo changedEventInfo = productType.GetEvent(PRICE_CHANGED_NAME);
            if (changeEventInfo != null)
            {
                changeEventInfo.AddEventHandler(product, priceChangeHandler);
            }
            if (changedEventInfo != null)
            {
                changedEventInfo.AddEventHandler(product, priceChangedHandler);
            }
        }

        /// <summary>
        /// Raises events by changing price property value.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        /// <param name="newPrice">
        /// The new price.
        /// </param>
        public static void RaiseEvent(Product product, decimal newPrice)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            Type productType = product.GetType();
            PropertyInfo propertyInfo = productType.GetProperty(PRICE_PROP_NAME);
            if (propertyInfo != null)
            {
                propertyInfo.SetValue(product, newPrice);
            }
        }
    }
}