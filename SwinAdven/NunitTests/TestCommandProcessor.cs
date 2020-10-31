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
    public class TestCommandProcessor
    {
        Player _player;
        Item _pc;

        Bag _bag;
        Item _gem;

        Path hallwayPath1;

        Path hallwayPath2;
        Item _voilin;

        Item _shovel;
        Item _sword;
        Item _torch;


        CommandProcessor cmdProc;

        [SetUp]
        public void SetUp()
        {
            _player = new Player("player", "mighty programmer");

            //add items in player inventory
            _pc = new Item(new List<string> { "pc" }, "a pc", "a binary machine");
            _player.Inventory.Put(_pc);

            //adding item into bag, owned by the player
            _bag = new Bag(new List<string> { "bag" }, "leather bag", "a portable essential ");
            _gem = new Item(new List<string> { "gem" }, "a red gem", "A bright red ruby the size of your fist!");

            _bag.Inventory.Put(_gem);
            _player.Inventory.Put(_bag);

            //adding paths to players default location (hallway - in constructor)
            hallwayPath1 = new Path(new List<string> { "north", "n" }, "North", "go through a door");
            hallwayPath1.Location = new Location(new List<string> { "garden" }, "garden", "green trees and fountain");

            hallwayPath2 = new Path(new List<string> { "south", "s" }, "South", "forcibly open the door to enter");
            hallwayPath2.Location = new Location(new List<string> { "Boiler room" }, "Boiler Room", "dark room");

            foreach (Path p in new List<Path> { hallwayPath1, hallwayPath2 })
            {
                _player.Location.AddPath(p);

            }

            //adding items in one of locations chosen a path - north
            _voilin = new Item(new List<string> { "voilin" }, "a voilin", "cool string instrument...");
            hallwayPath1.Location.Inventory.Put(_voilin);

            //adding items in player location
            _shovel = new Item(new List<string> { "shovel", "spade" }, "a shovel", "An instrument to dig or kill...");
            _sword = new Item(new List<string> { "sword", "blade" }, "a sword", "a long celtic sword");
            _torch = new Item(new List<string> { "torch" }, "a torch", "Useful utensil to rid of darkness");

            foreach (Item i in new List<Item> { _shovel, _sword, _torch })
            {
                _player.Location.Inventory.Put(i);
            }



            //new command object
            cmdProc = new CommandProcessor();

        }

        [Test]
        public void TestLookCommand()
        {
            List<string> listText = new List<string> { "look", "at", "me" };

            string stringTest = "You are player the mighty programmer \n You are carrying: \n" + _player.Inventory.ItemList;

            Assert.AreEqual
             (
              stringTest,
              cmdProc.ExecuteRelevantCommand(_player, listText)
             );
        }

        [Test]
        public void TestMoveCommand()
        {
            List<string> listText = new List<string> { "move", "south" };

            string stringTest = "You head South\n You forcibly open the door to enter\n You have" +
                " arrived in a Boiler Room";

            Assert.AreEqual
             (
              stringTest,
              cmdProc.ExecuteRelevantCommand(_player, listText)
             );
        }

        [Test]
        public void TestCurrentLocationItems()
        {
            //testing if sword returns desc when remaining in hallway
            List<string> listText = new List<string> { "look", "at", "sword" };

            string stringTest = _sword.FullDescription;

            Assert.AreEqual
            (
             stringTest,
             cmdProc.ExecuteRelevantCommand(_player, listText)
            );
        }

        [Test]
        public void TestNewLocationItems()
        {
            //move north to garden and test if item exists in inventory
            cmdProc.ExecuteRelevantCommand(_player, new List<string> { "move", "north" });

            //look at the item expected to be in garden
            List<string> listText = new List<string> { "look", "at", "voilin" };

            string stringTest = _voilin.FullDescription;

            Assert.AreEqual
            (
             stringTest,
             cmdProc.ExecuteRelevantCommand(_player, listText)
            );
        }

        [Test]
        public void TestInvalidLookCommand()
        {
            List<string> listText = new List<string> { "look", "at", "mirror" };

            string stringTest = "I can't find the mirror";

            Assert.AreEqual
            (
             stringTest,
             cmdProc.ExecuteRelevantCommand(_player, listText)
            );
        }

        [Test]
        public void TestInvalidMoveDirection()
        {
            List<string> listText = new List<string> { "move", "foward"};

            string stringTest = "Cannot find Path";

            Assert.AreEqual
            (
             stringTest,
             cmdProc.ExecuteRelevantCommand(_player, listText)
            );
        }

        [Test]
        public void TestMoveOnly()
        {
            List<string> listText = new List<string> { "move"};

            string stringTest = "Please specify direction";

            Assert.AreEqual
            (
             stringTest,
             cmdProc.ExecuteRelevantCommand(_player, listText)
            );
        }


    }
}
