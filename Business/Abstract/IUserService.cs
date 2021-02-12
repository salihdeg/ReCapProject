using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService : IEntityServiceBase<User>
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}
