using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MaintenanceCenter.Models;

namespace MaintenanceCenter.Delegates
{
    public delegate void DeviceStatusHandler(Device d, string newStatus);
}