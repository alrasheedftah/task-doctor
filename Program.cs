
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ApiAppPetrol.Models;

namespace ApiAppPetrol
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //  TimeSpan ts = TimeSpan.Parse("6:30");
            //        var strDate=DateTime.Parse("02-05-2021") + ts;
            //  Console.WriteLine("{0} --> {1}", strDate, ts.ToString("c"));
  
            // maker();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


    public static void maker(){
        int SessionTime=30;
        int WaitingTime=15;
        int TimeBetween = 60;
        var strDate=DateTime.Parse("05-02-2021");
        var endDate=DateTime.Parse("06-02-2021");

        var firstPeriodBegin="8:30";
        var firstPeriodEnd="14:00";
        var lastPeriodBegin="12:00";
 
        List<DoctorSchedual> sch=new List<DoctorSchedual>();

        int deffDays=  (endDate - strDate).Days ;
        int day=0;
        while(day < deffDays ){
            int flagFirstSession=0;
            var lastSesstionSchedualTime = strDate.AddDays(day) +  TimeSpan.Parse(firstPeriodEnd+"");

            var FirstSesstionSchedualTime=strDate.AddDays(day) +  TimeSpan.Parse(firstPeriodBegin+"");
            Console.WriteLine(" "+FirstSesstionSchedualTime +"   "+lastSesstionSchedualTime + "  : "+deffDays);

            while(FirstSesstionSchedualTime <= lastSesstionSchedualTime)    {

                sch.Add(new DoctorSchedual{
                    Id = 1,
                    WaitingTime  = WaitingTime,
                    SessionTime = SessionTime ,
                    SessionDateTime = FirstSesstionSchedualTime ,
                    PeriodType = "true",
                    DoctorId = 1,
                });
            Console.WriteLine(" "+FirstSesstionSchedualTime +"   "+lastSesstionSchedualTime);
                FirstSesstionSchedualTime= FirstSesstionSchedualTime.AddMinutes(SessionTime);
                 FirstSesstionSchedualTime=FirstSesstionSchedualTime.AddMinutes(WaitingTime);


            }

            day++;
            Console.WriteLine("Next Day : "+day);
        }

        // foreach (var item in sch)
        // {
        //     Console.WriteLine("Next Day : "+day);
            
        // }

    }
    }


}


//"Server=.;Database=PetrolUser.sd;Trusted_Connection=True;MultipleActiveResultSets=true",
//"Server=.;Database=Petrol.sd;Trusted_Connection=True;MultipleActiveResultSets=true"