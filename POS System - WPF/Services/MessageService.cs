using POS_System___WPF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace POS_System___WPF.Services
{
    public class MessageService : IMessageService
{
    public void ShowInfo(string message) => MessageBox.Show(message, "Info");
    public void ShowWarning(string message) => MessageBox.Show(message, "Warning");
    public void ShowError(string message) => MessageBox.Show(message, "Error");

    public bool ShowConfirm(string message)
    {
        var result = MessageBox.Show(message, "Confirm", MessageBoxButton.YesNo);
        return result == MessageBoxResult.Yes;
    }
}
}
