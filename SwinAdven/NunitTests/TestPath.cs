using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SwinAdven;

namespace NunitTests
{
    [TestFixture]
    public class TestPath
    {
        Player player;

        Path hallwayPath1;
        Path hallwayPath2;

        [SetUp]
        public void SetUp()
        {
            //default player location is set in hallway
            player = new Player("jack", "fdghslag");

            hallwayPath1 = new Path(new List<string> { "north", "n" }, "North", "go through a door");
            hallwayPath1.Location = new Location(new List<string> { "garden" }, "garden", "green trees and fountain");

            hallwayPath2 = new Path(new List<string> { "south", "s" }, "South", "forcibly open the door to enter");
            hallwayPath2.Location = new Location(new List<string> { "Boiler room" }, "Boiler Room", "dark room");

            foreach (Path p in new List<Path> { hallwayPath1, hallwayPath2 })
            {
                player.Location.AddPath(p);

            }
        }

        [Test]
        public void TestPathMovesPlayerToDestination()
        {
            hallwayPath1.Move(player);

            Assert.AreEqual("garden", player.Location.Name);
        }

        [Test]
        public void GetPathFromLocationWithPathID()
        {
            Path IdToPath = player.Location.FetchPath("south");

            Assert.AreSame(IdToPath, hallwayPath2);
        }

        [Test]
        public void TestPlayerLeavesLocationIfValid()
        {
            List<string> listText = new List<string> { "move", "south" };

            MoveCommand command = new MoveCommand();

            string stringtest = "You head South\n You forcibly open the door to enter\n You have" +
                " arrived in a Boiler Room";

            Assert.AreEqual
            (
             stringtest,
             command.Execute(player, listText)
            );
        }

        [Test]
        public void TestPlayerRemainsInLocationIfInvalid()
        {
            //invalid direction
            List<string> listText = new List<string> { "move", "east" };

            MoveCommand command = new MoveCommand();

            string stringtest = "Cannot find Path";

            Assert.AreEqual
            (
             stringtest,
             command.Execute(player, listText)
            );
        }

    }
}
