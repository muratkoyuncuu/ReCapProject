using Business.Concrete;
using Business.Conrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
     class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            Brands();
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetail();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Araba Bilgisi: " + car.BrandName + " Açıklaması : " + car.CarDesription);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void Brands()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            if (result.Success == true)
            {
                foreach (var brands in result.Data)
                {
                    Console.WriteLine(brands.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }



            
        }
    }
}
