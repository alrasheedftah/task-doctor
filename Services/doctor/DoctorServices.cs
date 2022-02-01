using System.Collections.Generic;
using System.Threading.Tasks;
using ApiAppPetrol.Domain.Response;
using ApiAppPetrol.Domain.Requsts;
using ApiAppPetrol.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAppPetrol.Domain.Response;
using ApiAppPetrol.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using ApiAppPetrol.Helpers;
namespace ApiAppPetrol.Services
{

    public  class DoctorServices : IDoctorServices
    {
        private readonly DoctorDBContext _context;
        public const string FirstPeriodBegins="ana"; 
        public DoctorServices(DoctorDBContext context){
            _context = context;
        }       
        public async Task<List<DoctorResponse>> GetAllDoctors(){

               var doctorsList= await _context.doctors
               .Select( doc => new DoctorResponse{

                  DoctorName = doc.DoctorName ,

                  DoctorId = (int)doc.Id,

                  DoctorStatus = doc.Active,
                  
               })
               .ToListAsync();

               return doctorsList;
        }
        public async Task<DoctorResponse> FIndDoctorById(long Id){
               var doctor= await _context.doctors
               .Select(doc => new DoctorResponse{
                  DoctorName = doc.DoctorName ,

                  DoctorId = (int)doc.Id,

                  DoctorStatus = doc.Active,                   
               })
                .FirstOrDefaultAsync(doc => doc.DoctorId == Id);
            return doctor;

        }
        public Task<DoctorResponse> UpdateDoctors(long id, AddDoctorReest doctorData){
            return null;

        }
        public Task<DoctorResponse> DeleteDoctors(long Id){
            return null;

        }

        public async Task<bool> AddDoctors(AddDoctorReest doctorData){
              var doctor=  _context.doctors.Add(new Doctor{
                    Id = doctorData.DoctorId,
                    DoctorName = doctorData.DoctorName,
                    Active = doctorData.DoctorStatus
                });
                _context.SaveChanges();            
                return true;
        }

        public async Task<List<DoctorSchedual>> CreateDoctorScheduals(long doctorId,AddDoctorSchedualsRequest doctorData){
            //Morning Period
            var sch=Schedualers.makeSchedualPeriod(doctorData,true,doctorId);
            // Evening Period 
            
            sch.AddRange(Schedualers.makeSchedualPeriod(doctorData,false,doctorId));

               await _context.AddRangeAsync(sch);
               await _context.SaveChangesAsync();

            return sch;

        }
        public async Task<Doctor> GetDoctorSchedals(long doctorId){
               var doctor= await _context.doctors
                                .Include(d => d.DoctorSchedual)
                                .FirstOrDefaultAsync(d => d.Id == doctorId);
            
            return doctor;

        }


        public void makeSchedualDoctorTime(int deffTime,long doctorId,DateTime strDate,DateTime endDate){
            int DoctorsestionTime=0;

        }
        // string GetStationById();     
    }
}