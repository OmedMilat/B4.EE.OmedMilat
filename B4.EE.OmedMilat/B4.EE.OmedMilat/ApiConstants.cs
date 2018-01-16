using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B4.EE.OmedMilat
{
    public static class ApiConstants
    {
        //Api Key Verloopt op 5/02/2018
        public static readonly string BingVisionApi = "4cafbf62054940a49bca279f07ca96c9";
        public static readonly string BingVisionEndpointUrl = "https://westcentralus.api.cognitive.microsoft.com/vision/v1.0/analyze?visualFeatures=Categories,Description,Faces&language=en";

        //Api Key Verloopt op 4/02/2018
        public static readonly string BingSpeechApiKey = "c1c38bbe75f14ee3b293cc774997a5e6";


        public static readonly string OpenWeatherMapApi = "200510b1716274cf3afd3f5b71b0b73b";
    }
}
