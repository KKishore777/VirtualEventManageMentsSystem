using DAL.DataAccess;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace DAL.DataAccess
{
    public class SessionServices : ISessionRepository<SessionInfo>
    {
        private readonly Context _context;

        public SessionServices(Context context)
        {
            _context = context;
        }
        public async Task Add(SessionInfo session)
        {
            _context.sessionInfos.Add(session);
            await _context.SaveChangesAsync();
        }

       
       public async Task<int> Delete(int id)
        {

                var ExistId = _context.sessionInfos.FirstOrDefault(eve => eve.SessionId.Equals(id));
                if (ExistId is not null)
                {
                    _context.sessionInfos.Remove(ExistId);//method change the state of an entity from unchanged to Remove
                    return await _context.SaveChangesAsync();

                }
                else
                {
                    return 0;
                }


        }        

        public async Task<List<SessionInfo>> GetAll()
        {
            return await _context.sessionInfos.ToListAsync();
        }
       

    }
}
