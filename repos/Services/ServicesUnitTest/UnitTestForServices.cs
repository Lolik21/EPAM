using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Common;
using Services.Repository;
using Services;
using Moq;

namespace ServicesUnitTest
{
    [TestClass]
    public class UnitTestForServices
    {
        private User _user;
        private Mock<IUserRepository> _repository;
        [TestInitialize]
        public void Init()
        {
            _user = new User
            {
                Login = "Admin"
            };
            _repository = new Mock<IUserRepository>();
            _repository.Setup(r => r.Create(It.IsAny<User>()))
                .Callback<User>(u => u.Id += 10);
        }
        [TestMethod]
        public void RegisterTest()
        {
            var service = new UserService();
            service.Rep = _repository.Object;
            service.Register(_user);
            Assert.AreNotEqual(default(int), _user.Id);
            _repository.Verify();
        }
    }
}
