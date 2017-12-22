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
        [Route("getall"), HttpGet]
        public List<Car> GetAllCars()
        {
            CarsService carService = new CarsService();
            return carService.GetAllCars();
        }
        // {{ Create }}
        [Route, HttpPost]
        public HttpResponseMessage CarCreate(CarCreate request)
        {
            CarsService carsService = new CarsService();
            if (request == null)
                ModelState.AddModelError("", "missing model");

            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            var id = carsService.CarCreate(request);
            return Request.CreateResponse(HttpStatusCode.Created, id);
        }
        // {{ Update }}
        [Route("{Id:int}"), HttpPut]
        public HttpResponseMessage CarUpdate(int Id, CarUpdate updateRequest)
        {
            CarsService carsService = new CarsService();
            if (updateRequest == null)
                ModelState.AddModelError("", "missing model");
            else if (Id != updateRequest.Id)
                ModelState.AddModelError("Id", "id does not match URL");

            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            carsService.CarUpdate(updateRequest);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // {{ Delete }}
        [Route("{Id:int}"), HttpDelete]
        public HttpResponseMessage CarDelete(int Id)
        {
            CarsService carsService = new CarsService();
            carsService.CarDelete(Id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        //// {{Get by Id }}
        //[HttpGet, Route("GetByIdCars")]
        //public List<Car> GetByIdCars(int Id)
        //{
        //    var car = new CarsService.GetByIdCars(Id);
        //    return carsService.GetByIdCars();
        //}

    }
}
