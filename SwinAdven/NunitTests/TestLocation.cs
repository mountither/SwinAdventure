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
    public class TestLocation
    {
        Item _shovel;
        Item _sword;
        Item _torch;
        
        Location _location;

        Player _player;

        [SetUp]
        public void SetUp()
        {
            _location = new Location(new List<string> { "hallway" }, "hallway", "A long room with great lighting");

            _shovel = new Item(new List<string> { "shovel", "spade" }, "a shovel", "An instrument to dig or kill...");
            _sword = new Item(new List<string> { "sword", "blade" }, "a sword", "a long celtic sword");
            _torch = new Item(new List<string> { "torch" }, "a torch", "Useful utensil to rid of darkness");

            foreach (Item i in new List<Item> { _shovel, _sword, _torch })
            {
                _location.Inventory.Put(i);
            }

        }

        [Test]
        public void IdentifyLocation()
        {
            string stringDesc = "Your are in the hallway \n A long room with great lighting \n In this room you can see: \n" +
                                "   a shovel (shovel)" + "\n" +
                                "   a sword (sword)" + "\n" +
                                "   a torch (torch)" + "\n";
            Assert.AreEqual(stringDesc, _location.FullDescription);
           
        }

        [TestCase("shovel")]
        [TestCase("sword")]
        [TestCase("torch")]
        public void LocateItemsInLocation(string itemToTest)
        {
            Assert.IsTrue(_location.Inventory.HasItem(itemToTest));
        }

        [TestCase("shovel")]
        [TestCase("sword")]
        [TestCase("torch")]
        public void LocateItemsInPlayerLocation(string itemToTest)
        {
            _player = new Player("tony", "The best chef");
            foreach (Item i in new List<Item> { _shovel, _sword, _torch })
            {
                _player.Location.Inventory.Put(i);
            }

            Assert.IsTrue(_player.Location.Inventory.HasItem(itemToTest));

        }

        [Test]
        public void TestLookCommandForLocation()
        {
            _player = new Player("tony", "The best chef");
            foreach (Item i in new List<Item> { _shovel, _sword, _torch })
            {
                _player.Location.Inventory.Put(i);
            }

            List<string> listText = new List<string> { "look", "at", "sword" };

            LookCommand command = new LookCommand();

            string stringTest = _sword.FullDescription;

            Assert.AreEqual
            (
             stringTest,
             command.Execute(_player, listText),
             "Testing the look command returns a format like stringTest"
            );
        }
    }
}
