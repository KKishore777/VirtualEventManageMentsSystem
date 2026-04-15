using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public interface IParticipantEventRepository
    {
        // Register participant to event/session
        Task<int> Register(ParticipantEventDetails entity);

        // Update attendance (True / False)
        Task<int> UpdateAttendance(int id, bool status);

        // Get all registrations of a participant
        Task<List<ParticipantEventDetails>> GetByUser(string email);

        // Get all records (Admin use)
        Task<List<ParticipantEventDetails>> GetAll();

        // Get by Id
        Task<ParticipantEventDetails> GetById(int id);

        // Delete registration
        Task<int> Delete(int id);
    }

}
