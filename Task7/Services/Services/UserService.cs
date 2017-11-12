using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Common;
using Services.DataAccess;

namespace Services
{
    /// <summary>
    /// Class that realize user service methods
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly Validator _validator;

        /// <summary>
        /// Ctor to get repository and create validator class
        /// </summary>
        /// <param name="repository">Repository interface</param>
        public UserService(IUserRepository repository)
        {
            _repository = repository;
            _validator = new Validator();
        }

        public void Register(User user)
        {
            _validator.IsUserValid(user);
            _repository.Create(user);
        }

        public bool Login(string login, string password)
        {
            _validator.IsLoginValid(login);
            _validator.IsPasswdValid(password);     
            User user = _repository.GetByLogin(login);
            if (user == null)
            {
                throw new ArgumentNullException("User not found");
            }
            if (user.Password == password) return true;
            return false;
        }

        public User GetUser(int id)
        {
            _validator.IsIdValid(id);
            return _repository.Get(id);
        }

        public User GetUserByLogin(string login)
        {
            _validator.IsLoginValid(login);
            return _repository.GetByLogin(login);
        }

        public void Unregister(int id)
        {
            _validator.IsIdValid(id);
            _repository.Delete(id);
        }

        public bool CheckUserByEmail(string email)
        {
            _validator.IsEmailValid(email);
            User user = _repository.GetByEmail(email);
            return user == null ? false : true;
        }
    }
}
