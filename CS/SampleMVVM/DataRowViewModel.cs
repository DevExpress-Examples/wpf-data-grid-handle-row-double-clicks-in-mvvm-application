// Developer Express Code Central Example:
// How to handle a double-click on a grid row in a MVVM application
// 
// This example demonstrates one of many possible solutions for decoupling DXGrid
// mouse event handling from business logic, when using the MVVM architectural
// pattern.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E2458

using System;
using System.Windows;
using System.Windows.Input;
using DevExpress.Xpf.Core.Commands;

namespace SampleMVVM {
    public class DataRowViewModel {
        public DataRowModel Row { get; private set; }
        public ICommand CellDoubleClickCommand { get; private set; }

        public DataRowViewModel(DataRowModel row) {
            Row = row;
            CellDoubleClickCommand = new DelegateCommand<object>(o => MessageBox.Show("Cell double click. Row: " + Row.Id));
        }
    }
}
