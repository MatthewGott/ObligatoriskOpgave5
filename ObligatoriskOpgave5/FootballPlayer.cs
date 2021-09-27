using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoriskOpgave5
{
    public class FootballPlayer
    {
        //Static int that is used for generating unique ID's for all instances of this Class
        private static int NextID = 1;

        //Properties of the Class
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int ShirtNumber { get; set; }

        //The Constructor for the Class
        public FootballPlayer(string name, int price, int shirtnumber)
        {
            //Sets the ID for the Player
            ID = NextID;
            ++NextID;

            //Checks Name length and applies if valid, throws an exception if invalid
            if (name.Length >= 4) Name = name;
            else throw new ArgumentOutOfRangeException("Name is too Short, must be a minimum of 4 letters");

            //Checks if Price is MORE than 0, throws an exception if invalid
            if (price > 0) Price = price;
            else throw new ArgumentOutOfRangeException("Invalid Price submitted, must be a Positive number (higher than 0)");

            //Checks if Shirtnumber is Higher than 0 AND lower than 101, throws an exception if invalid
            if (shirtnumber > 0 && shirtnumber < 101) ShirtNumber = shirtnumber;
            else throw new ArgumentOutOfRangeException("Invalid ShirtNumber submitted, must be higher than 0 AND lower than 101");
        }

        public override string ToString()
        {
            return ("ID : " + ID.ToString() + ", Name : " + Name + ", Price : " + Price.ToString() + ", ShirtNumber : " + ShirtNumber.ToString());
        }
    }
}
