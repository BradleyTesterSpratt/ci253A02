using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatesMotel;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class FatesMotelTests
    {
        [TestMethod]
        public void CheckLowRoomNumber()
        {
            //arrange
            double vRoomsNo = 1;
            int vFloorsNo = 1;
            Motel expected = null;

            //act
            Motel vTestMotel = new Motel(vRoomsNo, vFloorsNo);

            //assert
            Assert.AreEqual(expected, vTestMotel, "Unable to make Motel");
        }

        [TestMethod]
        public void GoToInvalidRoom()
        {
            //arrange
            Motel vTestMotel = new Motel(16, 1);
            Game vTestGame = new Game(vTestMotel, GameSpeed.AVERAGE);
            Location expected = vTestMotel.GetRooms().ElementAt(0);
            Room vFailRoom = new Room(1000);

            //act
            vTestGame.MoveEngine(vFailRoom);

            //assert
            Assert.AreEqual(expected, vFailRoom, "move unsuccesful");
        }

        [TestMethod]
        public void EngineRefillOutOfStation()
        {
            //arrange
            Motel vTestMotel = new Motel(16, 1);
            Game vTestGame = new Game(vTestMotel, GameSpeed.AVERAGE);
            bool expected = false;

            //act
            vTestGame.MoveEngine(vTestMotel.GetRooms().ElementAt(1));
            vTestGame.EngineRefill();

            //assert
            Assert.AreEqual(expected, vTestGame.TestEngine().CoolantTest(), "cant refill");
        }
    }
}
