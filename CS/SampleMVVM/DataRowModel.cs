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

namespace SampleMVVM {
    public class DataRowModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
