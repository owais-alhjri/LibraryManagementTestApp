using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Domain.Entities;

namespace LMS.Domain.Repositories
{
    public interface IUserRepository
    {
         Task AddUserAsync(User user);

         Task SaveChangesAsync();
    }
}
