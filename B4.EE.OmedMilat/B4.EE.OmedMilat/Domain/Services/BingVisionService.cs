using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.IO;
using Acr.UserDialogs;

namespace B4.EE.OmedMilat.Domain.Services
{
    public class BingVisionService
    {
        public static string ResponseString;
        HttpClient visionApiClient;
        PromptConfig prompt;
        AlertConfig DisplayAlert;

        public BingVisionService()
        {
            visionApiClient = new HttpClient();
            visionApiClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", ApiConstants.BingVisionApi);
        }
        public async Task TakePhoto()
        {
            MediaFile photoMediaFile = null;
            byte[] photoByteArray = null;

            if (CrossMedia.Current.IsCameraAvailable)
            {
                var mediaOptions = new StoreCameraMediaOptions
                {
                    PhotoSize = PhotoSize.Medium,
                    AllowCropping = true,
                    SaveToAlbum = false,
                };
                photoMediaFile = await CrossMedia.Current.TakePhotoAsync(mediaOptions);
                photoByteArray = MediaFileToByteArray(photoMediaFile);
                await GetVisualInfo(photoByteArray);
            }         
            else
            {
                prompt = new PromptConfig
                {
                    Title = "Error",
                    Message = "No camera found, would you like to choose a photo from the gallery?",
                    OkText = "Yes",
                    CancelText = "No"
                };
                var result = await UserDialogs.Instance.PromptAsync(prompt);
                if (result.Ok)
                {
                    await PhotoFromGallery();
                }
            }
        }

        public async Task PhotoFromGallery()
        {
            MediaFile photoMediaFile = null;
            byte[] photoByteArray = null;

            try
            {
                photoMediaFile = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                {
                    PhotoSize = PhotoSize.Medium,
                });
                photoByteArray = MediaFileToByteArray(photoMediaFile);
                await GetVisualInfo(photoByteArray);
            }
            catch
            {
                DisplayAlert = new AlertConfig
                {
                    Title = "Error",
                    Message = "Error choosing photo from gallery",
                    OkText = "Ok"
                };
            }
            
        }

        byte[] MediaFileToByteArray(MediaFile photoMediaFile)
        {
            using (MemoryStream memStream = new MemoryStream())
            {
                photoMediaFile.GetStream().CopyTo(memStream);
                return memStream.ToArray();
            }
        }
        public async Task GetVisualInfo(byte[] photo)
        {
            HttpResponseMessage response = null;
            using (var content = new ByteArrayContent(photo))
            {
                // The media type of the body sent to the API. 
                // "application/octet-stream" defines an image represented 
                // as a byte array
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await visionApiClient.PostAsync(ApiConstants.BingVisionEndpointUrl, content);
                ResponseString = await response.Content.ReadAsStringAsync();

                //De Json result in output laten zien.
                //JObject json = JObject.Parse(ResponseString);
                //Debug.WriteLine(JsonPrettyPrint(ResponseString));
            }
        }
        static string JsonPrettyPrint(string json)
        {
            if (string.IsNullOrEmpty(json))
                return string.Empty;

            json = json.Replace(Environment.NewLine, "").Replace("\t", "");

            StringBuilder sb = new StringBuilder();
            bool quote = false;
            bool ignore = false;
            int offset = 0;
            int indentLength = 3;

            foreach (char ch in json)
            {
                switch (ch)
                {
                    case '"':
                        if (!ignore) quote = !quote;
                        break;
                    case '\'':
                        if (quote) ignore = !ignore;
                        break;
                }

                if (quote)
                    sb.Append(ch);
                else
                {
                    switch (ch)
                    {
                        case '{':
                        case '[':
                            sb.Append(ch);
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', ++offset * indentLength));
                            break;
                        case '}':
                        case ']':
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', --offset * indentLength));
                            sb.Append(ch);
                            break;
                        case ',':
                            sb.Append(ch);
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', offset * indentLength));
                            break;
                        case ':':
                            sb.Append(ch);
                            sb.Append(' ');
                            break;
                        default:
                            if (ch != ' ') sb.Append(ch);
                            break;
                    }
                }
            }

            return sb.ToString().Trim();
        }
    }
}
