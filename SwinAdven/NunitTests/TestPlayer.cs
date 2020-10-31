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
    public class TestPlayer
    {
        Player _player;

        Item _shovel;
        Item _sword;
        Item _torch;

        [SetUp]
        public void SetUp()
        {
          
            _player = new Player("Monti", "mighty programmer");

            _shovel = new Item(new List<string> { "shovel", "spade" }, "a shovel", "An instrument to dig or kill...");
            _sword = new Item(new List<string> { "sword", "blade" }, "a sword", "a long celtic sword");
            _torch = new Item(new List<string> { "torch" }, "a torch", "Useful utensil to rid of darkness");


            foreach (Item i in new List<Item> { _shovel, _sword, _torch })
            {
                _player.Inventory.Put(i);
            }

        }

        [TestCase("me")]
        [TestCase("inventory")]
        public void TestPlayerIsIdentifiable(string defaultId)
        {
            Assert.IsTrue(_player.AreYou(defaultId));
        }

        [TestCase("shovel")]
        [TestCase("sword")]
        [TestCase("torch")]

        public void TestItemLocator(string toTest)
        {
            Assert.AreEqual
                (
                _player.Inventory.Fetch(toTest),
                _player.Locate(toTest),
                "Testing if player can locate items in their inventory "
                );

            Assert.IsTrue(_player.Inventory.HasItem(toTest), "Items returned to the player should remain in inventory");
        }

        [TestCase("me")]
        [TestCase("inventory")]
        public void TestPlayerLocator(string myId)
        {
            Assert.AreEqual(_player ,_player.Locate(myId));
        }

        [TestCase("watch")]
        [TestCase("bible")]
        public void TestLocatingNothing(string toTest)
        {
            Assert.AreNotEqual(toTest, _player.Locate(toTest));
        }

        [Test]
        public void TestPlayerFullDesc()
        {
            string stringDesc = "You are Monti the mighty programmer \n You are carrying: \n" + _player.Inventory.ItemList;
                               

            Assert.AreEqual
               (
               stringDesc,
               _player.FullDescription,
               "Testing the player's full desc returns a format like stringDesc"
               );

        }
    }
}
