using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.Xpf;
using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace RowDoubleClick_MVVM {
    public class DataItem {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class MainViewModel : ViewModelBase {
        public ObservableCollection<DataItem> Items { get; }
        public DataItem CurrentItem {
            get { return GetProperty(() => CurrentItem); }
            set { SetProperty(() => CurrentItem, value); }
        }
        public MainViewModel() {
            Items = new ObservableCollection<DataItem>(GetItems());
        }
        IEnumerable<DataItem> GetItems() {
            return Enumerable.Range(0, 10).Select(i => new DataItem() { Id = i, Name = "item " + i });
        }

        [Command]
        public void RowDoubleClick(RowClickArgs args) {
            DXMessageBox.Show("Row double click: " + CurrentItem.Name);
        }
    }
}
