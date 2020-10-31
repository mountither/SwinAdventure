using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI;
using NUnit.Framework;

namespace GUIUnitTests
{
    public class TestGUIStart
    {
        [Test]
        public void TestButtonIsEnabled()
        {
            GUIStart gui = new GUIStart();
            gui.NameTextBox = "name";

            gui.DescTextBox = "typist";

            //expected to be true;
            Assert.IsTrue(gui.ButtonStartEnabled);

        }

        [Test]
        public void TestButtonIsDisabled()
        {
            GUIStart gui = new GUIStart();
            gui.NameTextBox = "";

            gui.DescTextBox = "typist";

            //expected to be false since name is empty;
            Assert.IsFalse(gui.ButtonStartEnabled);

        }




    }
}
