using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Interfaces
{
    public interface IMessageService
    {
        void ShowInfo(string message);
        void ShowWarning(string message);
        void ShowError(string message);
        bool ShowConfirm(string message);
    }
}
