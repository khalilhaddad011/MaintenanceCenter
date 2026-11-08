using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace MaintenanceCenter.Models
{
    public class AirConditioner : Device
    {
        public override double CalculateRepairCost()
        {
            // حساب الكلفة الكلية للصيانة
            double total = BaseCost + freonCost;
            if (needsCleaning)
                total = total + 3000;
            return total;
        }

        private double freonCost;
        private bool needsCleaning;

        public double FreonCost
        {
            get { return freonCost; }
            set { freonCost = value; }
        }

        public bool NeedsCleaning
        {
            get { return needsCleaning; }
            set { needsCleaning = value; }
        }

        public AirConditioner(string serial, string brand, double baseCost, double freonCost, bool needsCleaning)
            : base(serial, brand, baseCost)
        {
            this.freonCost = freonCost;
            this.needsCleaning = needsCleaning;
        }

       

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Type: Air Conditioner");
            Console.WriteLine("Freon Cost: " + freonCost);
            Console.WriteLine("------------------------");
        }
    }
}