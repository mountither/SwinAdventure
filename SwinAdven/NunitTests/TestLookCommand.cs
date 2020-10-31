using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SwinAdven;

namespace NunitTests
{
    public class TestLookCommand
    {
        Player _player;
        Item _mygem;

        Bag _bag;
        Item _gem;

        [SetUp]
        public void SetUp()
        {
            _player = new Player("player", "mighty programmer");

            _mygem = new Item(new List<string> { "gem" }, "a gem", "a ruby for you from ancient amharia");

      
            _player.Inventory.Put(_mygem);
         

            _bag = new Bag(new List<string> { "bag" }, "bag", "a portable essential ");

            _gem = new Item(new List<string> { "gem" }, "a red gem", "A bright red ruby the size of your fist!");

            _bag.Inventory.Put(_gem);
            _player.Inventory.Put(_bag);
         
        }

        [Test]
        public void TestLookAtMe()
        {
            List<string> listText = new List<string> { "look", "at", "me" };

            LookCommand command =  new LookCommand();

            string stringTest = "You are player the mighty programmer \n You are carrying: \n" + _player.Inventory.ItemList;

            Assert.AreEqual
             (
              stringTest,
              command.Execute(_player, listText),
              "Testing the look command returns a format like stringTest"
             );
     
        }

        [Test]
        public void TestLookAtGem()
        {
            List<string> listText = new List<string> { "look", "at", "gem" };

            LookCommand command = new LookCommand();

            string stringTest = _mygem.FullDescription;

            Assert.AreEqual
            (
             stringTest,
             command.Execute(_player, listText),
             "Testing the look command returns a format like stringTest"
            );
        }

        [Test]
        public void TestLookAtUnk()
        {
            List<string> listText = new List<string> { "look", "at", "gem" };

            //removes gem
            _player.Inventory.Take("gem");


            LookCommand command = new LookCommand();

            string stringTest = "I can't find the gem";

            Assert.AreEqual
            (
             stringTest,
             command.Execute(_player, listText),
             "Testing the look command returns a format like stringTest"
            );
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            List<string> listText = new List<string> { "look", "at", "gem", "in", "me" };

            LookCommand command = new LookCommand();

            string stringTest = _mygem.FullDescription;

            Assert.AreEqual
            (
             stringTest,
             command.Execute(_player, listText),
             "Testing the look command returns a format like stringTest"
            );
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            List<string> listText = new List<string> { "look", "at", "gem", "in", "bag" };

            LookCommand command = new LookCommand();

            string stringTest = _gem.FullDescription;

            Assert.AreEqual
            (
             stringTest,
             command.Execute(_player, listText),
             "Testing the look command returns a format like stringTest"
            );
        }

        [Test]
        public void TestLookAtGemInNoBag()
        {
            List<string> listText = new List<string> { "look", "at", "gem", "in", "bag" };

            //remove bag 
            _player.Inventory.Take("bag");

            LookCommand command = new LookCommand();

            string stringtest = "I can't find the bag";

            Assert.AreEqual
            (
             stringtest,
             command.Execute(_player, listText),
             "testing the look command returns a format like stringtest"
            );
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            List<string> listText = new List<string> { "look", "at", "gem", "in", "bag" };

            //remove the gem in bag 
            _bag.Inventory.Take("gem");

            LookCommand command = new LookCommand();

            string stringtest = "I can't find the gem in the bag";

            Assert.AreEqual
            (
             stringtest,
             command.Execute(_player, listText),
             "testing the look command returns a format like stringtest"
            );
        }


        [Test]
        public void TestInvalidLookAround()
        {
            List<string> listText = new List<string> { "look", "around" };

            LookCommand command = new LookCommand();

            string stringtest = "I don't know how to look for that";

            Assert.AreEqual
            (
             stringtest,
             command.Execute(_player, listText),
             "testing the look command returns a format like stringtest"
            );

        }

        [Test]
        public void TestInvalidUnk()
        {
            List<string> listText = new List<string> { "hello" };

            LookCommand command = new LookCommand();

            string stringtest = "I don't know how to look for that";

            Assert.AreEqual
            (
             stringtest,
             command.Execute(_player, listText),
             "testing the look command returns a format like stringtest"
            );
        }

        [Test]
        public void TestInvalidLookAt()
        {
            List<string> listText = new List<string> { "look", "in", "a", "in", "b" };

            LookCommand command = new LookCommand();

            string stringtest = "What do you want to look at?";

            Assert.AreEqual
            (
             stringtest,
             command.Execute(_player, listText),
             "testing the look command returns a format like stringtest"
            );
        }

        [Test]
        public void TestMisspelledLook()
        {
            List<string> listText = new List<string> { "lok", "at", "gem", "in", "bag" };

            LookCommand command = new LookCommand();

            string stringtest = "Error in look input";

            Assert.AreEqual
            (
             stringtest,
             command.Execute(_player, listText),
             "testing the look command returns a format like stringtest"
            );
        }


    }
}
