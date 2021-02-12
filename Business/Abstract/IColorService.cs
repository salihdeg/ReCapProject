﻿using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService : IEntityServiceBase<Color>
    {
        IResult Add(Color color);
        IResult Update(Color color);
        IResult Delete(Color color);
    }
}
