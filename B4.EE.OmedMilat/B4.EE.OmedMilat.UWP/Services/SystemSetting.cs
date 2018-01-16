using B4.EE.OmedMilat.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace B4.EE.OmedMilat.UWP.Services
{
    class SystemSetting : ISystemSetting
    {
        public void ChangeBrightness(int brightness)
        {         
        }

        public void ChangeVolume(int volume)
        {      
        }

        public void CloseApp()
        {
            Application.Current.Exit();
        }

        public void Vibrate(int ms)
        {
        }
    }
}
