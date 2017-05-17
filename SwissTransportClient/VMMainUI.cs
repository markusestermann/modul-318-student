using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwissTransport;

namespace SwissTransportClient
{
    public class VMMainUI : INotifyPropertyChanged
    {
        Transport dataService = null;
        List<Station> stationsFrom = null;
        string searchtextFrom = null;
        List<Station> stationsTo = null;
        string searchtextTo = null;
        Station selectedFrom = null;
        Station selectedTo = null;
        List<Connection> connections = null;

        public event PropertyChangedEventHandler PropertyChanged;

        public VMMainUI()
        {
            dataService = new Transport();

            searchtextFrom = "";
        }

        public string SearchTextFrom
        {
            get
            {
                return searchtextFrom;
            }
            set
            {
                searchtextFrom = value;

                if (searchtextFrom.Length >= 3)
                {
                    //var stations = dataService.GetStations(searchtextFrom);
                    //this.StationsFrom = stations.Result.StationList;

                    this.UpdateStationsFrom(searchtextFrom);
                }
            }
        }

        private async void UpdateStationsFrom(string searchtext)
        {
            var stations = await dataService.GetStations(searchtextFrom);
            this.StationsFrom = stations.StationList;
        }

        private async void UpdateStationsTo(string searchtext)
        {
            var stations = await dataService.GetStations(searchtextFrom);
            this.StationsTo = stations.StationList;
        }

        public string SearchTextTo
        {
            get
            {
                return searchtextTo;
            }
            set
            {
                searchtextTo = value;

                if (searchtextTo.Length >= 3)
                {
                    //var stations = dataService.GetStations(searchtextTo);
                    //this.StationsTo = stations.Result.StationList;

                    this.UpdateStationsTo(searchtextTo);
                }
            }
        }

        public List<Station> StationsFrom
        {
            get
            {
                return stationsFrom;
            }
            set
            {
                stationsFrom = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("StationsFrom"));
                }
            }
        }

        public List<Station> StationsTo
        {
            get
            {
                return stationsTo;
            }
            set
            {
                stationsTo = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("StationsTo"));
                }
            }
        }

        public Station SelectedFrom
        {
            get
            {
                return selectedFrom;
            }

            set
            {
                selectedFrom = value;

                this.FindConnections();
            }
        }

        public Station SelectedTo
        {
            get
            {
                return selectedTo;
            }

            set
            {
                selectedTo = value;

                this.FindConnections();
            }
        }

        private void FindConnections()
        {
            if(this.SelectedFrom != null
                && this.SelectedTo != null)
            {
                var connections = dataService.GetConnections(this.SelectedFrom.Name, this.SelectedTo.Name);

                this.Connections = connections.ConnectionList;
            }
        }

        public List<Connection> Connections
        {
            get
            {
                return connections;
            }
            set
            {
                connections = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Connections"));
                }
            }
        }
    }
}
