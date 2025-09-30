namespace Notes.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage : ContentPage
{
    public string ItemId
    {
        set { LoadNote(value); }
    }

    public NotePage()
	{
		InitializeComponent();  // reads the XAML markup and
                                // initializes all of the objects
                                // declared in the XAML

        string appDataPath = FileSystem.AppDataDirectory;                   // gets the path to the app's data directory
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";    // generates a random file name with .notes.txt extension

        LoadNote(Path.Combine(appDataPath, randomFileName));                // loads the note from the file represented by the full path
    }
    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note note)
            File.WriteAllText(note.Filename, TextEditor.Text);

        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note note)
        {
            // Delete the file.
            if (File.Exists(note.Filename))
                File.Delete(note.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }

    private void LoadNote(string fileName)  // loads the note from the file represented by the full path
    {
        Models.Note noteModel = new Models.Note();              // creates a new instance of the Note class
        noteModel.Filename = fileName;                          // sets the Filename property of the noteModel object to the fileName parameter

        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);    // sets the Date property of the noteModel object to the creation time of the file represented by the fileName parameter
            noteModel.Text = File.ReadAllText(fileName);        // sets the Text property of the noteModel object to the text read from the file represented by the fileName parameter
        }

        BindingContext = noteModel;                             // sets the BindingContext property of the NotePage object to the noteModel object
    }

}