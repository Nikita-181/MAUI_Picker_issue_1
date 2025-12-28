using System.Collections.ObjectModel;

namespace MauiApp1
{
    public class ClassA
    {
        public int id_counter {  get; set; }
        public ObservableCollection<ClassB> itemsB { get; set; } = new();
        public ObservableCollection<ClassC> itemsC { get; set; } = new();
    }
}
