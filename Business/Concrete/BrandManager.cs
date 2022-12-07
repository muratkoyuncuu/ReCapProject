using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;


        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public IResult Add(Brands brands)
        {
            if (brands.BrandName.Length <= 1)
            {
                return new ErrorResult(Messages.BrandNameInvalid);
            }
            _brandDal.Add(brands);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brands brands)
        {
          _brandDal.Delete(brands);
            return new SuccessResult();
        }

        public IDataResult<List<Brands>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Brands>>(Messages.MaintenanceTime);

            }
            return new SuccessDataResult<List<Brands>>(_brandDal.GetAll(), Messages.BrandListed);
        }

        public IDataResult<Brands> GetById(int Id)
        {
            return new SuccessDataResult<Brands>(_brandDal.Get(b => b.Id == Id));
        }

        public IResult Update(Brands brands)
        {
            _brandDal.Update(brands);
            return new SuccessResult();
        }
    }
}
