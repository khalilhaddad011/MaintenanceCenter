using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
namespace MaintenanceCenter.Models
{
    public class WashingMachine : Device
    {
        // لا تعدلو عليها 
        public override double CalculateRepairCost()
        {
            double total = BaseCost + partsCost;
            // هون  خصم 10% إذا كان الضمان أكثر من سنة
            if (warrantyMonths > 12)
                total = total - (total * 0.10);
            return total;
        }

        private double partsCost;
        private int warrantyMonths;

        public double PartsCost
        {
            get { return partsCost; }
            set { partsCost = value; }
        }

        public int WarrantyMonths
        {
            get { return warrantyMonths; }
            set { warrantyMonths = value; }
        }

        public WashingMachine(string serial, string brand, double baseCost, double partsCost, int warrantyMonths)
            : base(serial, brand, baseCost)
        {
            this.partsCost = partsCost;
            this.warrantyMonths = warrantyMonths;
        }

       

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Type: Washing Machine");
            Console.WriteLine("Parts Cost: " + partsCost);
            Console.WriteLine("------------------------");
        }
    }
}