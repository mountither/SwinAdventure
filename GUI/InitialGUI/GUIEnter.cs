using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI;
using SwinAdven;

namespace GUI
{
    public partial class GUIEnter : Form
    {

        string _descValue;
        string _nameValue;
        private Player player;
        private CommandProcessor processCmd;
        private List<string> commandStr;
        private string line;
        public GUIEnter(string nameValue, string descValue)
        {
           

            _nameValue = nameValue;
            _descValue = descValue;
            player = new Player(_nameValue, _descValue);

            //player starts with this item
            Item _sword = new Item(new List<string> { "sword", "blade" }, "a sword", "a long celtic sword");
            player.Inventory.Put(_sword);


            //items existing in all locations
            Bag _bag = new Bag(new List<string> { "bag" }, "leather bag", "a portable essential ");
            Bag _satchel = new Bag(new List<string> { "satchel" }, "satchel", "handheld item");
            //add items in each bag 
            Item _wallet = new Item(new List<string> { "wallet" }, "wallet", "There's money in here...");
            _bag.Inventory.Put(_wallet);
            Item _ciggerates = new Item(new List<string> { "ciggerates", "smokes" }, "ciggerates", "New smokes");
            _satchel.Inventory.Put(_ciggerates);
            

            Item _torch = new Item(new List<string> { "torch" }, "torch", "Useful utensil to rid of darkness");
            Item _card = new Item(new List<string> { "card" }, "credit card", "A credit card with monies to pay your upcoming rent with");
            Item _belt = new Item(new List<string> { "belt" }, "waist belt", "Use this if you run out of edibles");
            Item _nail = new Item(new List<string> { "nail" }, "rusty nail", "Old and rusty");
            Item _keys = new Item(new List<string> { "keys" }, "keys", "Seems like someone dropped these");
            Item _pc = new Item(new List<string> { "pc", "computer" }, "pc", "binary machine");
            Item _thermo = new Item(new List<string> { "thermostat", "thermo" }, "thermostat", "Check the room temperature...its 17 degrees celcius");
            Item _calculator = new Item(new List<string> { "calculator", "calc" }, "calculator", "you can calculate your survival rate!");
            Item _stapler = new Item(new List<string> { "stapler" }, "stapler", "a few staples left in this");


            //player will start in this location
            Location _hallway = new Location(new List<string> { "hallway", "here" }, "hallway", "A long room with great lighting");
            player.Location = _hallway;
            player.Location.Inventory.Put(_calculator);
            player.Location.Inventory.Put(_stapler);


            //all the possible locations
            Location _garden = new Location(new List<string> { "Garden" }, "Garden", "green trees and fountain");
            //add items in garden
            _garden.Inventory.Put(_nail);
            _garden.Inventory.Put(_bag);
            Location _boiler = new Location(new List<string> { "Boiler room" }, "Boiler Room", "A dark room");
            //add items in boiler room
            _boiler.Inventory.Put(_thermo);
            _boiler.Inventory.Put(_nail);
            _boiler.Inventory.Put(_satchel);
            Location _kitchen = new Location(new List<string> { "Kitchen" }, "Kitchen", "very cold and empty");
            //add items in kitchen
            _kitchen.Inventory.Put(_keys);
            _kitchen.Inventory.Put(_card);
            Location _room = new Location(new List<string> { "Room" }, "Room", "there are three beds here with toys scattered on the floor");
            //add items in kitchen
            _room.Inventory.Put(_torch);
            _room.Inventory.Put(_belt);
            _room.Inventory.Put(_pc);

            //the paths available to player at default location
            Path hallwayPathNorth = new Path(new List<string> { "north", "n", "up" }, "North", "go through a door");
            hallwayPathNorth.Location = _garden;
            Path gardenPathSouth = new Path(new List<string> { "south", "s", "down" }, "South", "go back through the door");
            gardenPathSouth.Location = _hallway;
            _garden.AddPath(gardenPathSouth);

            Path hallwayPathSouth = new Path(new List<string> { "south", "s", "down" }, "South", "forcibly open the hatch and enter");
            hallwayPathSouth.Location = _boiler;
            Path boilerPathNorth = new Path(new List<string> { "north", "n", "up" }, "North", "you easily walk out the hatch");
            boilerPathNorth.Location = _hallway;
            _boiler.AddPath(boilerPathNorth);

            Path hallwayPathEast = new Path(new List<string> { "east", "e" }, "East", "enter through a sliding door");
            hallwayPathEast.Location = _kitchen;
            Path kitchenPathWest = new Path(new List<string> { "west", "w" }, "West", "reslide the door");
            kitchenPathWest.Location = _hallway;
            _kitchen.AddPath(kitchenPathWest);

            Path hallwayPathWest = new Path(new List<string> { "west", "w" }, "West", "enter through a door");
            hallwayPathWest.Location = _room;
            Path roomPathEast = new Path(new List<string> { "east", "e" }, "East", "go back where you were");
            roomPathEast.Location = _hallway;
            _room.AddPath(roomPathEast);

            foreach (Path p in new List<Path> { hallwayPathNorth, hallwayPathSouth, hallwayPathEast, hallwayPathWest })
            {
                player.Location.AddPath(p);

            }

            processCmd = new CommandProcessor();

            InitializeComponent();

            

        }

        public Player TestPlayer
        {
            get
            {
                return player;
            }
        }

        public string OutputTextTest
        {
            get
            {
                return OutputText.Text;
            }
        }

        public string InsertCommandTest
        {
            set
            {
                textBox1.Text = value;
            }
        }

        private void EnterGUI_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            line = textBox1.Text;
            commandStr = line.Split(' ').ToList();
            string returnInfo = processCmd.ExecuteRelevantCommand(player, commandStr);
            OutputText.Text = returnInfo;
            OutputText.Visible = true;

            if (line == "quit")
            {
                this.Close();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                actionBtn.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;

                textBox1.Clear();
                
            }
        }
    }
}
