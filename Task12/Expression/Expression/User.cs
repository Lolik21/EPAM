using System;

namespace MyExpression
{
    /// <summary>
    /// The user.
    /// </summary>
    public class User
    {
        /// <summary>
        /// The approximately days per year.
        /// </summary>
        private const double DAYS_PER_YEAR = 365.25;

        /// <summary>
        /// Gets or sets the users id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the users name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the users end name.
        /// </summary>
        public string SurName { get; set; }

        /// <summary>
        /// Gets or sets the users birth date.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets the users age.
        /// </summary>
        public int Age
        {
            get
            {
                int days = (DateTime.Now - this.BirthDate).Days;
                return (int)(days / DAYS_PER_YEAR);
            }
        }
    }
}
