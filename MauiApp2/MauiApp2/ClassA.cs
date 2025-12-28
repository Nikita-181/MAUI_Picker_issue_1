using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MauiApp2
{
    public class ClassA
    {
        public int id_counter { get; set; }
        public ObservableCollection<ClassB> itemsB { get; set; } = new();
        public ObservableCollection<ClassC> itemsC { get; set; } = new();
    }
}
