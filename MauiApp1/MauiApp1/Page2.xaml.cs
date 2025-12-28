namespace MauiApp1;

public partial class Page2 : ContentPage
{
    ClassA mainData;
    public Page2(ClassA mainData)
    {
        InitializeComponent();
        this.mainData = mainData;
        collectionView1.ItemsSource = this.mainData.itemsC;
    }
    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        NavigationPage? navPage = Application.Current?.MainPage as NavigationPage;
        var stack = navPage?.Navigation.NavigationStack;
        int pageCount = navPage.Navigation.NavigationStack.Count;

        if (navPage.Navigation.NavigationStack[pageCount - 1].Title == "Page1")
        {
            var pagesTitle = string.Join("\n", stack);
        }
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