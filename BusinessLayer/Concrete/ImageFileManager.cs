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
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _ımageFileDal;

        public ImageFileManager(IImageFileDal ımageFileDal)
        {
            _ımageFileDal = ımageFileDal;
        }

        public List<ImageFile> GetAll()
        {
            return _ımageFileDal.List();
        }
    }
}
