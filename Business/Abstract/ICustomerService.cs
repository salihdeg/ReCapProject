using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService : IEntityServiceBase<Customer>
    {
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
    }
}
