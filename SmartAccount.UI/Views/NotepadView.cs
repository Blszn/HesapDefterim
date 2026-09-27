using System;
using System.IO;
using System.Windows.Forms;

namespace SmartAccount.UI.Views
{
    public partial class NotepadView : UserControl
    {
        private string notesFilePath;

        public NotepadView()
        {
            InitializeComponent();
            notesFilePath = Path.Combine(Application.StartupPath, "notes.txt");
            LoadNotes();
        }

        private void LoadNotes()
        {
            if (File.Exists(notesFilePath))
            {
                txtNotes.Text = File.ReadAllText(notesFilePath);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            File.WriteAllText(notesFilePath, txtNotes.Text);
            MessageBox.Show("Notlar kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}


