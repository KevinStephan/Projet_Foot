using CoffeeTime.Foot.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeTime.Foot.Core.Business.Services
{
    public class UserService : BaseService
    {
        public User GetById(int Id)
        {
            return DataModel.Users.Where(o => o.Id == Id).FirstOrDefault();
        }

        public List<User> GetAll()
        {
            List<User> listUsers = (from o in DataModel.Users select o).ToList();
            return listUsers;
        }

        public User Create(string lastName, string firstName, DateTime birthDate, string email, string password)
        {
            User user = new User()
            {
                LastName = lastName,
                FirstName = firstName,
                BirthDate = birthDate,
                Email = email,
                Password = password,
                InscriptionDate = DateTime.Now,
                Login = firstName+"."+lastName
            };
            DataModel.Users.Add(user);
            DataModel.SaveChanges();
            return user;
        }

        public User Update(int id, string lastName, string firstName, DateTime birthDate, string email, string password)
        {
            User user = GetById(id);
            user.LastName = lastName;
            user.FirstName = firstName;
            user.BirthDate = birthDate;
            user.Email = email;
            user.Password = password;
            try
            {
                DataModel.SaveChanges();
                return user;
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
        }

        public void Delete(int id)
        {
            User user = GetById(id);
            DataModel.Users.Remove(user);
            DataModel.SaveChanges();
        }

    }
}
