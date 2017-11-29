namespace WebStore
{
    using System;
    using System.Activities;
    using System.Text.RegularExpressions;

    using Common;

    using WebStore.Exceptions;

    public class Validator
    {
        private const int NAME_MINLENGTH = 10;
        private const int NAME_MAXLENGTH = 50;
        private const int DESC_MINLENGTH = 10;
        private const int DESC_MAXLENGTH = 1000;

        /// <summary>
        /// Validates product fields.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        public void ValidateProduct(Product product)
        {
            this.ValidateLink(product);
            this.ValidateName(product.Name);
            this.ValidateDescription(product.Description);
            this.ValidateSize(product.Width);
            this.ValidateWeight(product.Weight);
        }

        /// <summary>
        /// Validates link.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws when Product is null
        /// </exception>
        public void ValidateLink(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
        }

        /// <summary>
        /// Validates name.
        /// </summary>
        /// <param name="name">
        /// The name of the product.
        /// </param>
        public void ValidateName(string name)
        {
            this.ValidateString(name, NAME_MINLENGTH, NAME_MAXLENGTH);
        }

        /// <summary>
        /// Validates description.
        /// </summary>
        /// <param name="desctiption">
        /// The description of the product.
        /// </param>
        public void ValidateDescription(string desctiption)
        {
            this.ValidateString(desctiption, DESC_MINLENGTH, DESC_MAXLENGTH);
        }

        /// <summary>
        /// Validates size.
        /// </summary>
        /// <param name="sizeParam">The size parameter</param>
        /// <exception cref="InvalidSizeException">
        /// Throws when size is invalid (width or height is zero or less)
        /// </exception>
        public void ValidateSize(double sizeParam)
        {
            if (sizeParam <= 0)
            {
                throw new InvalidSizeException("");
            }
        }

        /// <summary>
        /// Validates weight.
        /// </summary>
        /// <param name="weight">
        /// The weight of the product.
        /// </param>
        /// <exception cref="InvalidWeightException">
        /// Throws when weight is zero or less
        /// </exception>
        public void ValidateWeight(double weight)
        {
            if (weight <= 0)
            {
                throw new InvalidWeightException();
            }
        }

        /// <summary>
        /// Validates string.
        /// </summary>
        /// <param name="str">
        /// The string to validate.
        /// </param>
        /// <param name="minLength">
        /// The min length.
        /// </param>
        /// <param name="maxLength">
        /// The max length.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws when string is null
        /// </exception>
        /// <exception cref="EmptyStringException">
        /// Throws when string is empty
        /// </exception>
        /// <exception cref="ValidationException">
        /// Throws when regular expression validation failed
        /// </exception>
        private void ValidateString(string str, int minLength,int maxLength)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }
            if (string.IsNullOrEmpty(str))
            {
                throw new EmptyStringException(nameof(str));
            }
            if (!Regex.IsMatch(str, $"^[a-zA-Z ]{{{minLength},{maxLength}}}$"))
            {
                throw new ValidationException(nameof(str));
            }
        }

    }
}