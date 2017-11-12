using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Services.Common;
using Services.DataAccess;

namespace Services.Tests
{
    [TestClass()]
    public class UserServiceTests
    {
        private Mock<IUserRepository> _repositoryMoq;
        private User _user;


        [TestInitialize]
        public void Initialize()
        {
            _user = new User
            {
                Login = "Haker123123",
                Password = "123123123123",
                BirthDate = new DateTime(1998, 2, 28),
                CreatedDate = DateTime.Now,
                Email = "cvobodne@yandex.ru",
                FirstName = "Ilya",
                LastName = "Kremniou",
                Id = 0,
            };

            _repositoryMoq = new Mock<IUserRepository>();
            _repositoryMoq.Setup(r => r.Create(It.IsAny<User>()))
                .Callback<User>(u => u.Id += 10);
            _repositoryMoq.Setup(r => r.Get(It.Is<int>(i => i == 0))).Returns(_user);
            _repositoryMoq.Setup(r => r.GetByLogin(It.Is<string>(str => 
                str == "Haker123123"))).Returns(_user);
            _repositoryMoq.Setup(r => r.GetByEmail(It.Is<string>(str =>
                str == "cvobodne@yandex.ru"))).Returns(_user);
            _repositoryMoq.Setup(r => r.Delete(It.Is<int>(i => i == 0))).Callback(() =>
            {
                User myUser = null;
                _repositoryMoq.Reset();
                _repositoryMoq.Setup(r => r.Get(It.Is<int>(i => i == 0))).Returns(myUser);               
            });
        }

