using Microsoft.AspNetCore.Authorization;

namespace ApiAppPetrol.Policies
{
    class PoliciesCustom
    {
        public const string Station = "Station";
        public const string Engineer = "Engineer";

        public const string SecurityAgent = "Security";
        public const string BusAssent = "BusAssent";
        public const string TruckAssent = "TruckAssent";


        public static AuthorizationPolicy StationPolicy(){

            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Station).Build();

        }

        public static AuthorizationPolicy EnginnerPolicy(){
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Engineer).Build();

        }

         public static AuthorizationPolicy SecurityAgentPolicy(){
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(SecurityAgent).Build();

        }

        public static AuthorizationPolicy BusAssentPolicy(){
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(BusAssent).Build();

        }

         public static AuthorizationPolicy TruckAssentPolicy(){
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(TruckAssent).Build();

        }

    }


}