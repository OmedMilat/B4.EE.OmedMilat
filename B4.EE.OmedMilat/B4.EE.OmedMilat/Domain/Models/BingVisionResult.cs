using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B4.EE.OmedMilat.Domain.Models
{//https://app.quicktype.io/#r=json2csharp
    public partial class BingVisionResult
    {
        [JsonProperty("categories")]
        public List<Category> Categories { get; set; }

        [JsonProperty("description")]
        public Description Description { get; set; }

        [JsonProperty("faces")]
        public List<Face> Faces { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }
    }

    public partial class Category
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("detail")]
        public Detail Detail { get; set; }
    }

    public partial class Detail
    {
        [JsonProperty("celebrities")]
        public List<Celebrity> Celebrities { get; set; }

        [JsonProperty("landmarks")]
        public List<Landmark> Landmarks { get; set; }
    }
    public partial class Celebrity
    {
        [JsonProperty("faceRectangle")]
        public FaceRectangle FaceRectangle { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }
    }
    public partial class Landmark
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }
    }
    public partial class Description
    {
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("captions")]
        public List<Caption> Captions { get; set; }
    }

    public partial class Caption
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }
    }
    public partial class Face
    {
        [JsonProperty("age")]
        public long Age { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("faceRectangle")]
        public FaceRectangle FaceRectangle { get; set; }
    }

    public partial class FaceRectangle
    {
        [JsonProperty("top")]
        public long Top { get; set; }

        [JsonProperty("left")]
        public long Left { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }
}
