/*
 * Plor V4 Source Code (Main Class):
 */

using System.Windows.Forms;

/*
 * UI Controls:
 * title: Displays the text 'Plor V4' at the top of the form.
 * input: Input for the user's search, (path / URL).
 * log: Output for directory and file path info.
 */

namespace Plor_V4
{
    public partial class Form1 : Form
    {
        //Class Imports:
        FileManager fm = new FileManager();
        Launcher launcher = new Launcher();
        Client client = new Client();

        public Form1()
        {
            InitializeComponent();
        }

        //Print:
        private void logger(string text)
        {
            log.AppendText(text + "\n");
        }

        //Get input text:
        private string getInputText()
        {
            return input.Text;
        }

        //Update log:
        private void updateLog(string inputText)
        {
            //Clear the log:
            log.Text = "";

            //If the directory exists:
            if (fm.dirExists(inputText))
            {
                this.logger(inputText);

                //Print subdirectories:
                string[] subDirs = fm.getDirs(inputText);
                int i;

                for (i = 0; i < subDirs.Length; i++)
                {
                    this.logger(" - " + subDirs[i]);
                }

                //Print subfiles:
                string[] subFiles = fm.getFiles(inputText);
                int j;

                for (j = 0; j < subFiles.Length; j++)
                {
                    this.logger(" - " + subFiles[j]);
                }

                return;
            }

            //If the file exists:
            if (fm.fileExists(inputText))
            {
                this.logger(inputText);

                //Display contents:
                string[] contents = fm.read(inputText);
                int i;

                for (i = 0; i < contents.Length; i++)
                {
                    this.logger("   " + contents[i]);
                }

                //Display number of lines:
                int lines = contents.Length;
                this.logger("\n - Lines: " + lines.ToString());
            }
        }

        //When a key is pressed on the 'input' control:
        private void input_KeyDown(object sender, KeyEventArgs e)
        {
            //Code executed when the 'enter' key is pressed on the input control:
            if (e.KeyCode == Keys.Enter)
            {
                string inputText = this.getInputText();

                //If the file or directory exists:
                if (fm.fileExists(inputText) || fm.dirExists(inputText))
                {
                    launcher.launch(inputText);
                    return;
                }

                //If it is an invalid directory:
                if (!fm.fileExists(inputText) && !fm.dirExists(inputText))
                {
                    //If the search is a valid site:
                    if (client.siteExists(inputText))
                    {
                        launcher.launch(inputText);
                        return;
                    }

                    launcher.launch("https://www.google.com/#q=" + inputText);
                }
            }
        }

        //When the text is changed on the 'input' control:
        private void input_TextChanged(object sender, System.EventArgs e)
        {
            string inputText = this.getInputText();
            this.updateLog(inputText);
        }
    }
}