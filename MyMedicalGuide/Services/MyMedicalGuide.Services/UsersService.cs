using MyMedicalGuide.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMedicalGuide.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyMedicalGuide.Data;

namespace MyMedicalGuide.Services
{
    public class UsersService : IUsersService
    {
        private MyMedicalGuideDbContext context;

        public UsersService()
        {
            this.context = new MyMedicalGuideDbContext();
        }

        public void Create(User user, string role)
        {
            var userManager = new UserManager<User>(new UserStore<User>(context));

            userManager.Create(user);
            context.SaveChanges();
            userManager.AddToRole(user.Id, role);
            this.context.SaveChanges();

        }

        public User GetUserById(string id)
        {
            return context.Users.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
