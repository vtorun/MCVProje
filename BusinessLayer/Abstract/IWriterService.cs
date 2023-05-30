using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetListWriter();
        void WriterAdd(Writer writer);
        Writer GetById(int id);
        void WriterRemove(Writer writer);
        void WriterUpdate(Writer writer);
    }
}
