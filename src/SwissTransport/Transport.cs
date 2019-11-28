using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SwissTransport
{
    public class Transport : ITransport
    {
        private static int m_RequestsRemaining;

        public async Task<Stations> GetStations(string query)
        {
            var request = CreateWebRequest("http://transport.opendata.ch/v1/locations?query=" + query);
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();

            if (responseStream != null)
            {                
                if(response.Headers["X-Rate-Limit-Remaining"] != null)
                {
                    m_RequestsRemaining = int.Parse(response.Headers["X-Rate-Limit-Remaining"]);
                }

                var message = await new StreamReader(responseStream).ReadToEndAsync();
                var stations = JsonConvert.DeserializeObject<Stations>(message);
                return stations;
            }

            return null;
        }

        public StationBoardRoot GetStationBoard(string station, string id)
        {
            var request = CreateWebRequest("http://transport.opendata.ch/v1/stationboard?Station=" + station + "&id=" + id);
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();

            if (responseStream != null)
            {
                var readToEnd = new StreamReader(responseStream).ReadToEnd();
                var stationboard =
                    JsonConvert.DeserializeObject<StationBoardRoot>(readToEnd);
                return stationboard;
            }

            return null;
        }

        public Connections GetConnections(string fromStation, string toStattion, System.DateTime departure = new System.DateTime())
        {
            string query = "from=" + fromStation + "&to=" + toStattion;

            if (departure != new System.DateTime())
            {
                query += "&date=" + departure.ToString("yyyy-MM-dd") + "&time=" + departure.ToString("hh:mm");
            }

            var request = CreateWebRequest("http://transport.opendata.ch/v1/connections?" + query);
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();

            if (responseStream != null)
            {
                var readToEnd = new StreamReader(responseStream).ReadToEnd();
                var connections =
                    JsonConvert.DeserializeObject<Connections>(readToEnd);
                return connections;
            }

            return null;
        }

        private static WebRequest CreateWebRequest(string url)
        {
            var request = WebRequest.Create(url);
            var webProxy = WebRequest.DefaultWebProxy;

            webProxy.Credentials = CredentialCache.DefaultNetworkCredentials;
            request.Proxy = webProxy;
            
            return request;
        }

        public static int RequestsRemaining
        {
            get
            {
                return m_RequestsRemaining;
            }
        }
    }
}
