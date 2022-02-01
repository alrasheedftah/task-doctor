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
    // [Authorize(AuthenticationSchemes = "Bearer")]  
    [ApiController]
    public class DoctorController : ControllerBase
    {
       private IDoctorServices _doctorServices;
        public DoctorController(IDoctorServices doctorServices){
            _doctorServices = doctorServices;

        }

     [HttpGet(ApiRoutes.DoctorRoute.doctors)]
        public async Task<IActionResult> index(){
            var doctor=await  _doctorServices.GetAllDoctors();
            if(doctor == null)
                throw new HttpResponseException(){ Status = 401 ,Value = new ErrorsResponse{
            Errors = new[] { "No Data In FuelType Table " },
            Success = false
        }};
        
            return Ok(doctor);

        }


        [HttpPost(ApiRoutes.DoctorRoute.doctors)]
        public async Task<IActionResult> store([FromBody] AddDoctorReest doctor){
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
            var doctorInsert=await  _doctorServices.AddDoctors(doctor);
            if(doctorInsert != true)
                throw new HttpResponseException(){ Status = 401 ,Value = new ErrorsResponse{
            Errors = new[] { "No Data In FuelType Table " },
            Success = false
        }};
        
            return Ok(doctorInsert);

        }

     [HttpGet(ApiRoutes.DoctorRoute.findDoctors)]
        public async Task<IActionResult> show([FromRoute] long doctorID){
            var doctor=await  _doctorServices.FIndDoctorById(doctorID);
            if(doctor == null)
                throw new HttpResponseException(){ Status = 401 ,Value = new ErrorsResponse{
            Errors = new[] { "No Data In FuelType Table " },
            Success = false
        }};
        
                return Ok(doctor);

        }

    }
}