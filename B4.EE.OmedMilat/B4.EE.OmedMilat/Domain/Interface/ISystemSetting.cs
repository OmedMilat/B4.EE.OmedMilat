using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B4.EE.OmedMilat.Domain.Interface
{
    public interface ISystemSetting
    {
        void ChangeVolume(int volume);
        void ChangeBrightness(int brightness);
    }
}
