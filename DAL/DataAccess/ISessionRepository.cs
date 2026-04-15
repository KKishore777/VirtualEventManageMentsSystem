using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public interface ISessionRepository<TEntity>
    {
        Task Add(SessionInfo session);
        Task<int> Delete(int id);

        Task<List<TEntity>> GetAll();
    }
}
