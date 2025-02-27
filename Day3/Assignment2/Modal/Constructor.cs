using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Modal
{
    internal class Constructor
    {
        private string assetName;
        private string assetType;
        private double assetValue;


        // Public properties to access private fields
        public string AssetName
        {
            get { return assetName; }
            set { assetName = value; }
        }

        public string AssetType
        {
            get { return assetType; }
            set { assetType = value; }
        }

        public double AssetValue
        {
            get { return assetValue; }
            set { assetValue = value; }
        }


        // Parameterized constructor
        public Constructor(string name, string type, double value)
        {
            this.assetName = name;
            this.assetType = type;
            this.assetValue = value;
        }


        public Constructor()
        {
            this.assetName = "Unknown";
            this.assetType = "Unknown";
            this.assetValue = 0.0;
        }

        public void Display()
        {
            Console.WriteLine($"Asset Name: {AssetName}, Type: {AssetType}, Value: {AssetValue}");
        }

    }
}
