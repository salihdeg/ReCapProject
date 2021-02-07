using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CheckRules : ICarCheckService
    {
        //This class contains all rules for adding, deleting and updating
        public bool CheckCarRules(Car car)
        {
            if (car.CarDescription.Length >= 2 && car.DailyPrice > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
