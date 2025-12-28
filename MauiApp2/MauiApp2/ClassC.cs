using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MauiApp2
{
    public class ClassC
    {
        public int id { get; set; }
        public string name { get; set; }
        public ObservableCollection<ClassB> itemsB { get; set; } = new();
        public ClassB selected_item
        {
            get
            {
                for (var i = 0; i < itemsB.Count; i++)
                {
                    if (itemsB[i].isSelected) return itemsB[i];
                }
                return null;
            }
            set
            {
                if (value == null)
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
                        else itemsB[i].isSelected = false;
                    }
                }
            }
        }
    }
}
