using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RESTfulWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RESTUserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RESTUserService.svc or RESTUserService.svc.cs at the Solution Explorer and start debugging.
    public class RESTUserService : IUserService
    {
        static Users _users = new Users();
        public Users GetAllUsers()
        {
            //IN YOUR CASE YOU'D PROBABLY ACCESS A DB
            //OR A WEB SERVICE TO RETRIEVE ACTUAL DATA
            GenerateFakeUsers();
            return _users;
        }
        public User AddNewUser(User u)
        {
            u.UserId = Guid.NewGuid().ToString();
            //IN YOUR CASE YOU'D PROBABLY ACCESS A DB
            //OR A WEB SERVICE TO SAVE ACTUAL DATA
            _users.Add(u);
            return u;
        }
        public User GetUser(string user_id)
        {
            var u = FindUser(user_id);
            return u;
        }
        private User FindUser(string user_id)
        {
            //IN YOUR CASE YOU'D PROBABLY ACCESS A DB
            //OR A WEB SERVICE TO RETRIEVE ACTUAL DATA
            return new User()
            {
                FirstName = "FirstName1",
                LastName = "LastName1",
                Email = "email1@demoDomain.com",
                UserId = "1"
            };
        }
        private void GenerateFakeUsers()
        {
            _users.Add(new User()
            {
                FirstName = "FirstName1",
                LastName = "LastName1",
                Email = "email1@demoDomain.com",
                UserId = "1"
            });
            _users.Add(new User()
            {
                FirstName = "FirstName2",
                LastName = "LastName2",
                Email = "email2@demoDomain.com",
                UserId = "2"
            });
        }
    }
}
