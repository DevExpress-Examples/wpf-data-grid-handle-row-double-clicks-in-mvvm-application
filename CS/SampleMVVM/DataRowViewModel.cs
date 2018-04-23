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
