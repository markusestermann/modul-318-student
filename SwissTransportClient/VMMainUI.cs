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
        DateTime datumzeit;
        bool isFromFocused = false;
        bool isFromDroppedDown = false;
        bool isFromDropFocused = false;
        bool isSelectionVisible = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public VMMainUI()
        {
            dataService = new Transport();

            searchtextFrom = "";
            datumzeit = DateTime.Now;
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
            try
            {
                var stations = await dataService.GetStations(searchtextFrom);
                this.StationsFrom = stations.StationList;
            }
            catch
            { }
        }

        private async void UpdateStationsTo(string searchtext)
        {
            try
            {
                var stations = await dataService.GetStations(searchtextTo);
                this.StationsTo = stations.StationList;
            }
            catch
            { }
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
                    PropertyChanged(this, new PropertyChangedEventArgs("CoordinatesFrom"));
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

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedFrom"));
                }
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

        public DateTime DatumZeit
        {
            get
            {
                return datumzeit;
            }
            set
            {
                datumzeit = value;

                this.FindConnections();
            }
        }

        private void FindConnections()
        {
            if(this.SelectedFrom != null
                && this.SelectedTo != null)
            {
                var connections = dataService.GetConnections(this.SelectedFrom.Name, this.SelectedTo.Name, this.DatumZeit);

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

        public bool IsFromFocused
        {
            get
            {
                return isFromFocused;
            }
            set
            {
                isFromFocused = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsFromFocused"));
                }

                this.IsFromDroppedDown = this.IsFromFocused || this.IsFromDropFocused;
                this.IsSelectionVisible = this.IsFromFocused == false;
            }
        }

        public bool IsFromDroppedDown
        {
            get
            {
                return isFromDroppedDown;
            }
            set
            {
                isFromDroppedDown = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsFromDroppedDown"));
                }
            }
        }

        public bool IsFromDropFocused
        {
            get
            {
                return isFromDropFocused;
            }
            set
            {
                isFromDropFocused = value;

                this.IsFromDroppedDown = this.IsFromFocused || this.IsFromDropFocused;
            }
        }

        public bool IsSelectionVisible
        {
            get
            {
                return isSelectionVisible;
            }
            set
            {
                isSelectionVisible = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsSelectionVisible"));
                }

                this.IsTextFromVisible = !this.IsSelectionVisible;
            }
        }

        public bool IsTextFromVisible
        {
            get
            {
                return this.IsSelectionVisible == false; ;
            }
            set
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsTextFromVisible"));
                }
            }
        }
    }
}
