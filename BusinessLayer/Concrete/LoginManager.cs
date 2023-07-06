using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Entity.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class LoginManager : ILoginService
    {
        IWriterDal _writerDal;
        IAdminDal _adminDal;

        public LoginManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }
        public LoginManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public Admin GetByAdmin(string userName)
        {
            return _adminDal.Get(x => x.AdminUserName == userName);
        }

        public Writer GetByWriter(string userName)
        {
            return _writerDal.Get(x => x.WriterMail == userName);
        }
    }
}
