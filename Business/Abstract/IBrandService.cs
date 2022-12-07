using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
      
        IDataResult<Brands> GetById(int Id);
        IResult Add(Brands brands);
        IDataResult<List<Brands>> GetAll();
        IResult Update(Brands brands);
        IResult Delete(Brands brands);
    }
}
