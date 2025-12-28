namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        ClassA mainData;
        public MainPage()
        {
            InitializeComponent();
            mainData = new();
        }
        private async void buttonPage1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1(mainData));
        }
        private async void buttonPage2_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page2(mainData));
        }

        private void buttonTest_Clicked(object sender, EventArgs e)
        {
            ClassA data = new();

            ClassB itemB1 = new ClassB();
            itemB1.id = data.id_counter++;
            itemB1.name = "itemB1";
            data.itemsB.Add(itemB1);

            ClassB itemB2 = new ClassB();
            itemB2.id = data.id_counter++;
            itemB2.name = "itemB2";
            data.itemsB.Add(itemB2);

            ClassB itemB3 = new ClassB();
            itemB3.id = data.id_counter++;
            itemB3.name = "itemB3";
            data.itemsB.Add(itemB3);

            ClassC itemC1 = new ClassC();
            itemC1.id = data.id_counter++;
            foreach (var itemB in data.itemsB)
                itemC1.itemsB.Add((ClassB)itemB.Clone());
            data.itemsC.Add(itemC1);

            itemC1.selected_item = itemB2;

            foreach (var itemC in data.itemsC)
            {
                for (int i = 0; i < itemC.itemsB.Count; i++)
                {
                    if (itemC.itemsB[i].id == itemB2.id)
                    {
                        itemC.itemsB.RemoveAt(i);
                    }
                }
            }

            data.itemsB.Remove(itemB2);

            if(itemC1.selected_item == null)
            {
                string text = "selected_process == null, and setter was not called ^_^";
            }
        }
    }
}
