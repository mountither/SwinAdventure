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
    public class TestInventory
    {
        Item _shovel;
        Item _sword;
        Item _torch;

        Inventory _invent;
        [SetUp]
        public void SetUp()
        {
            _invent = new Inventory();

            _shovel = new Item(new List<string> { "shovel", "spade" }, "a shovel", "An instrument to dig or kill...");
            _sword = new Item(new List<string> { "sword", "blade" }, "a sword", "a long celtic sword");
            _torch = new Item(new List<string> { "torch"}, "a torch", "Useful utensil to rid of darkness");
        
        foreach(Item i in new List<Item> { _shovel, _sword, _torch })
            {
               _invent.Put(i);
            }
            
        }

        [TestCase("shovel")]
        [TestCase("sword")]
        [TestCase("torch")]
        public void FindItem(string IdToTest)
        {
            Assert.IsTrue(_invent.HasItem(IdToTest), "Items fed should exist and return true"); 
        }

        [TestCase("pc")]
        [TestCase("lighter")]
        public void NoItemFound(string IdToTest)
        {
            Assert.IsFalse(_invent.HasItem(IdToTest), "Non-existent items are fed, expected to be false");
        }

        [Test]
        public void FetchItems()
        {
            Assert.AreEqual
                (
                _shovel,
                _invent.Fetch("shovel"),
                "Testing the item is returned"
                );

            Assert.IsTrue(_invent.HasItem("shovel"), "tests if the item still exists");
        }

        [Test]
        public void TakeItem()
        {
            Assert.AreEqual
                (
                _shovel,
                _invent.Take("shovel"),
                "Testing the item is returned"
                );

            Assert.IsFalse(_invent.HasItem("shovel"), "tests if the item doesnt exist");
        }

        [Test]
        public void ItemList()
        {
            string stringList = "   a shovel (shovel)" + "\n" +
                                "   a sword (sword)" + "\n" +
                                "   a torch (torch)" + "\n";

            Assert.AreEqual
               (
               stringList,
               _invent.ItemList,
               "Testing the itemList returns a format like stringList"
               );

            
        }
    }
}
