using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Conrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
    

        public CarManager (ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
          
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);

            }
       
        
        return new SuccessDataResult<List<Car>>( _carDal.GetAll(),Messages.CarsListed);
        }
        

        public IDataResult<List<Car>> GetByDailyPrice(decimal min)
        {
           return new SuccessDataResult<List<Car>>( _carDal.GetAll(c=>c.DailyPrice > min ));
        }

        public IDataResult<Car> GetById(int CarId)
        {
           return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == CarId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail()
        { if(DateTime.Now.Hour == 18)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail());
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }
    }
}
