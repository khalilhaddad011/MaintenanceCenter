using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceCenter.Interfaces
{
    public interface IDevice
    {
        void ShowInfo (  );


        double CalculateRepairCost ( );

        string GetStatus ();

        bool IsRepaired  ();


    }
}
