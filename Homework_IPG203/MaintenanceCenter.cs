using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MaintenanceCenter.Models;
using MaintenanceCenter.Helpers;

namespace MaintenanceCenter.Services
{
    public class Center
    {
        private List<Device> devices = new List<Device>();

         public void AddDevice(Device d, bool showMessage = true)
        {
            devices.Add(d);
            Validator.AddDevice();
            d.StatusChanged += OnStatusChanged;

            if (showMessage)
                Console.WriteLine("Device added successfully");
        }

        private void OnStatusChanged(Device d, string newStatus)
        {
            if (newStatus == "Repaired")
            {
                Validator.MarkRepaired();
                Console.WriteLine(">>> Device " + d.Serial + " is repaired!");
            }
        }

        public void ShowAll()
        {
            if (devices.Count == 0)
            {
                Console.WriteLine("No devices found");
                return;
            }
            foreach (Device d in devices)
            {
                d.ShowInfo();
            }
        }

        public void RepairDevice(string serial)
        {
            foreach (Device d in devices)
            {
                if (d.Serial == serial)
                {
                    d.Status = "Repaired";
                    return;
                }
            }
            Console.WriteLine("Device not found");
        }

        public double TotalCost()
        {
            double total = 0;
            foreach (Device d in devices)
            {
                total = total + d.CalculateRepairCost();
            }
            return total;
        }

        public void ShowRepaired()
        {
            foreach (Device d in devices)
            {
                if (d.IsRepaired())
                    d.ShowInfo();
            }
        }

        public void ShowPending()
        {
            foreach (Device d in devices)
            {
                if (!d.IsRepaired())
                    d.ShowInfo();
            }
        }
    }
}