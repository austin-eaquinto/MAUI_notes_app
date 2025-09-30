using System.Collections.ObjectModel;

namespace Notes.Models;

internal class AllNotes
{
    public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();   // Collection of Note objects

    public AllNotes() =>
        LoadNotes();    // Calls the LoadNotes method to populate the Notes collection

    public void LoadNotes()     // Loads notes from files in the app's data directory
    {
        Notes.Clear();  // Clear existing notes

        // Get the folder where the notes are stored.
        string appDataPath = FileSystem.AppDataDirectory;

        // Use Linq extensions to load the *.notes.txt files.
        IEnumerable<Note> notes = Directory

            // Select the file names from the directory
            .EnumerateFiles(appDataPath, "*.notes.txt")

            // Each file name is used to create a new Note
            .Select(filename => new Note()
            {
                Filename = filename,
                Text = File.ReadAllText(filename),
                Date = File.GetLastWriteTime(filename)
            })

            // With the final collection of notes, order them by date
            .OrderBy(note => note.Date);

        // Add each note into the ObservableCollection
        foreach (Note note in notes)
            Notes.Add(note);
    }
}