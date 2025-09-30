namespace Notes.Views;

public partial class AllNotesPage : ContentPage     // Inherits from ContentPage class
{
    public AllNotesPage()
    {
        InitializeComponent();  // Initializes the components defined in the XAML file

        BindingContext = new Models.AllNotes(); // Sets the BindingContext to an instance of the AllNotes model
    }

    protected override void OnAppearing()
    {
        ((Models.AllNotes)BindingContext).LoadNotes(); // Calls LoadNotes method to refresh the notes when the page appears
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NotePage));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (Models.Note)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(NotePage)}?{nameof(NotePage.ItemId)}={note.Filename}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }
}