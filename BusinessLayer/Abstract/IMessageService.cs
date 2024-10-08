﻿using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string email);
        List<Message> GetListSendbox(string email);
        List<Message> GetListByMessageId(int id);
        List<Message> GetList(string mail);
        void MessageAdd(Message message);
        Message GetById(int id);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
        List<Message> MessageNoRead(string email);
    }
}
