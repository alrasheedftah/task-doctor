public static class ApiRoutes {
public  const string baseUrl="api";
    public static class FuelTypeRoute{
    public  const string getFuelType = baseUrl+"/fueltype";
    }
    public static class DoctorRoute{
    public  const string doctors = baseUrl+"/doctors";
    public  const string findDoctors = baseUrl+"/doctors/{doctorID}";
    public  const string doctorScheduals = baseUrl+"/doctors/{doctorID}/scheduals";

    }
}
