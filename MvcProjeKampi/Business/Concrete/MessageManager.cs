using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
        public Message GetById(int id)
        {
            return _messageDal.Get(p=>p.MessageID==id);
        }
        //session eklenecenk 
        public List<Message> GetListInbox(string p)
        {
            return _messageDal.List(x=>x.RecieverMail==p);
                
        }

        public List<Message> GetListSendBox(string p)
        {
            return _messageDal.List(x=>x.SenderMail== p);
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Add(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDal.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }

    }
}
