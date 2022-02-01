using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ApiAppPetrol.Domain.Response;
using ApiAppPetrol.Domain.Requsts;
using ApiAppPetrol.Exceptions;
using ApiAppPetrol.Extention;
using ApiAppPetrol.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiAppPetrol.Controllers
{
    [ApiController]
    public class DoctorSchedualsController : ControllerBase
    {
              private IDoctorServices _doctorServices;
        public DoctorSchedualsController(IDoctorServices doctorServices){
            _doctorServices = doctorServices;
        }

     [HttpGet(ApiRoutes.DoctorRoute.doctorScheduals)]
        public async Task<IActionResult> index([FromRoute] long doctorID){
            var scheduals=await  _doctorServices.GetDoctorSchedals(doctorID);
            if(scheduals.DoctorSchedual == null)
                throw new HttpResponseException(){ Status = 404 ,Value = new ErrorsResponse{
            Errors = new[] { "No Data In FuelType Table " },
            Success = false
            }};
        
            return Ok(scheduals.DoctorSchedual);

        }


        [HttpPost(ApiRoutes.DoctorRoute.doctorScheduals)]
        public async Task<IActionResult> store([FromBody] AddDoctorSchedualsRequest doctorSchedals,[FromRoute] long doctorID){
            if (!ModelState.IsValid)
                throw new HttpResponseException()
                {
                    Status = 419,
                    Value = new ErrorsResponse
                    {
                        Errors = new[] { "The Specific QRCode Not Found " },
                        Success = false
                    }
                };
            Console.WriteLine(" "+doctorSchedals.SessionTime+"  : "+doctorSchedals.SessionTime+"  : "+doctorSchedals.endDate+"  : "+doctorSchedals.strDate+"  : "+doctorSchedals.TimeBetween+"  : "+doctorSchedals.WaitingTime);
            var fuelType=await  _doctorServices.CreateDoctorScheduals(doctorID,doctorSchedals);
            if(fuelType == null)
                throw new HttpResponseException(){ Status = 401 ,Value = new ErrorsResponse{
            Errors = new[] { "No Data In FuelType Table " },
            Success = false
        }};
        
            // return Ok("ana");
            return Ok(fuelType);

        }

    //     [HttpPut(ApiRoutes.DoctorRoute.doctorScheduals)]
    //     public async Task<IActionResult> update([FromRoute] string doctorID){
    //         var fuelType=await  _doctorServices.GetFuelTypes();
    //         if(fuelType == null)
    //             throw new HttpResponseException(){ Status = 401 ,Value = new ErrorsResponse{
    //         Errors = new[] { "No Data In FuelType Table " },
    //         Success = false
    //     }};
        
    //             return Ok(fuelType);

    //     }

    //  [HttpDelete(ApiRoutes.DoctorRoute.doctorScheduals)]
    //     public async Task<IActionResult> delete([FromRoute] string doctorID){
    //         var fuelType=await  _doctorServices.GetFuelTypes();
    //         if(fuelType == null)
    //             throw new HttpResponseException(){ Status = 401 ,Value = new ErrorsResponse{
    //         Errors = new[] { "No Data In FuelType Table " },
    //         Success = false
    //     }};
        
    //             return Ok(fuelType);

    //     }        


    }
}