        [TestMethod()]
        public void RegisterTest()
        {

            User user = new User
            {
                Login = "Hacker12345",
                Password = "123123123123",
                BirthDate = new DateTime(1998, 2, 28),
                CreatedDate = DateTime.Now,
                Email = "cvobodne@yandex.ru",
                FirstName = "Ilya",
                LastName = "Kremniou",
                Id = 0,
            };

            var service = new UserService(_repositoryMoq.Object);
            service.Register(user);

            Assert.AreNotEqual(default(int), user.Id);
            _repositoryMoq
                .Verify(r => r.Create(It.IsAny<User>()), () => Times.Exactly(1));
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidationException))]
        public void RegisterTestWithInvalidLogin()
        {
            User user = new User
            {
                Login = "H",
                Password = "123123123123",
                BirthDate = new DateTime(1998, 2, 28),
                CreatedDate = DateTime.Now,
                Email = "cvobodne@yandex.ru",
                FirstName = "Ilya",
                LastName = "Kremniou",
                Id = 0,
            };

            var service = new UserService(_repositoryMoq.Object);
            service.Register(user);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void RegisterTestWithInvalidEmail()
        {
            User user = new User
            {
                Login = "Haker123123",
                Password = "123123123123",
                BirthDate = new DateTime(1998, 2, 28),
                CreatedDate = DateTime.Now,
                Email = "cvobodn",
                FirstName = "Ilya",
                LastName = "Kremniou",
                Id = 0,
            };

            var service = new UserService(_repositoryMoq.Object);
            service.Register(user);
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidationException))]
        public void RegisterTestWithInvalidID()
        {
            User user = new User
            {
                Login = "Haker123123",
                Password = "123123123123",
                BirthDate = new DateTime(1998, 2, 28),
                CreatedDate = DateTime.Now,
                Email = "cvobodne@yandex.ru",
                FirstName = "Ilya",
                LastName = "Kremniou",
                Id = -4999,
            };

            var service = new UserService(_repositoryMoq.Object);
            service.Register(user);
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidationException))]
        public void RegisterTestWithInvalidFirstName()
        {
            User user = new User
            {
                Login = "Haker123123",
                Password = "123123123123",
                BirthDate = new DateTime(1998, 2, 28),
                CreatedDate = DateTime.Now,
                Email = "cvobodne@yandex.ru",
                FirstName = "",
                LastName = "Kremniou",
                Id = 0,
            };

            var service = new UserService(_repositoryMoq.Object);
            service.Register(user);
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidationException))]
        public void RegisterTestWithInvalidLastName()
        {
            User user = new User
            {
                Login = "Haker123123",
                Password = "123123123123",
                BirthDate = new DateTime(1998, 2, 28),
                CreatedDate = DateTime.Now,
                Email = "cvobodne@yandex.ru",
                FirstName = "Ilya",
                LastName = "",
                Id = 0,
            };

            var service = new UserService(_repositoryMoq.Object);
            service.Register(user);
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidationException))]
        public void RegisterTestWithInvalidBirthDate()
        {
            User user = new User
            {
                Login = "Haker123123",
                Password = "123123123123",
                BirthDate = new DateTime(1898, 2, 28),
                CreatedDate = DateTime.Now,
                Email = "cvobodne@yandex.ru",
                FirstName = "Ilya",
                LastName = "Kremniou",
                Id = 0,
            };

            var service = new UserService(_repositoryMoq.Object);
            service.Register(user);
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidationException))]
        public void RegisterTestWithInvalidPassword()
        {
            User user = new User
            {
                Login = "Haker123123",
                Password = "123",
                BirthDate = new DateTime(1998, 2, 28),
                CreatedDate = DateTime.Now,
                Email = "cvobodne@yandex.ru",
                FirstName = "Ilya",
                LastName = "Kremniou",
                Id = 0,
            };
            
            var service = new UserService(_repositoryMoq.Object);
            service.Register(user);
        }

        [TestMethod()]
        public void LoginTest()
        {
            var service = new UserService(_repositoryMoq.Object);
            bool rezult = service.Login(_user.Login, _user.Password);  
            Assert.AreEqual(true, rezult);
        }

        [TestMethod()]
        public void LoginTestWithAnotherPassword()
        {
            var service = new UserService(_repositoryMoq.Object);
            bool rezult = service.Login(_user.Login, "olololololololololo");
            Assert.AreEqual(false, rezult);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoginTestWithNotExistingLogin()
        {
           
            var user = new User
            {
                Login = "Haker123123",
                Password = "123123123123",
                BirthDate = new DateTime(1998, 2, 28),
                CreatedDate = DateTime.Now,
                Email = "cvobodne@yandex.ru",
                FirstName = "Ilya",
                LastName = "Kremniou",
                Id = 0,
            };

            var repositoryMoq = new Mock<IUserRepository>();
            repositoryMoq.Setup(r => r.GetByLogin(It.Is<string>(str =>
                str == "Haker123123"))).Returns(user);
            var service = new UserService(repositoryMoq.Object);
            bool rezult = service.Login("NotExistingLogin123", user.Password);
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidationException))]
        public void LoginTestWithInvalidLogin()
        {
            var service = new UserService(_repositoryMoq.Object);
            bool rezult = service.Login("asd", _user.Password);
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidationException))]
        public void LoginTestWithInvalidPassword()
        {
            var service = new UserService(_repositoryMoq.Object);            
            bool rezult = service.Login(_user.Login, "asd");
        }

        [TestMethod()]
        public void GetUserTest()
        {
            var service = new UserService(_repositoryMoq.Object);
            User rezult = service.GetUser(_user.Id);
            Assert.AreEqual(_user, rezult);
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidationException))]
        public void GetUserTestWithInvalidID()
        {
            var service = new UserService(_repositoryMoq.Object);
            User rezult = service.GetUser(_user.Id - 10000);
        }

        [TestMethod()]
        public void GetUserByLoginTest()
        {
            var service = new UserService(_repositoryMoq.Object);
            User rezult = service.GetUserByLogin("Haker123123");
            Assert.AreEqual(_user, rezult);
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidationException))]
        public void GetUserByLoginTestWithInvalidEmail()
        {
            var service = new UserService(_repositoryMoq.Object);
            User rezult = service.GetUserByLogin("23123");
        }

        [TestMethod()]
        public void GetUserByLoginTestNoSuchUser()
        {
            var service = new UserService(_repositoryMoq.Object);
            User rezult = service.GetUserByLogin("fds2323532141asd13");
            Assert.AreEqual(null, rezult);
        }

        [TestMethod()]
        public void UnregisterTest()
        {
            var service = new UserService(_repositoryMoq.Object);
            service.Unregister(_user.Id);

            User user = service.GetUser(0);

            Assert.AreEqual(null, user);
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidationException))]
        public void UnregisterTestWithInvalidID()
        {
            var service = new UserService(_repositoryMoq.Object);
            service.Unregister(-10000);
        }

        [TestMethod()]
        public void CheckByEmailTest()
        {
            var service = new UserService(_repositoryMoq.Object);
            bool rez = service.CheckUserByEmail(_user.Email);
            Assert.AreEqual(true, rez);
        }

        [TestMethod()]
        public void CheckByEmailTestWithNonExistUser()
        {
            var service = new UserService(_repositoryMoq.Object);
            bool rez = service.CheckUserByEmail("cvobdddodne@yandex.ru");
            Assert.AreEqual(false, rez);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void CheckByEmailTestWithInvalidEmail()
        {
            var service = new UserService(_repositoryMoq.Object);
            bool rez = service.CheckUserByEmail("cvobdandex.ru");
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RegisterTestWithNullUser()
        {
            User user = null;
            var service = new UserService(_repositoryMoq.Object);
            service.Register(user);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RegisterTestWithNullLogin()
        {
            User user = new User
            {
                Login = null,
                Password = "125234123423",
                BirthDate = new DateTime(1998, 2, 28),
                CreatedDate = DateTime.Now,
                Email = "cvobodne@yandex.ru",
                FirstName = "Ilya",
                LastName = "Kremniou",
                Id = 0,
            };

            var service = new UserService(_repositoryMoq.Object);
            service.Register(user);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RegisterTestWithNullPassword()
        {
            User user = new User
            {
                Login = "Hacker123123123",
                Password = null,
                BirthDate = new DateTime(1998, 2, 28),
                CreatedDate = DateTime.Now,
                Email = "cvobodne@yandex.ru",
                FirstName = "Ilya",
                LastName = "Kremniou",
                Id = 0,
            };

            var service = new UserService(_repositoryMoq.Object);
            service.Register(user);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RegisterTestWithNullEmail()
        {
            User user = new User
            {
                Login = "Hacker123123123",
                Password = "125234123423",
                BirthDate = new DateTime(1998, 2, 28),
                CreatedDate = DateTime.Now,
                Email = null,
                FirstName = "Ilya",
                LastName = "Kremniou",
                Id = 0,
            };

            var service = new UserService(_repositoryMoq.Object);
            service.Register(user);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RegisterTestWithNullFirstName()
        {
            User user = new User
            {
                Login = "Hacker123123123",
                Password = "125234123423",
                BirthDate = new DateTime(1998, 2, 28),
                CreatedDate = DateTime.Now,
                Email = "cvobodne@yandex.ru",
                FirstName = null,
                LastName = "Kremniou",
                Id = 0,
            };

            var service = new UserService(_repositoryMoq.Object);
            service.Register(user);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RegisterTestWithNullLastName()
        {
            User user = new User
            {
                Login = "Hacker123123123",
                Password = "125234123423",
                BirthDate = new DateTime(1998, 2, 28),
                CreatedDate = DateTime.Now,
                Email = "cvobodne@yandex.ru",
                FirstName = "Ilya",
                LastName = null,
                Id = 0,
            };

            var service = new UserService(_repositoryMoq.Object);
            service.Register(user);
        }


    }
}