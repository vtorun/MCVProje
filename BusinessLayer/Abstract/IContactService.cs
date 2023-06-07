using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetListContact();
        void ContactAdd(Contact contact);
        Contact GetById(int id);
        void ContactRemove(Contact contact);
        void ContactUpdate(Contact contact);
    }
}
