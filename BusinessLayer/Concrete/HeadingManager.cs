using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public Heading GetById(int id)
        {
            return _headingDal.Get(x => x.HeadingId == id);
        }

        public List<Heading> GetListHeading()
        {
            return _headingDal.List();
        }

        public List<Heading> GetListHeadingByWriter()
        {
            return _headingDal.List(x => x.WriterId == 2);
        }

        public void HeadingAdd(Heading heading)
        {
            _headingDal.Add(heading);
        }

        public void HeadingRemove(Heading heading)
        {
            if (heading.HeadingStatus == true)
            {
                heading.HeadingStatus = false;
            }
            else
            {
                heading.HeadingStatus = true;
            }
            _headingDal.Update(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}
