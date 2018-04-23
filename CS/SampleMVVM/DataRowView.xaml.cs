using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace SampleMVVM {
    public partial class DataRowView : Window {
        public DataRowView() {
            InitializeComponent();
            List<DataRowViewModel> list = new List<DataRowViewModel>();
            for(int i = 0; i < 100; i++)
                list.Add(new DataRowViewModel(new DataRowModel() { Id = i + 1, Name = "Row" + i.ToString(), Date = DateTime.Now}));
            grid.DataSource = list;
        }
    }

    public static class ClickBindingHelper {
        public static ICommand GetDoubleClickCommand(DependencyObject obj) {
            return (ICommand)obj.GetValue(DoubleClickCommandProperty);
        }
        public static void SetDoubleClickCommand(DependencyObject obj, ICommand value) {
            obj.SetValue(DoubleClickCommandProperty, value);
        }
        public static readonly DependencyProperty DoubleClickCommandProperty =
            DependencyProperty.RegisterAttached("DoubleClickCommand", typeof(ICommand), typeof(ClickBindingHelper), new PropertyMetadata(null, OnDoubleClickCommandChanged));

        static void OnDoubleClickCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            UIElement element = d as UIElement;
            if(element != null) {
                element.InputBindings.Clear();
                ICommand command = e.NewValue as ICommand;
                if(command != null)
                    element.InputBindings.Add(new MouseBinding(command, new MouseGesture(MouseAction.LeftDoubleClick)));
            }
        }
    }
}
