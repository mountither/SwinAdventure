using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI;
using NUnit.Framework;
using SwinAdven;

namespace GUIUnitTests
{
    public class TestGUIEnter
    {
        string name = "user";
        string desc = "tester";
        GUIEnter gui;
        Player p;

        [SetUp]
        public void SetUp()
        {
            gui = new GUIEnter(name, desc);
            p = gui.TestPlayer;
        }


        [Test]
        public void TestPlayerIsCreatedWhenFormIsShown()
        {

           
            Assert.AreEqual("user", p.Name);


        }


    }
}
