namespace Common
{
    using WebStore;

    /// <summary>
    /// The phone product.
    /// </summary>
    public class ConcreteProduct : AbstractProduct
    {
        /// <summary>
        /// The _width.
        /// </summary>
        private double _width;

        /// <summary>
        /// The _height.
        /// </summary>
        private double _height;

        /// <summary>
        /// The weight of the product.
        /// </summary>
        private double _weight;

        /// <summary>
        /// Gets or sets the weight of the product.
        /// </summary>
        public double Weight
        {
            get => this._weight;
            set
            {
                Validator validator = new Validator();
                validator.ValidateWeight(value);
                this._weight = value;
            }
        }

        /// <summary>
        /// Gets or sets the width of the product.
        /// </summary>
        public double Width
        {
            get => this._width;

            set 
            {
                Validator validator = new Validator();
                validator.ValidateSize(value);
                this._width = value;
            }
        }

        /// <summary>
        /// Gets or sets the height of the product.
        /// </summary>
        public double Height
        {
            get => this._height;
            set
            {
                Validator validator = new Validator();
                validator.ValidateSize(value);
                this._height = value;
            }
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
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

            return obj is ConcreteProduct product && this.CompareFields(product);
        }

        /// <summary>
        /// Gets hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/> hash code.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)this.Height;
                hashCode = (hashCode * 397) ^ (int)this.Width;
                hashCode = (hashCode * 397) ^ (int)this.Weight;
                return hashCode;
            }
        }

        /// <summary>
        /// Compares fields of the phone product.
        /// </summary>
        /// <param name="product">
        /// The phone product.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/> true if products fields is equal
        /// vice versa  return false.
        /// </returns>
        protected override bool CompareFields(AbstractProduct product)
        {
            var isEquals = base.CompareFields(product);
            if (!(product is ConcreteProduct phoneProduct))
            {
                return false;
            }

            isEquals = isEquals && this.Width == phoneProduct.Width
                && this.Height == phoneProduct.Height && this.Weight == phoneProduct.Weight;
            return isEquals;
        }
    }
}