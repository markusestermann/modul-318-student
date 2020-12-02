using System.Collections.Generic;
using Newtonsoft.Json;

namespace SwissTransport
{
    public class Connections
    {
        [JsonProperty("connections")]
        public List<Connection> ConnectionList { get; set; } 
    }

    public class Connection
    {
        [JsonProperty("from")]
        public ConnectionPoint From  { get; set; }

        [JsonProperty("to")]
        public ConnectionPoint To { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("products")]
        public string[] Products { get; set; }

        public List<Section> sections { get; set; }
    }

    public class ConnectionPoint
    {
        [JsonProperty("station")]
        public Station Station { get; set; }

        public string Arrival { get; set; }

        public string ArrivalTimestamp { get; set; }

        public System.DateTime? Departure { get; set; }

        public string DepartureTimestamp { get; set; }

        public int? Delay { get; set; }

        public string Platform { get; set; }

        public string RealtimeAvailability { get; set; }
    }

    public class Section
    {
        public Journey journey { get; set; }
        public object walk { get; set; }
        //public Departure departure { get; set; }
        //public Arrival arrival { get; set; }
    }

    public class Journey
    {
        public string name { get; set; }
        public string category { get; set; }
        public object subcategory { get; set; }
        public object categoryCode { get; set; }
        public string number { get; set; }
        public string @operator { get; set; }
        public string to { get; set; }
        //public List<PassList> passList { get; set; }
        public object capacity1st { get; set; }
        public object capacity2nd { get; set; }
    }
}