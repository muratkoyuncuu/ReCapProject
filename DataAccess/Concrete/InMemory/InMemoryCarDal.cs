using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=100,Description="BMW 320i",ModelYear=2020},
                new Car{CarId=2,BrandId=1,ColorId=2,DailyPrice=150,Description="BMW 520i",ModelYear=2018},
                new Car{CarId=3,BrandId=2,ColorId=3,DailyPrice=120,Description="Renault Fluence",ModelYear=2014},
                new Car{CarId=4,BrandId=3,ColorId=4,DailyPrice=90,Description="Seat Leon FR",ModelYear=2017},
                new Car{CarId=5,BrandId=4,ColorId=2,DailyPrice=360,Description="BMW M5",ModelYear=2022},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }
        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(c=>c.BrandId== brandId).ToList();
        }

        public List<CarDetailDto> GetCarDetail()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId== car.CarId);
            
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId= car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

        }
    }
}
