using Business.Abstract;
using Business.Constants;
using Core.Utilities.FileOperations;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        IWebHostEnvironment _webHostEnvironment;
        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult AddAsync([FromForm] IFormFile image, [FromForm] string carImageString)
        {
            if (image == null)
            {
                return BadRequest("File not found");
            }
            CarImage carImage = JsonConvert.DeserializeObject<CarImage>(carImageString);

            string path = _webHostEnvironment.WebRootPath + @"\images\";
            string newFileNameWithGUID = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);

            bool fileCreate = ImageOperations.CopyFileToServer(image, path, newFileNameWithGUID);
            if (!fileCreate) return BadRequest(Messages.FileCreateError);

            carImage.ImagePath = path + newFileNameWithGUID;
            var result = _carImageService.Add(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            bool isDeleted = ImageOperations.DeleteFileFromServer(carImage.ImagePath);
            if (!isDeleted)
            {
                return BadRequest(Messages.FileDeleteError);
            }
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile image, [FromForm] string carImageString)
        {
            CarImage carImage = JsonConvert.DeserializeObject<CarImage>(carImageString);

            if (image == null)
            {
                var result = _carImageService.Update(carImage);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            else
            {
                string path = _webHostEnvironment.WebRootPath + @"\images\";
                string newFileNameWithGUID = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                if (!ImageOperations.DeleteFileFromServer(carImage.ImagePath)) return BadRequest(Messages.FileDeleteError);
                if(!ImageOperations.CopyFileToServer(image, path, newFileNameWithGUID)) return BadRequest(Messages.FileCreateError);
                carImage.ImagePath = path + newFileNameWithGUID;
                var result = _carImageService.Update(carImage);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
        }
    }
}
