using B4.EE.OmedMilat.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B4.EE.OmedMilat.Domain.Interface
{
    public interface IOpenApp
    {
        Task OpenExternalApp(string appname);
        List<InstalledAppsInfo> AppInfo();
    }
}
