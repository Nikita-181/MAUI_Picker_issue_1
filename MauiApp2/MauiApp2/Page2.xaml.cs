using Microsoft.Maui.Controls;

namespace MauiApp2;

public partial class Page2 : ContentPage
{
    ClassA mainData;
    public Page2(ClassA mainData)
    {
        InitializeComponent();
        this.mainData = mainData;
        collectionView1.ItemsSource = this.mainData.itemsC;
    }
    private async void buttonDeleteRow_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            if (button.BindingContext is ClassC item)
            {
                bool result = await DisplayAlert("Comfirm the action", "Do you really want to delete the item \"" + item.name + "\" ?", "Yes", "No");
                if (result)
                {
                    mainData.itemsC.Remove(item);
                }
            }
        }
    }

    private void buttonAddRow_Clicked(object sender, EventArgs e)
    {
        ClassC itemC = new ClassC();
        itemC.id = mainData.id_counter++;
        foreach (var itemB in mainData.itemsB)
            itemC.itemsB.Add((ClassB)itemB.Clone());
        mainData.itemsC.Add(itemC);
    }
}