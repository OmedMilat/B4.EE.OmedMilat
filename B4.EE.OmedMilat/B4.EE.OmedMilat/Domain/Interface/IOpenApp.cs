using B4.EE.OmedMilat.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace B4.EE.OmedMilat.Domain.Interface
{
    public interface IOpenApp
    {
        Task OpenExternalApp(string appname);
        List<InstalledAppsInfo> AppInfo();    
    }
}
