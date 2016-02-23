using MyMedicalGuide.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedicalGuide.Services.Contracts
{
    public interface IUsersService
    {
        void Create(User user, string role);

        User GetUserById(string id);
    }
}
