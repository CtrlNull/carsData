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
        [HttpGet, Route("getById")]
        public Car GetById(int id)
        {
            return CarsService.GetById(id);
        }
        // {{ Create }}

        // {{ Update }}

        // {{ Delete }}

    }
}
