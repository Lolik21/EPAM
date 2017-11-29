namespace WebStore
{
    using System;
    using System.Activities;
    using System.Text.RegularExpressions;

    using Common;

    using WebStore.Exceptions;

    /// <summary>
    /// The validator class that validates product fields.
    /// </summary>
    public class Validator
    {
        private const int NAME_MINLENGTH = 10;
        private const int NAME_MAXLENGTH = 50;
        private const int DESC_MINLENGTH = 10;
        private const int DESC_MAXLENGTH = 1000;

        /// <summary>
        /// Validates link.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws when Product is null
        /// </exception>
        public void ValidateLink(AbstractProduct product)
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
        /// <param name="description">
        /// The description of the product.
        /// </param>
        public void ValidateDescription(string description)
        {
            this.ValidateString(description, DESC_MINLENGTH, DESC_MAXLENGTH);
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
                throw new InvalidSizeException("Size of the product cannot be zero of less");
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
                throw new InvalidWeightException("Weight cannot be zero or less");
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
        private void ValidateString(string str, int minLength, int maxLength)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (string.IsNullOrEmpty(str))
            {
                throw new EmptyStringException(nameof(str));
            }

            if (!Regex.IsMatch(str, $"^[0-9a-zA-Z ]{{{minLength},{maxLength}}}$"))
            {
                throw new InvalidStringException(nameof(str));
            }
        }
    }
}