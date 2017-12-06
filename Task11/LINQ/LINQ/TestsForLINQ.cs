using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LINQ
{
    using System.Runtime.CompilerServices;

    using DataGenerator;
    using DataGenerator.Sources;

    using User;

    [TestClass]
    public class TestsForLINQ
    {
        private List<User> _users;

        private List<User> _users2;

        [TestInitialize]
        public void Init()
        {
            DateTime dateTime = new DateTime(1950, 1, 1);
            Generator generator = new Generator();
            Generator.Default.Configure(
                c => c.Entity<User>(
                    e =>
                        {
                            e.Property(p => p.Id).DataSource<IntegerSource>();
                            e.Property(p => p.Name).DataSource<FirstNameSource>();
                            e.Property(p => p.SurName).DataSource<LastNameSource>();
                            e.Property(p => p.BirthDate).DateTimeSource(dateTime, DateTime.Now);
                        }));

            this._users = Generator.Default.List<User>(20) as List<User>;
        }

        [TestMethod]
        public void TestSelectByBirthDate1()
        {
            var selectedItems = from user in this._users where user.Age > 40 select user;
            Assert.IsTrue(selectedItems.All(user => user.Age > 40));
        }

        [TestMethod]
        public void TestSelectByBirthDate2()
        {
            var selectedItems = this._users.Where(user => user.Age > 40);
            Assert.IsTrue(selectedItems.All(user => user.Age > 40));
        }

        [TestMethod]
        public void TestSelectByBirthDateOnlyNameAndSurName1()
        {
            var selectedItems = from user in this._users
                                where user.Age > 20 && user.Age < 30
                                select new { Name = user.Name, SurName = user.SurName };

            var result = from user in this._users
                         where selectedItems.Any(user2 => user2.Name == user.Name && user2.SurName == user.SurName)
                         select user;

            Assert.AreEqual(result.Count(), selectedItems.Count());
        }

        [TestMethod]
        public void TestSelectByBirthDateOnlyNameAndSurName2()
        {
            var selectedItems = this._users.Where(user => user.Age > 20 && user.Age < 30)
                .Select(user => new { Name = user.Name, SurName = user.SurName });

            var rezult = this._users.Where(
                user => selectedItems.Any(arg => user.Name == arg.Name && user.SurName == arg.SurName));

            Assert.AreEqual(rezult.Count(), selectedItems.Count());
        }

        [TestMethod]
        public void TestSelectByNameEquals1()
        {
            this._users[0].BirthDate = DateTime.Now;
            this._users[1].BirthDate = new DateTime(1900, 1, 1);

            var result = from user in this._users join user1 in this._users on user.Name equals user1.Name select user;

            int max = result.Max(user => user.Age);
            int min = result.Min(user => user.Age);
            Assert.AreEqual(DateTime.Now.Year - 1900, max);
            Assert.AreEqual(0, min);
        }

        [TestMethod]
        public void TestSelectByNameEquals2()
        {
            this._users[0].BirthDate = DateTime.Now;
            this._users[1].BirthDate = new DateTime(1900, 1, 1);

            var result = this._users.Join(this._users, u => u.Name, u => u.Name, (user, user1) => user);

            int max = result.Max(user => user.Age);
            int min = result.Min(user => user.Age);
            Assert.AreEqual(DateTime.Now.Year - 1900, max);
            Assert.AreEqual(0, min);
        }

        [TestMethod]
        public void TestStringQueue1()
        {
            string rezStr = string.Empty;
            var rezult = from user in this._users
                         select this._users.First() == user ? rezStr += user.SurName : rezStr += "," + user.SurName;

            string RezStr = string.Empty;

            RezStr = rezult.Last();
            int i = 0;
            foreach (var s in RezStr.Split(','))
            {
                Assert.AreEqual(this._users[i].SurName, s);
                i++;
            }
        }

        [TestMethod]
        public void TestStringQueue2()
        {
            string rezult = this._users.Aggregate(string.Empty, (type, user) => type + user.SurName);

            int i = 0;
            rezult.Split().Select(
                s =>
                    {
                        Assert.AreEqual(s, this._users[i].SurName);
                        i++;
                        return s;
                    });
        }

        [TestMethod]
        public void TestSort1()
        {
            this._users[0].Name = this._users[1].Name;
            this._users[3].BirthDate = DateTime.Now;
            var rezult = from user1 in this._users orderby user1.Age descending
                         where this._users.FindAll(user => user1.Name == user.Name).Count == 1
                         join user2 in _users on user1.Age equals user2.Age
                         into pr                      
                         select pr;

            Assert.AreEqual(0, rezult.Last().FirstOrDefault().Age);
        }

        [TestMethod]
        public void TestSort2()
        {
            this._users[3].BirthDate = DateTime.Now;
            this._users[0].Name = this._users[1].Name;
            var rezult = this._users.OrderByDescending(user => user.Age)
                .Where(user => this._users.FindAll(user1 => user1.Name == user.Name).Count == 1)
                .GroupBy(user => user.Age);
            Assert.AreEqual(0, rezult.Last().FirstOrDefault().Age);
        }

        [TestMethod]
        public void TestGroup1()
        {
            var d = from user in this._users
                    select new KeyValuePair<int, string>(user.Id, user.Name + user.SurName);
            Assert.AreEqual(this._users[0].Id, d.First().Key);
        }

        [TestMethod]
        public void TestGroup2()
        {
            var d = this._users.Select(user => new KeyValuePair<int, string>
                (user.Id, user.Name + user.SurName));

            Assert.AreEqual(this._users[0].Id, d.First().Key);

        }
    }
}
