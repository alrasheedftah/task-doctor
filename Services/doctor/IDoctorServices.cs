using System.Collections.Generic;
using System.Threading.Tasks;
using ApiAppPetrol.Domain.Response;
using ApiAppPetrol.Domain.Requsts;
using ApiAppPetrol.Models;

namespace ApiAppPetrol.Services
{

    public  interface IDoctorServices
    {
       
        Task<List<DoctorResponse>> GetAllDoctors();
        Task<DoctorResponse> FIndDoctorById(long Id);
        Task<DoctorResponse> UpdateDoctors(long id, AddDoctorReest doctorData);
        Task<DoctorResponse> DeleteDoctors(long Id);
        Task<bool> AddDoctors(AddDoctorReest doctorData);
        Task<List<DoctorSchedual>> CreateDoctorScheduals(long doctorId, AddDoctorSchedualsRequest doctorData);
        Task<Doctor> GetDoctorSchedals(long doctorId);

        // string GetStationById();     
    }
}