using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
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

      

        public List<Car> GetAll()
        {
        return _carDal.GetAll();
        }


        public List<Car> GetByDailyPrice(decimal min)
        {
           return _carDal.GetAll(c=>c.DailyPrice > min );
        }

        public List<CarDetailDto> GetCarDetail()
        {
            return _carDal.GetCarDetail();
        }
    }
}
