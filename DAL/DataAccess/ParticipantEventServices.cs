using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public class ParticipantEventServices : IParticipantEventRepository
    {
        private readonly Context _context;
        public ParticipantEventServices(Context context)
        {
            _context = context;
        }
        public void met()
        {
            var data = _context.userInfos.ToList();
        }
        public async Task<int> Delete(int id)
        {
           
                var record = await _context.participantEventDetails
                    .FirstOrDefaultAsync(p => p.ID == id);

                if (record != null)
                {
                _context.participantEventDetails.Remove(record);
                    return await _context.SaveChangesAsync();
                }
                else
                {
                    return 0;

                }
            
        }

        public async Task<List<ParticipantEventDetails>> GetAll()
        {

                return await _context.participantEventDetails.ToListAsync();
            
        }

        public async Task<ParticipantEventDetails> GetById(int id)
        {

                return await _context.participantEventDetails
                    .FirstOrDefaultAsync(p => p.ID == id);
            
        }

        public async Task<List<ParticipantEventDetails>> GetByUser(string email)
        {

                return await _context.participantEventDetails
                    .Where(p => p.EmailId == email)
                    .ToListAsync();
            
        }

        public async Task<int> Register(ParticipantEventDetails entity)
        {

            _context.participantEventDetails.Add(entity);
                return await _context.SaveChangesAsync();
            
        }

        public async Task<int> UpdateAttendance(int id, bool status)
        {
          
                var record = await _context.participantEventDetails
                    .FirstOrDefaultAsync(p => p.ID == id);

                if (record != null)
                {
                    record.IsAttended = status;
                    return await _context.SaveChangesAsync();
                }
                else
                {
                    return 0;
                }
            
        }
    }
}
