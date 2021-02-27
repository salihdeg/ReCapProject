using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckMaxCarImageOfCar(carImage.CarId),
                ChangeDateToNow(carImage));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckMaxCarImageOfCar(carImage.CarId),
                ChangeDateToNow(carImage));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var result = _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            var result = _carImageDal.Get(cI => cI.CarId == id);
            return new SuccessDataResult<CarImage>(result);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckMaxCarImageOfCar(carImage.CarId),
                ChangeDateToNow(carImage));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckMaxCarImageOfCar(int carId)
        {
            var imageCount = _carImageDal.GetAll(carImage=> carImage.CarId == carId).Count;
            if (imageCount>=5)
            {
                return new ErrorResult(Messages.MaxImageOfCarExceeded);
            }
            return new SuccessResult();
        }

        private IResult ChangeDateToNow(CarImage carImage)
        {
            carImage.ImageDate = DateTime.Now;
            return new SuccessResult();
        }
        private IResult ChangeImageNameAndCopy(CarImage carImage)
        {
            var newName = ImageInfo.DefaultImageFolder + Guid.NewGuid().ToString();
            File.Copy(carImage.ImagePath,newName);
            carImage.ImagePath = newName;
            return new SuccessResult();
        }
    }
}
