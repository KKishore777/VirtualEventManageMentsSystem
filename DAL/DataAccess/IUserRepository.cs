using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public interface IUserRepository<TEntity>
   
    {

        // Update user profile
        Task<int> Update(TEntity entity);

        // Register new user
        Task<int> Register(TEntity user);

        // Get user by Email (for login)
        Task<UserInfo> GetByEmail(string email);

        // Get all users (optional - admin)
        Task<List<UserInfo>> GetAll();

    }
}
