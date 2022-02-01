using System.Collections.Generic;

namespace ApiAppPetrol.Domain.Response

{

    public class MyAutheResult{
        public string Token {get ; set ;}
        public bool Success {get ; set ;}
        // public string ErrorMessage {get ; set ;}
        public IEnumerable<string> Errors{ get ; set ;}
        
    }


}