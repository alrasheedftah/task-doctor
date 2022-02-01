using System;
using System.Collections.Generic;

namespace ApiAppPetrol.Domain.SMSContent
{
  
        public class  SmsContent{

        public string Title {get ; set ;}
        
        public string Order {get ; set ;}
        public string CustmorName {get ; set ;}

        public string Agreedate {get ; set ;}

        public string Note {get ; set ;}
        public string ReasonReject {get ; set ;}


        public string getAsString(){
          var   sms="تم"+Title+" علي استحقاق "+"%0a"+Order+"%0a"+" باسم "+CustmorName+"%0a"+" بتاريخ " + Agreedate +"%0a"+" الملاحظة  :  "+Note??Agreedate+"%0a";
            return  sms;
        }

     
    }


}