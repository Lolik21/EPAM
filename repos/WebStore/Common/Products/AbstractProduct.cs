
namespace Common
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    using WebStore;

    public abstract class AbstractProduct
    {
        private string _name;

        private string _description;

        private double _weight;



        /// <summary>
        /// Gets or sets the id of the product.
        /// </summary>
        public uint ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                Validator validator = new Validator();
                validator.ValidateName(value);
                _name = value;
            }
        }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        public uint Price { get; set; }

        /// <summary>
        /// Gets or sets the weight of the product.
        /// </summary>
        public double Weight
        {
            get
            {
                return this.Weight;
            }
            set
            {
                Validator validator = new Validator();
                validator.ValidateWeight(value);
                this.Weight = value;
            }
        }

        /// <summary>
        /// Gets or sets the description of the product.
        /// </summary>
        public string Description
        {
            get
            {
                return this.Description;
            }
            set
            {
                Validator validator = new Validator();
                validator.ValidateDescription(value);
                this.Description = value;
            }
        }

        /// <summary>
        /// Gets or sets the count of the product.
        /// </summary>
        public uint Count { get; set; }

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

            AbstractProduct product = obj as AbstractProduct;
            if (product == null)
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
            unchecked
            {
                var hashCode = (int)this.ID;
                hashCode = (hashCode * 397) ^ (int)this.Price;
                return hashCode;
            }
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
            bool isEquals = !(this.Name != product.Name && 
                this.Description != product.Description && 
                this.Price != product.Price && 
                this.Weight != product.Weight);
            return isEquals;
        }
            
    }
}
