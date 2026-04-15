using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public class UserServices : IUserRepository<UserInfo>
    {
        private readonly Context _context;
        public UserServices(Context context)
        {
            _context = context;
        }
        public void met()
        {
            var data = _context.userInfos.ToList();
        }
        public async Task<List<UserInfo>> GetAll()
        {
           
                return await _context.userInfos.ToListAsync();
            
        }

        public async Task<UserInfo> GetByEmail(string email)
        {
        
                return await _context.userInfos
                    .FirstOrDefaultAsync(u => u.EmailId == email);
            
        }

        public async Task<int> Register(UserInfo user)
        {
            
                //  Check duplicate email
                var existing = await _context.userInfos
                    .FirstOrDefaultAsync(u => u.EmailId == user.EmailId);

                if (existing != null)
                {
                    return 0; // Email already exists
                }

            _context.userInfos.Add(user);
                return await _context.SaveChangesAsync();
            
        }

        public async Task<int> Update(UserInfo entity)
        {
            
                var Existdetails = _context.userInfos.FirstOrDefault(eve => eve.EmailId.Equals(entity.EmailId));


                if (Existdetails is not null)
                {
                    Existdetails.UserName = entity.UserName;
                    Existdetails.password = entity.password;
                    Existdetails.Role = entity.Role;

                    return await _context.SaveChangesAsync();
                }
                return 0;
            
        }
    }
}
