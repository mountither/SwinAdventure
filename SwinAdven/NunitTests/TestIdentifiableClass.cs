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
    public class TestIdentifiableObject
    {
        IdentifiableObject _testableObject;
       
        [SetUp]
        public void SetUp()
        {
            List<string> idList = new List<string>
            {
                "Fred",
                "Bob",
                "Richard"
            };

            _testableObject = new IdentifiableObject(idList);
            
        }

        [Test]
         public void TestFirstName()
        {
            Assert.AreEqual
                (
                _testableObject.FirstId,
                "Fred",
                "Testing the First ID is the first identifier"
                );
        }

        [TestCase("fred")]
        [TestCase("bob")]
        [TestCase("fRed")]
        [TestCase("Bob")]
        [TestCase("richard")]
        [TestCase("RicHard")]

        public void TestAreYou(string toTest)
        {
            Assert.IsTrue(_testableObject.AreYou(toTest));
        }


        [TestCase("greg")]
        [TestCase("wilma")]
        public void TestAreYouNot(string toTest)
        {
            Assert.IsFalse(_testableObject.AreYou(toTest));
        }




        [TestCase("wilma")]
        [TestCase("fred")]
        [TestCase("bob")]
        [TestCase("richard")]
        public void TestAddID(string toTest)
        {
            _testableObject.AddIdentifier("wilma");


            Assert.IsTrue(_testableObject.AreYou(toTest));
        }

    }
}
