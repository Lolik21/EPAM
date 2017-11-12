using Services.Common;

namespace Services
{
    /// <summary>
    /// Include method that need to be realized
    /// in user service class
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Register's new user
        /// </summary>
        /// <param name="user">User to register</param>
        void Register(User user);

        /// <summary>
        /// Login using login and password
        /// </summary>
        /// <param name="login">User login</param>
        /// <param name="password">User password</param>
        /// <returns>true if login is successfully complete
        /// overwise return false</returns>
        bool Login(string login, string password);

        /// <summary>
        /// Get's user by ID
        /// </summary>
        /// <param name="id">ID if user to get</param>
        /// <returns>User associated with ID</returns>
        User GetUser(int id);

        /// <summary>
        /// Get's user by login
        /// </summary>
        /// <param name="login">Login of user to get</param>
        /// <returns>User associated with logib</returns>
        User GetUserByLogin(string login);

        /// <summary>
        /// Unregister's user using user ID
        /// </summary>
        /// <param name="id">ID of user to unregister</param>
        void Unregister(int id);

        /// <summary>
        /// Check's user by email
        /// </summary>
        /// <param name="email">Email of user to check</param>
        /// <returns>true if threre is user with such email
        /// overwise return false</returns>
        bool CheckUserByEmail(string email);
    }
}