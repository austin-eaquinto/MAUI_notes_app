namespace Notes.Views;

public partial class NotePage : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");  // full path to the file
    public NotePage()
	{
		InitializeComponent();  // reads the XAML markup and
                                // initializes all of the objects
                                // declared in the XAML

        if (File.Exists(_fileName)) // if the file exists
            TextEditor.Text = File.ReadAllText(_fileName);  // read the file into the editor
    }
    private void SaveButton_Clicked(object sender, EventArgs e) // writes the text in the editor control to the file represented by _fileName
    {
        // Save the file.
        File.WriteAllText(_fileName, TextEditor.Text);
    }

    private void DeleteButton_Clicked(object sender, EventArgs e)   // if the file represented by _filename variable exists delete the file
    {
        // Delete the file.
        if (File.Exists(_fileName))
            File.Delete(_fileName);

        TextEditor.Text = string.Empty;
    }
}