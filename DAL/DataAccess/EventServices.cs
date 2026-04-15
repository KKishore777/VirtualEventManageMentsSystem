using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public class EventServices : IEventRepository<EventDetails>
    {
        private readonly Context _context;
        public EventServices(Context context)
        {
            _context = context;
        }
        public void met()
        {
            var data = _context.userInfos.ToList();
        }
        public async Task<int> Add(EventDetails entity)
        {
            _context.eventDetails.Add(entity);
                //DbContext.eventDetails.Add(entity);//Add() method change the state of an entity from unchanged to added
                return await _context.SaveChangesAsync();//this method observes current entity state(Added) and build the t-sql statement(insert into values)
                 
        }

        public async Task<int> Delete(int id)
        {
           
              var ExistId =  _context.eventDetails.FirstOrDefault(eve=> eve.EventId.Equals(id));
                if (ExistId is not null)
                {
                _context.eventDetails.Remove(ExistId);//method change the state of an entity from unchanged to Remove
                    return await _context.SaveChangesAsync();

                }
                else
                {
                    return 0;
                }
            

        }

        public async Task<List<EventDetails>> GetAll()
        {

            
                return await _context.eventDetails.ToListAsync();


            }
        

        public async Task<EventDetails> GetById(int id)
        {
            
                return await _context.eventDetails.FirstOrDefaultAsync (eve => eve.EventId.Equals(id));
                

            
        }

        public async Task<int> Update(EventDetails entity)
        {
          
                var Existdetails = _context.eventDetails.FirstOrDefault(eve => eve.EventId.Equals(entity.EventId));
                if (Existdetails is not null)
                {
                    //It will change entity state from unchange to modify
                    Existdetails.EventName = entity.EventName;
                    Existdetails.EventCategory = entity.EventCategory;
                    Existdetails.EventDate = entity.EventDate;
                    Existdetails.Status = entity.Status;
                    return await _context.SaveChangesAsync();
                }
                else
                {
                    return 0;
                }
            
        }
    }
}
