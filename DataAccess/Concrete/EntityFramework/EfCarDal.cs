using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, MuratCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {
            using(MuratCarContext context = new MuratCarContext())
            {


                var result = from c in context.Cars
                             join b in context.Brand
                             on c.BrandId equals b.Id
                             select new CarDetailDto { CarId = c.CarId, BrandName = b.BrandName, CarDesription = c.Description };
                return result.ToList();
            }
        }
    }
}
