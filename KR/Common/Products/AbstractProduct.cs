
namespace Common
{
    using WebStore;

    /// <summary>
    /// The abstract product.
    /// </summary>
    public abstract class AbstractProduct
    {
        /// <summary>
        /// The name of the product.
        /// </summary>
        private string _name;

        /// <summary>
        /// The description of the product.
        /// </summary>
        private string _description;

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string Name
        {
            get => this._name;
            set
            {
                Validator validator = new Validator();
                validator.ValidateName(value);
                this._name = value;
            }
        }    

        /// <summary>
        /// Gets or sets the description of the product.
        /// </summary>
        public string Description
        {
            get => this._description;
            set
            {
                Validator validator = new Validator();
                validator.ValidateDescription(value);
                this._description = value;
            }
        }

        /// <summary>
        /// Gets or sets the id of the product.
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        public uint Price { get; set; }

        /// <summary>
        /// Gets or sets the count of the product.
        /// P.S my shop is too small to operate
        /// numbers near max values of unsigned integer
        /// </summary>
        public uint Count { get; set; }

        /// <summary>
        /// Compares two products.
        /// </summary>
        /// <param name="obj">
        /// The product to compare.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/> true if product is equal
        /// vice versa returns false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (!(obj is AbstractProduct product))
            {
                return false;
            }

            return this.CompareFields(product);
        }

        /// <summary>
        /// Gets hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/> hash code.
        /// </returns>
        public override int GetHashCode()
        {
            var hashCode = this._name.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Compares products fields.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/> true when fields 
        /// is Equal vice versa false.
        /// </returns>
        protected virtual bool CompareFields(AbstractProduct product)
        {
            var isEquals = this.Name == product.Name && this.Description == product.Description
                           && this.Price == product.Price ;
            return isEquals;
        }
    }
}
