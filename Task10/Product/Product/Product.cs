using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{

    /// <summary>
    /// The product.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// The on price change event.
        /// </summary>
        public event EventHandler OnPriceChange;

        /// <summary>
        /// The on price changed event.
        /// </summary>
        public event EventHandler OnPriceChanged;

        /// <summary>
        /// The price of the product.
        /// </summary>
        private decimal _price;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Throws when value is less than zero
        /// </exception>
        public decimal Price
        {
            get => this._price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Value is less than zero");
                }
                this.OnPriceChange?.Invoke(this, EventArgs.Empty);
                this._price = value;
                this.OnPriceChanged?.Invoke(this, EventArgs.Empty);
            }
        }

    }
}
