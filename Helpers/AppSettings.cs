using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ApiAppPetrol.Models;
using ApiAppPetrol.Domain.Requsts;

namespace ApiAppPetrol.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
    }



    public class Schedualers
    {

      public const int SessionTime=30;
      public const  int WaitingTime=15;
      public const  int TimeBetween = 60;
      public const string firstPeriodBegin="8:30";
      public const string firstPeriodEnd="14:00";
      public const string lastPeriodEnd="12:00";
    //   public const  var strDate=DateTime.Parse("05-02-2021");
    //   public const  var endDate=DateTime.Parse("06-02-2021");

        public static List<DoctorSchedual> makeSchedualPeriod(AddDoctorSchedualsRequest data,bool PeriodType,long doctorID){
            DateTime endDate = data.endDate;
            DateTime strDate = data.strDate;
 
        List<DoctorSchedual> sch=new List<DoctorSchedual>();

        int deffDays=  (endDate - strDate).Days ;
        int day=0;
        string periodTyeLabel="Morning";
        while(day < deffDays ){
            int flagFirstSession=0;


                // TODO Morrning Period => True    , False Evening

            var lastSesstionSchedualTime = strDate.AddDays(day) +  TimeSpan.Parse(firstPeriodEnd+"" ) ;
            var FirstSesstionSchedualTime=  strDate.AddDays(day) +    TimeSpan.Parse(firstPeriodBegin+"") ;
            if(!PeriodType){
             lastSesstionSchedualTime = strDate.AddDays(day) +    TimeSpan.Parse(lastPeriodEnd +"");
             FirstSesstionSchedualTime=    ( (strDate.AddDays(day) +    TimeSpan.Parse(firstPeriodEnd+"")).AddMinutes(TimeBetween) ) ;
             periodTyeLabel="Evening";

            }
            Console.WriteLine(" "+FirstSesstionSchedualTime +"   "+lastSesstionSchedualTime + "  : "+deffDays);

            while(FirstSesstionSchedualTime <= lastSesstionSchedualTime)    {

                sch.Add(new DoctorSchedual{
                    Id = 1,
                    WaitingTime  = WaitingTime,
                    SessionTime = SessionTime ,
                    SessionDateTime = FirstSesstionSchedualTime ,
                    PeriodType = periodTyeLabel,
                    DoctorId = doctorID,
                });
            Console.WriteLine(" "+FirstSesstionSchedualTime +"   "+lastSesstionSchedualTime);
                FirstSesstionSchedualTime= FirstSesstionSchedualTime.AddMinutes(SessionTime);
                 FirstSesstionSchedualTime=FirstSesstionSchedualTime.AddMinutes(WaitingTime);


            }

            day++;
            Console.WriteLine("Next Day : "+day);
        }

        return sch;
        // foreach (var item in sch)
        // {
        //     Console.WriteLine("Next Day : "+day);
            
        // }

    }
    }
}