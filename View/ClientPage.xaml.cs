namespace MeasureBook.View;


[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class ClientPage : ContentPage
{
	public ClientPage()
	{
		InitializeComponent();
	}

    async void OnSaveClicked(object sender, EventArgs e)
    {
        var client = (ClientModel)BindingContext;
        MeasureBookDb database = await MeasureBookDb.Instance;
        await database.SaveItemAsync(client);
        await Navigation.PopAsync();
    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        var client = (ClientModel)BindingContext;
        MeasureBookDb database = await MeasureBookDb.Instance;
        await database.DeleteItemAsync(client);
        await Navigation.PopAsync();
    }

    async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}