using Microsoft.Maui.Controls;

namespace MauiApp1;

public partial class Page1 : ContentPage
{
    ClassA mainData;

    public Page1(ClassA mainData)
    {
        InitializeComponent();
        this.mainData = mainData;
        collectionView1.ItemsSource = this.mainData.itemsB;

    }
    private void buttonAddRow_Clicked(object sender, EventArgs e)
    {
        ClassB itemB1 = new ClassB();
        itemB1.id = mainData.id_counter++;
        itemB1.name = "itemB1";
        mainData.itemsB.Add(itemB1);

        ClassB itemB2 = new ClassB();
        itemB2.id = mainData.id_counter++;
        itemB2.name = "itemB2";
        mainData.itemsB.Add(itemB2);

        ClassB itemB3 = new ClassB();
        itemB3.id = mainData.id_counter++;
        itemB3.name = "itemB3";
        mainData.itemsB.Add(itemB3);
    }
    private async void buttonDeleteRow_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            if (button.BindingContext is ClassB item)
            {
                bool result = await DisplayAlert("Comfirm the action", "Do you really want to delete the item \"" + item.name + "\" ?", "Yes", "No");
                if (result)
                {
                    RemoveInDependencies(item.id);
                    mainData.itemsB.Remove(item);
                }
            }
        }
    }
    void RemoveInDependencies(int id)
    {
        foreach (var itemC in mainData.itemsC)
        {
            for (int i = 0; i < itemC.itemsB.Count; i++)
            {
                if (itemC.itemsB[i].id == id)
                {
                    NavigationPage? navPage = Application.Current?.MainPage as NavigationPage;
                    var stack = navPage?.Navigation.NavigationStack;
                    int pageCount = navPage.Navigation.NavigationStack.Count;

                    var pagesTitle = string.Join("\n", stack);

                    itemC.itemsB.RemoveAt(i);
                    break;
                }
            }
        }
    }
}