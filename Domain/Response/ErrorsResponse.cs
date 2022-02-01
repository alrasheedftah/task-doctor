using System.Collections.Generic;

namespace ApiAppPetrol.Domain.Response

{

    public class ErrorsResponse{
        public bool Success {get ; set ;} = true;

        public int Code {get ; set ;} = 0;

        // public string ErrorMessage {get ; set ;}
        public IEnumerable<string> Errors{ get ; set ;}
        
    }


}