using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Common;
using Services.Repository;

namespace Services
{
    public class UserService : IUserService
    {
        public IUserRepository Rep { get; set; }
        public void Register(User user)
        {
            if (string.IsNullOrEmpty(user.Login))
            {
                throw new ArgumentNullException(nameof(user.Login));
            }

            Rep.Create(user);
        }
    }
}
