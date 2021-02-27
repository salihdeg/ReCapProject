using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectDBContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             select new CarDetailDto
                             {
                                 BrandName = b.BrandName,
                                 CarDescription = c.CarDescription,
                                 ColorName = cl.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }
        public List<CarImageDetailDto> GetCarImagesById(int carId)
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var result = from c in context.Cars
                             join i in context.CarImages
                             on c.Id equals i.CarId
                             where i.CarId == carId
                             select new CarImageDetailDto
                             {
                                 Id = i.Id,
                                 CarId = c.Id,
                                 CarDescription = c.CarDescription,
                                 ImagePath = i.ImagePath,
                                 ImageDate = i.ImageDate
                             };
                return result.ToList();
            }
        }
    }
}
