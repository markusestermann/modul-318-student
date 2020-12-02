using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace SwissTransport
{
    [TestClass]
    public class TransportTest
    {
        private ITransport testee;

        [TestMethod]
        public void Sursee10Stations()
        {
            //Arrange
            testee = new Transport();
            var stations = new Stations();

            //Act
            Task.Run(() => stations = testee.GetStations("Sursee,").Result).Wait();
            
            //Assert
            Assert.AreEqual(10, stations.StationList.Count);
        }

        [TestMethod]
        public void StationBoard()
        {
            //Arrange
            testee = new Transport();

            //Act
            var stationBoard = testee.GetStationBoard("Sursee", "8502007");

            //Assert
            Assert.IsNotNull(stationBoard);
        }


        [TestMethod]
        public void StationBoardNoStation()
        {
            //Arrange
            testee = new Transport();

            //Act
            var stationBoard = testee.GetStationBoard("Hildisrieden, Sempacherstrasse 1", "");

            //Assert
            Assert.IsNotNull(stationBoard);
        }

        [TestMethod]
        public void Connections()
        {
            testee = new Transport();
            var connections = testee.GetConnections("Sursee", "Luzern");

            Assert.IsNotNull(connections);
        }

        [TestMethod]
        public void ConnectionsHildLuzWithLinesDeparture()
        {
            //Arrange
            testee = new Transport();
            
            //Act
            var connections = testee.GetConnections("Hildisrieden", "Luzern", new System.DateTime(2020, 12, 1, 11, 25, 0));
            
            //Assert
            Assert.IsNotNull(connections);
            Assert.IsNotNull(connections.ConnectionList);
            Assert.IsTrue(connections.ConnectionList.Count == 4);
            Assert.IsTrue(connections.ConnectionList[1].Products.Length == 2);
        }
    }
}
