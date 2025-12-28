using System.Collections.ObjectModel;

namespace MauiApp1
{
    public class ClassC
    {
        public int id {  get; set; }
        public string name {  get; set; }
        public ObservableCollection<ClassB> itemsB { get; set; } = new();
        public ClassB selected_item
        {
            get
            {
                for (var i = 0; i < itemsB.Count; i++)//returning the first selected
                {
                    if (itemsB[i].isSelected) return itemsB[i];
                }
                return null;//else null
            }
            set
            {
                if (value == null)//For third-party controls with a clear button, or a custom workaround (why not basic functionality?)
                {
                    for (var i = 0; i < itemsB.Count; i++) itemsB[i].isSelected = false;
                }
                else
                {
                    for (var i = 0; i < itemsB.Count; i++)
                    {
                        if (itemsB[i].name == value.name)
                        {
                            itemsB[i].isSelected = true;
                        }
                        else itemsB[i].isSelected = false;//Along the way, we remove the old selection
                    }
                }
            }
        }
    }
}
