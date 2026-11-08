using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
namespace MaintenanceCenter.Models
{
    public class Refrigerator : Device
    {
        public override double CalculateRepairCost()
        {
            // حساب الكلفة
            return BaseCost + gasCost + 5000;
        }

        private double gasCost;

        public double GasCost
        {
            get { return gasCost; }
            set { gasCost = value; }
        }

        public Refrigerator(string serial, string brand, double baseCost, double gasCost)
            : base(serial, brand, baseCost)
        {
            this.gasCost = gasCost;
        }

      

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Type: Refrigerator");
            Console.WriteLine("Gas Cost: " + gasCost);
            Console.WriteLine("------------------------");
        }
    }
}