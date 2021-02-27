using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
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
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        public class FormData
        {
            public string CarImage { get; set; }
            public IFormFile Image { get; set; }
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
        public IActionResult AddAsync([FromForm] FormData formData)
        {
            if (formData.Image == null)
            {
                return BadRequest("File not found");
            }
            CarImage carImage = JsonConvert.DeserializeObject<CarImage>(formData.CarImage);

            var path = ImageInfo.DefaultImageFolder;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var newFileNameWithGUID = Guid.NewGuid().ToString() + Path.GetExtension(formData.Image.FileName);
            try
            {
                using (FileStream fileStream = System.IO.File.Create(path + newFileNameWithGUID))
                {
                    formData.Image.CopyTo(fileStream);
                    fileStream.Flush();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
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
            System.IO.File.Delete(carImage.ImagePath);
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CarImage carImage)
        {
            var result = _carImageService.Update(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
