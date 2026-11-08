using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
namespace MaintenanceCenter.Helpers
{
    public static class Validator
    {
        private static int totalDevices = 0;
        private static int repairedDevices = 0;

        public static int TotalDevices
        {
            get { return totalDevices; }
        }

        public static int RepairedDevices
        {
            get { return repairedDevices; }
        }

        public static bool IsValidSerial(string s)
        {
            if (string.IsNullOrEmpty(s))

                return false;





            if (s.Length < 4)
                return false;


            return true; // في حال كان الرقم التسلسلي صحيح
        }

        public static bool IsValidDate(DateTime d)
        {
            if (d > DateTime.Now)
                return false;

            return true;
        }

        public static void AddDevice()
        {
            totalDevices++; // هي لزيادة عدد الأجهزة المضافة 
        }

        public static void MarkRepaired()
        {
            repairedDevices++; // هي لزيادة عدد الأجهزة اللي تم إصلاحها
        }
    }
}