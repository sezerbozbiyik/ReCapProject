﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandal;

        public BrandManager(IBrandDal brandal)
        {
            _brandal = brandal;
        }

        public IResult Delete(Brand brand)
        {
            _brandal.Delete(brand);
            return new SuccessResult(brand.BrandName + Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            //sadece data ile çalıştırma
            return new SuccessDataResult<List<Brand>>(_brandal.GetAll(),"Markalar listelendi.");
        }

        public IDataResult<Brand> GetByBrandId(int id)
        {
            return new SuccessDataResult<Brand>(_brandal.Get(b=>b.Id==id));
        }

        public IResult Add(Brand brand)
        {
            _brandal.Add(brand);
            return new SuccessResult(brand.BrandName + Messages.BrandAdded);
        }

        public IResult Update(Brand brand)
        {
            _brandal.Update(brand);
            return new SuccessResult(brand.BrandName + Messages.BrandUpdated);
        }
    }
}
