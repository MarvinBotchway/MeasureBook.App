using MeasureBook.View;

namespace MeasureBook;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        MeasureBookDb database = await MeasureBookDb.Instance;
        listView.ItemsSource = await database.GetItemsAsync();
    }

    async void OnItemAdded(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClientPage
        {
            BindingContext = new ClientModel()
        });
    }

    async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ClientPage
            {
                BindingContext = e.SelectedItem as ClientModel
            });
        }
    }


}

