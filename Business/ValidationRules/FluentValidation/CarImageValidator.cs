﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(carImage => carImage.CarId).NotEmpty();
            RuleFor(carImage => carImage.ImagePath).NotEmpty();
        }
    }
}
