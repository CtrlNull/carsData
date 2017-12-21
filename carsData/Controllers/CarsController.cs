using carsData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace carsData.Controllers
{
    [RoutePrefix("api/cars")]
    public class CarsController : ApiController
    {
        // {{ Get All }}
        [HttpGet, Route("getall")]
        public List<Car> GetAllCars()
        {
            CarsService carService = new CarsService();
            return carService.GetAllCars();
        }
        // {{Get by Id }}
        [HttpGet, Route("getbyid")]
        public List<Car> GetByIdCars(int Id)
        {
            CarsService carsService = new CarsService();
            return carsService.GetByIdCars();
        }
        // {{ Create }}
        [HttpPost, Route("create")]
        public List<CarCreate> CarCreate()
        {
            CarsService carsService = new CarsService();
            return carsService.CarCreate();

        }
        // {{ Update }}
        [HttpPost, Route("update")]
        public List<CarUpdate> CarUpdate(int Id)
        {
            CarsService carsService = new CarsService();
            return carsService.CarUpdate(Id);
        }

        // {{ Delete }}
        [HttpDelete, Route("delete")]
        public List<CarDelete> CarDelete(int Id)
        {
            CarsService carsService = new CarsService();
            return carsService.CarDelete();
        }
    }
}
