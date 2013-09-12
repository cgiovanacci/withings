using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace Withings
{    
    public class WithingsResourceResponseBody
    {
        public DateTime updatetime { get; set; }
        public List<MeasureGroup> measuregrps { get; set; }
    }

    public class WithingsResourceResponse
    {
        public int status { get; set; }
        public WithingsResourceResponseBody body { get; set; }

        public static List<MeasureGroup> DeserializeMeasuresResponse(IRestResponse response)
        {
            WithingsResourceResponse result = WithingsResourceResponse.Deserialize(response);
            if (result.status != 0) return null; // do we want to throw an exception or act differently if the response is null?
            return result.body.measuregrps;
        }

        public static WithingsResourceResponse Deserialize(IRestResponse response)
        {
            var deserializer = new RestSharp.Deserializers.JsonDeserializer();
            WithingsResourceResponse result = deserializer.Deserialize<WithingsResourceResponse>(response);
            return result;
        }
    }
}
