using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectDBContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRetalDetails()
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join customer in context.Customers
                             on r.CustomerId equals customer.Id
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CarDescription = c.CarDescription,
                                 CompanyName = customer.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
