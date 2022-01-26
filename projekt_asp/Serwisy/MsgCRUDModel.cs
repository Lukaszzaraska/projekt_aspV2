using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt_asp.Models
{
    public class MsgCRUDModel : IMsgCRUDModel
    {
        private ApplicationDbContext _context;
        public MsgCRUDModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<MsgModel> FindAllUser()
        {

            return _context.User_Msg.ToList();
        }

        public IList<MsgModel> FindMsg(string login)
        {
            return _context.User_Msg.Where(x => x.Login_for.Equals(login)).ToList();
        }

        public int NewMsg(string login)
        {
            List<MsgModel> data = _context.User_Msg.Where(x => x.Login_for.Equals(login)).ToList();
            
            int new_msg = 0;
            foreach (MsgModel x in data)
            {
                if (x.Msg_readed==false)
                {
                    new_msg++;
                }
            }
            return new_msg;
        }

        public void SendMsg(MsgModel Msgs,RegisterModel login)
        {

            MsgModel users = new()
            {
               Login_from = Msgs.Login_from,
               Login_for = Msgs.Login_for,
               Msg = Msgs.Msg,
               Msg_readed = false,
               Date_send = DateTime.UtcNow, //tu wrazie czego dodac .date
               registerModel = login
            };
            _context.User_Msg.Add(users);
            _context.SaveChanges();
         
        }
        public MsgModel Readed(int id)
        {
          
            MsgModel orginal = _context.User_Msg.Find(id);
            orginal.Msg_readed = true;
            EntityEntry<MsgModel> entityEntry = _context.User_Msg.Update(orginal);
            _context.SaveChanges();
            return entityEntry.Entity;
          
        }

        public MsgModel FindMsgById(int id)
        {
            return _context.User_Msg.Where(x => x.MsgId.Equals(id)).First();
        }

        public MsgModel Delete(int id)
        {
            MsgModel useroff = _context.User_Msg.Remove(FindMsgById(id)).Entity;
            _context.SaveChanges();
            return useroff;
        }
    }
}
