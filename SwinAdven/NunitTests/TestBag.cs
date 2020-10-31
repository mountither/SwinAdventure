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
    public class TestBag
    {
        Bag _bag;

        Item _gem;
        Item _radio;
        Item _torch;
        [SetUp]
        public void SetUp()
        {

            _bag = new Bag(new List<string> { "bag"}, "leather bag", "a portable essential ");

            //add new item instances
            _gem = new Item(new List<string> { "gem"}, "a red gem", "A bright red ruby the size of your fist!");
            _radio = new Item(new List<string> { "radio"}, "a radio", "An old rusty radio");
            _torch = new Item(new List<string> { "torch" }, "a torch", "Useful utensil to rid of darkness");

            foreach (Item i in new List<Item> { _gem, _radio, _torch })
            {
                _bag.Inventory.Put(i);
            }


        }

        [Test]
        public void TestBagLocatesItems()
        {
        

            //locate items in bag's inventory
            Assert.AreEqual
                (
                _gem,
                _bag.Locate("gem"),
                "Testing if bag can locate items in it's inventory"
                );
            Assert.AreEqual
              (
              _radio,
              _bag.Locate("radio"),
              "Testing if bag can locate items in it's inventory"
              );
            Assert.AreEqual
              (
              _torch,
              _bag.Locate("torch"),
              "Testing if bag can locate items in it's inventory"
              );
            
            //testing if items still exist in bag's inven.
            Assert.IsTrue(_bag.Inventory.HasItem("gem"), "Items fed should exist and return true");
            Assert.IsTrue(_bag.Inventory.HasItem("radio"), "Items fed should exist and return true");
            Assert.IsTrue(_bag.Inventory.HasItem("torch"), "Items fed should exist and return true");
        }

        [Test]
        public void TestBagLocatesNull()
        {
            Assert.AreEqual
               (
               null,
               _bag.Locate("my keys"),
               "Testing if bag can locate a non-existent item"
               );
        }

        [Test]
        public void TestBagFullDesc()
        {
            string testString = "In the leather bag you can see: \n" +
                                "   a red gem (gem)" + "\n" +
                                "   a radio (radio)" + "\n" +
                                "   a torch (torch)" + "\n";

            Assert.AreEqual
                (
                testString,
                _bag.FullDescription,
                "test that the full desc is in the format indicated."
                );
        }

        [Test]
        public void TestBagInBag()
        {
            Bag _otherBag = new Bag(new List<string> { "Otherbag" }, "a small backpack", "wear it on your back");
            
            //adding items into other bag
            Item _shovel = new Item(new List<string> { "shovel", "spade" }, "a shovel", "An instrument to dig or kill...");
            Item _sword = new Item(new List<string> { "sword", "blade" }, "a sword", "a long celtic sword");

            _otherBag.Inventory.Put(_shovel);
            _otherBag.Inventory.Put(_sword);

            //add other bag into main bag
            _bag.Inventory.Put(_otherBag);

            //test main bag can locate other bag
            Assert.AreEqual
              (
              _otherBag,
              _bag.Locate("Otherbag"),
              "Testing if bag can locate the other bag"
              );

            //as in previous test, locate items in bag's inventory
            Assert.AreEqual
                (
                _gem,
                _bag.Locate("gem"),
                "Testing if bag can locate items in it's inventory"
                );
            Assert.AreEqual
              (
              _radio,
              _bag.Locate("radio"),
              "Testing if bag can locate items in it's inventory"
              );
            Assert.AreEqual
              (
              _torch,
              _bag.Locate("torch"),
              "Testing if bag can locate items in it's inventory"
              );

            //the main bag cannot locate the items in other bag
            Assert.AreEqual
               (
               null,
               _bag.Locate("sword"),
               "Testing if bag can locate a non-existent item (that actually exist in the other bag)"
               );

            Assert.AreEqual
               (
               null,
               _bag.Locate("shovel"),
               "Testing if bag can locate a non-existent item (that actually exist in the other bag)"
               );

        }
    }
}
