using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public interface IEventRepository<TEntity>
    {
        Task<int> Add(TEntity entity);
        Task<int> Update(TEntity entity);
        Task<int> Delete(int id);
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetAll();
    }
}
