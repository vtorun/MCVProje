﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetListHeading();
        List<Heading> GetListHeadingByWriter(int id);
        void HeadingAdd(Heading heading);
        Heading GetById(int id);
        void HeadingRemove(Heading heading);
        void HeadingUpdate(Heading heading);
    }
}
