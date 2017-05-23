using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwissTransportClient;

namespace SwissTransport
{
    [TestClass]
    public class VMMainTest
    {
        [TestMethod]
        public void FindFromStationsLuzern()
        {
            //Arrange
            VMMainUI vmMain = new VMMainUI();

            //Act
            vmMain.SearchTextFrom = "luzern";

            //Assert
            Assert.IsNotNull(vmMain.StationsFrom);
            Assert.IsTrue(vmMain.StationsFrom.Count > 0);
        }
    }
}
