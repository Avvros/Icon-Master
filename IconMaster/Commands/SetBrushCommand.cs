using System;
using System.Windows.Input;
using IconMaster.DrawTools;
using IconMaster.DrawTools.Brushes;

namespace IconMaster.Commands
{
    public class SetBrushCommand : ICommand
    {
#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67

        //public 

        public bool CanExecute(object parameter)
        {
            return parameter is Tool;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
