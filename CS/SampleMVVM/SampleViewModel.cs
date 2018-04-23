using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace SampleMVVM {
    public class SampleViewModel : ViewModelBase {
        public ObservableCollection<SampleItem> Items { get; set; }
        public ICommand RowDoubleClickCommand { get; private set; }
        public SampleItem CurrentItem {
            get { return GetProperty(() => CurrentItem); }
            set { SetProperty(() => CurrentItem, value); }
        }
        public SampleViewModel() {
            Items = new ObservableCollection<SampleItem>();
            RowDoubleClickCommand = new DelegateCommand(ExecuteRowDoubleClickCommand);
            InitItems();
        }
        void InitItems() {
            for (int i = 0; i < 10; i++) {
                SampleItem item = new SampleItem() { Id = i, Name = "item " + i.ToString() };
                Items.Add(item);
            }
        }
        void ExecuteRowDoubleClickCommand() {
            MessageBox.Show("Row double click: " + CurrentItem.Name);
        }
    }

    public class SampleItem : BindableBase {
        public int Id {
            get { return GetProperty(() => Id); }
            set { SetProperty(() => Id, value); }
        }
        public string Name {
            get { return GetProperty(() => Name); }
            set { SetProperty(() => Name, value); }
        }
    }
}
