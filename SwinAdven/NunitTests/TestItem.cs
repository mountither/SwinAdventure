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
    public class TestItem
    {
        Item _shovel;

        [SetUp]
        public void Setup()
        {
            List<string> idList = new List<string>
            {
                "Shovel",
                "Spade"
            };

            _shovel = new Item(idList, "a shovel", "To dig or kill...");

        }

        [TestCase("Shovel")]
        [TestCase("Spade")]
        public void TestIdentifiableItem(string toTest)
        {
  
            Assert.IsTrue(_shovel.AreYou(toTest));
        }

        [Test]
        public void TestShortDesc()
        {

            Assert.AreEqual
                (
                "a shovel (Shovel)",
                _shovel.ShortDescription,
                "test that the short desc and the First ID returns in the format indicated."
                );
        }

        [Test]
        public void TestFullDesc()
        {
            Assert.AreEqual
                (
                "To dig or kill...",
                _shovel.FullDescription,
                "test that the full desc is in the format indicated."
                );
        }
    }
}
