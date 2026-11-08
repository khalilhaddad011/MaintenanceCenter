using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MaintenanceCenter.Models;
using MaintenanceCenter.Services;
using MaintenanceCenter.Helpers;

namespace MaintenanceCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            Center center = new Center();

            // مشان لبيانات  افتراضية -          
            center.AddDevice(new Refrigerator("RF001", "Samsung", 3000, 2000), false);
            center.AddDevice(new WashingMachine("WM001", "LG", 2500, 1500, 18), false);
            center.AddDevice(new AirConditioner("AC001", "Sharp", 4000, 2500, true), false);
            center.AddDevice(new Refrigerator("RF002", "Beko", 2800, 1800), false);

            // هاد الجهاز المراد تصليحه... جهاز واحد -    أ
            center.RepairDevice("WM001");

            int choice = 0;

            while (choice != 6)
            {
                Console.WriteLine("\n==== Maintenance Center ===");
                Console.WriteLine("1 - Add Device");
                Console.WriteLine("2 - Show All Devices");
                Console.WriteLine("3 - Repair Device");
                Console.WriteLine("4 - Total Cost");
                Console.WriteLine("5 - Show Repaired / Pending");
                Console.WriteLine("6 - Exit");
                Console.Write("Choose: ");

                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch
                {
                    choice = 0;
                }

                if (choice == 1)
                {
                    Console.Write(@"Device type
1 = Refrigerator 
2 = WashingMachine
3 = AirConditioner   : ");

                    int type = int.Parse(Console.ReadLine());

                    Console.Write("Serial: ");
                    string serial = Console.ReadLine();

                    if (!Validator.IsValidSerial(serial))
                    {
                        Console.WriteLine("Invalid serial!");
                        continue;
                    }

                    Console.Write("Brand: ");
                    string brand = Console.ReadLine();

                    Console.Write("Base Cost: ");
                    double baseCost = double.Parse(Console.ReadLine());

                    if (type == 1)
                    {
                        Console.Write("Gas Cost: ");
                        double gas = double.Parse(Console.ReadLine());
                        center.AddDevice(new Refrigerator(serial, brand, baseCost, gas));
                    }
                    else if (type == 2)
                    {
                        Console.Write("Parts Cost: ");
                        double parts = double.Parse(Console.ReadLine());
                        Console.Write("Warranty Months: ");
                        int w = int.Parse(Console.ReadLine());
                        center.AddDevice(new WashingMachine(serial, brand, baseCost, parts, w));
                    }
                    else if (type == 3)
                    {
                        Console.Write("Freon Cost: ");
                        double freon = double.Parse(Console.ReadLine());
                        Console.Write("Needs Cleaning? (1=Yes, 0=No): ");
                        bool clean = Console.ReadLine() == "1";
                        center.AddDevice(new AirConditioner(serial, brand, baseCost, freon, clean));
                    }
                }
                else if (choice == 2)
                {
                    center.ShowAll();
                }
                else if (choice == 3)
                {
                    Console.Write("Device Serial: ");
                    string s = Console.ReadLine();
                    center.RepairDevice(s);
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Total Cost: " + center.TotalCost());
                    Console.WriteLine("Total Devices: " + Validator.TotalDevices);
                    Console.WriteLine("Repaired Devices: " + Validator.RepairedDevices);
                }
                else if (choice == 5)
                {
                    Console.WriteLine("--- Repaired ---");
                    center.ShowRepaired();
                    Console.WriteLine("--- Pending ---");
                    center.ShowPending();
                }
            }
        }
    }
}