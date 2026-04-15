using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public class SpeakerServises : ISpeakerRepository<SpeakersDetails>
    {
        private readonly Context _context;
        public SpeakerServises(Context context)
        {
            _context = context;
        }
        public void met()
        {
            var data = _context.userInfos.ToList();
        }
        public async Task<int> Add(SpeakersDetails entity)
        {

            _context.speakersDetails.Add(entity);
                return await _context.SaveChangesAsync();
            
        }

        public async Task<int> Delete(int id)
        {
            
             
               var ExistId = _context.speakersDetails.FirstOrDefault(spe => spe.SpeakerId.Equals(id));
                if (ExistId is not null)
                {
                _context.speakersDetails.Remove(ExistId);//method change the state of an entity from unchanged to Remove
                    return await _context.SaveChangesAsync();

                }
                else
                {
                    return 0;
                }
            
           
        }
       

        public async Task<int> Update(SpeakersDetails entity)
        {
           
                var Existdetails = _context.speakersDetails.FirstOrDefault(eve => eve.SpeakerId.Equals(entity.SpeakerId));
                if (Existdetails is not null)
                {
                    //It will change entity state from unchange to modify
                    Existdetails.SpeakerName = entity.SpeakerName;
                    return await _context.SaveChangesAsync();
                }
                else
                {
                    return 0;
                }
            
        }
        public async Task<List<SpeakersDetails>> GetAll()
        {


            return await _context.speakersDetails.ToListAsync();


        }
    }
}
