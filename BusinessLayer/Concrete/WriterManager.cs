using BusinessLayer.Abstract;
using BusinessLayer.Hashing;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Entity.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetById(int id)
        {
            return _writerDal.Get(x => x.WriterId == id); ;
        }

        public Writer GetByWriter(string userName, string password)
        {
            //string kullaniciAdi =Cryptology.Encryption(userName);
            //string sifre = Cryptology.Encryption(password);
            //return _writerDal.Get(x => x.WriterMail == kullaniciAdi && x.WriterPassword == sifre);
            return _writerDal.Get(x => x.WriterMail == userName && x.WriterPassword == password);
        }

        public List<Writer> GetListWriter()
        {
            return _writerDal.List();
        }

        public void WriterAdd(Writer writer)
        {
            //writer.WriterMail = Cryptology.Encryption(writer.WriterMail);
            //writer.WriterPassword = Cryptology.Encryption(writer.WriterPassword);
            _writerDal.Add(writer);
        }

        public void WriterRemove(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
