﻿//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Windows.Forms;

//namespace SwinAdven
//{
//    public class Program
//    {

//        public static void Main(string[] args)
//        {

//            Console.WriteLine("What's your name? ");
//            string name = Console.ReadLine();
//            Console.WriteLine("Briefly describe yourself ");
//            string desc = Console.ReadLine();
//            Player player = new Player(name, desc);


//            //player starts with this item
//            Item _sword = new Item(new List<string> { "sword", "blade" }, "a sword", "a long celtic sword");
//            player.Inventory.Put(_sword);


//            //items existing in all locations
//            Bag _bag = new Bag(new List<string> { "bag" }, "leather bag", "a portable essential ");
//            Bag _satchel = new Bag(new List<string> { "satchel" }, "satchel", "handheld item");
//            //add items in each bag 
//            Item _wallet = new Item(new List<string> { "wallet" }, "wallet", "There's money in here...");
//            _bag.Inventory.Put(_wallet);
//            Item _ciggerates = new Item(new List<string> { "ciggerates", "smokes" }, "ciggerates", "Old smokes");
//            _satchel.Inventory.Put(_ciggerates);


//            Item _torch = new Item(new List<string> { "torch" }, "torch", "Useful utensil to rid of darkness");
//            Item _card = new Item(new List<string> { "card" }, "credit card", "A credit card with monies to pay your upcoming rent with");
//            Item _belt = new Item(new List<string> { "belt" }, "waist belt", "Use this if you run out of edibles");
//            Item _nail = new Item(new List<string> { "nail" }, "rusty nail", "Old and rusty");
//            Item _keys = new Item(new List<string> { "keys" }, "keys", "Seems like someone dropped these");
//            Item _pc = new Item(new List<string> { "pc", "computer" }, "pc", "binary machine");
//            Item _thermo = new Item(new List<string> { "thermostat", "thermo" }, "thermostat", "Check the room temperature...");


//            //player will start in this location
//            player.Location = new Location(new List<string> { "hallway", "here" }, "hallway", "A long room with great lighting");

//            //all the possible locations
//            Location _garden = new Location(new List<string> { "Garden" }, "Garden", "green trees and fountain");
//            //add items in garden
//            _garden.Inventory.Put(_nail);
//            _garden.Inventory.Put(_bag);
//            Location _boiler = new Location(new List<string> { "Boiler room" }, "Boiler Room", "A dark room");
//            //add items in boiler room
//            _boiler.Inventory.Put(_thermo);
//            _boiler.Inventory.Put(_nail);
//            _boiler.Inventory.Put(_satchel);
//            Location _kitchen = new Location(new List<string> { "Kitchen" }, "Kitchen", "very cold and empty");
//            //add items in kitchen
//            _kitchen.Inventory.Put(_keys);
//            _kitchen.Inventory.Put(_card);
//            Location _room = new Location(new List<string> { "Room" }, "Room", "there are three beds here with toys scattered on the floor");
//            //add items in kitchen
//            _room.Inventory.Put(_torch);
//            _room.Inventory.Put(_belt);
//            _room.Inventory.Put(_pc);

//            //the paths available to player at default location
//            Path hallwayPathNorth = new Path(new List<string> { "north", "n", "up" }, "North", "go through a door");
//            hallwayPathNorth.Location = _garden;
//            Path hallwayPathSouth = new Path(new List<string> { "south", "s", "down" }, "South", "forcibly open the hatch a enter");
//            hallwayPathSouth.Location = _boiler;
//            Path hallwayPathEast = new Path(new List<string> { "east", "e" }, "East", "enter through a sliding door");
//            hallwayPathEast.Location = _kitchen;
//            Path hallwayPathWest = new Path(new List<string> { "west", "w" }, "West", "enter through a door");
//            hallwayPathWest.Location = _room;

//            foreach (Path p in new List<Path> { hallwayPathNorth, hallwayPathSouth, hallwayPathEast, hallwayPathWest })
//            {
//                player.Location.AddPath(p);

//            }

//            CommandProcessor processCmd = new CommandProcessor();


//            while (true)
//            {
//                string line = Console.ReadLine();
//                List<string> commandStr = line.Split(' ').ToList();

//                string returnInfo = processCmd.ExecuteRelevantCommand(player, commandStr);

//                Console.WriteLine(returnInfo);

//                if (line == "quit")
//                {
//                    return;
//                }
//            }

//        }
//    }
//}