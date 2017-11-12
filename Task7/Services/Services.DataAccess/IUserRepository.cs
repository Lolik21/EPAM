using Services.Common;

namespace Services.DataAccess
{
    /// <summary>
    /// Interface for repository methods
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Create's user according to passing user class
        /// </summary>
        /// <param name="user">User to create</param>
        void Create(User user);

        /// <summary>
        /// Get's user from repository
        /// </summary>
        /// <param name="id">Id of user to get</param>
        /// <returns></returns>
        User Get(int id);

        /// <summary>
        /// Update user in repository according passing params
        /// </summary>
        /// <param name="user">User to update</param>
        void Update(User user);

        /// <summary>
        /// Delete's user from repository by Id
        /// </summary>
        /// <param name="id">Id of user to delete</param>
        void Delete(int id);

        /// <summary>
        /// Get's user by email
        /// </summary>
        /// <param name="email">Email of user to get</param>
        /// <returns>User associated with email</returns>
        User GetByEmail(string email);

        /// <summary>
        /// Get's user be login
        /// </summary>
        /// <param name="login">Login of user to get</param>
        /// <returns>User associated with login</returns>
        User GetByLogin(string login);
    }
}