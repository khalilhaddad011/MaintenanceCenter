using MaintenanceCenter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 using MaintenanceCenter.Delegates;


namespace MaintenanceCenter.Models
{
    public abstract class Device : IDevice
    {
        private string serial;
        private string brand;
        private string status;
        private DateTime repairDate;
        private double baseCost;

        public event DeviceStatusHandler StatusChanged;

        public string Serial
        {
            get { return serial; }
        }

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (StatusChanged != null)
                    StatusChanged(this, status);
            }
        }

        public DateTime RepairDate
        {
            get { return repairDate; }
            set { repairDate = value; }
        }

        public double BaseCost
        {
            get { return baseCost; }
            set { baseCost = value; }
        }

        public Device(string serial, string brand, double baseCost)
        {
            this.serial = serial;
            this.brand = brand;
            this.baseCost = baseCost;
            this.status = "Under Repair";
            this.repairDate = DateTime.Now;
        }

        public abstract double CalculateRepairCost();

        public virtual void ShowInfo()
        {
            Console.WriteLine("Serial: " + serial);
            Console.WriteLine("Brand: " + brand);
            Console.WriteLine("Status: " + status);
            Console.WriteLine("Repair Cost: " + CalculateRepairCost());
        }

        public string GetStatus()
        {
            return status;
        }

        public bool IsRepaired()
        {
            return status == "Repaired";
        }
    }
}