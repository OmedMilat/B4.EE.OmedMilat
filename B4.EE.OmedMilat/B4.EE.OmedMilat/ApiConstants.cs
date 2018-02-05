using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B4.EE.OmedMilat
{
    public static class ApiConstants
    {
        //Api Key Verloopt op 7/03/2018
        public static readonly string BingVisionApi = "211fbedcc8804b92971474b15c7d297f";
        public static readonly string BingVisionEndpointUrl = "https://westcentralus.api.cognitive.microsoft.com/vision/v1.0/analyze?visualFeatures=Categories,Description,Faces&language=en";

        //Api Key Verloopt op 6/03/2018
        public static readonly string BingSpeechApiKey = "632a4d8d1e9a469490a968ef4a5d9e43";


        public static readonly string OpenWeatherMapApi = "200510b1716274cf3afd3f5b71b0b73b";
    }
}
