﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetListInbox(string email)
        {
            return _messageDal.List(x => x.ReceiverMail == email);
        }
        public List<Message> GetListSendbox(string email)
        {
            return _messageDal.List(x => x.SenderMail == email);
        }

        public List<Message> MessageNoRead(string email)
        {
            return _messageDal.List(x => x.ReceiverMail == email).Where(y => y.MessageRead == false).ToList();
        }


        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.MessageId == id);
        }

        public List<Message> GetListByMessageId(int id)
        {
            throw new NotImplementedException();
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Add(message);
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message message)
        {
            message.MessageRead = true;
            _messageDal.Update(message);
        }

        public List<Message> GetList(string mail)
        {
            return _messageDal.List(x => x.ReceiverMail == mail);
        }
    }
}
