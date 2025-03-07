using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;



namespace FileAnalyzer_Winform
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            // Configure Serilog for logging
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        private void formApp_Load(object sender, EventArgs e)
        {
            // Set up the combo box for file type selection
            combFileTypes.DropDownStyle = ComboBoxStyle.DropDownList;
            combFileTypes.Items.Add(".txt");
            combFileTypes.Items.Add(".docx");
            combFileTypes.Items.Add(".pdf");

            Log.Information("Application has started.");
        }

        private void combFileTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Enable the Load button when a file type is selected
            btnLoad.Enabled = true;
            Log.Information("File type selected: {FileType}", combFileTypes.SelectedItem);
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            listResult.Items.Clear();

            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                string filePath = file.FileName;
                string fileExtension = System.IO.Path.GetExtension(filePath);
                string fileContent = "";



                try
                {
                    Log.Information("File selected: {FilePath}", filePath);

                    labelFilePath.Visible = true;
                    labelFilePath.Text = filePath.ToString();

                    // Check if the selected file type matches the combo box selection
                    if (fileExtension == combFileTypes.Text)
                    {

                        // Read file content based on extension
                        if (fileExtension == ".txt")
                        {
                            fileContent = File.ReadAllText(filePath).ToLower();
                        }
                        else if (fileExtension == ".docx")
                        {
                            fileContent = Read.ReadDocxText(filePath).ToLower();
                        }
                        else if (fileExtension == ".pdf")
                        {
                            fileContent = Read.ReadPdfText(filePath).ToLower();
                        }

                        string destinationPath = System.IO.Path.Combine(Application.StartupPath, System.IO.Path.GetFileName(filePath));

                        prgBar.Value = 0;

                        // Upload the file asynchronously
                        await UploadFile.UploadFileAsync(filePath, destinationPath, prgBar);

                        MessageBox.Show("File upload completed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Log.Information("The file was successfully uploaded: {FileName}", System.IO.Path.GetFileName(filePath));
                    }
                    else
                    {
                        // Warn the user if the file type does not match the selection
                        MessageBox.Show("Please select the same file type as the one chosen in the ComboBox.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Log.Warning("Incorrect file type selected. Expected: {ExpectedType}, Selected: {SelectedType}",
                            combFileTypes.Text, fileExtension);
                    }

                    fileContent = fileContent.Trim();

                    // Split text into words using common delimiters
                    string[] words = fileContent.Split(new char[] { ' ', '.', ',', '!', '?', '\'', ':', ';', '*', '-', '_', '<', '>', '=', '(', ')', '[', ']', '"', '#', '%', '&', '@', '^', '+', '{', '}', '~', '/', '\\', '|', '`', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    Dictionary<string, int> wordCounts = new Dictionary<string, int>();

                    // Count word occurrences, excluding stop words and numbers
                    foreach (string word in words)
                    {
                        if (word != "ve" && word != "ama" && word != "fakat" && word != "hala" && word != "çünkü")
                        {
                            if (!int.TryParse(word, out int isNumber))
                            {
                                if (wordCounts.ContainsKey(word))
                                {
                                    wordCounts[word]++;
                                }
                                else
                                {
                                    wordCounts[word] = 1;
                                }
                            }
                        }
                    }

                    // Sort words by occurrence count in descending order
                    var sortedByCount = wordCounts.OrderByDescending(pair => pair.Value);

                    // Display words that appear more than once and have more than one character
                    foreach (var pair in sortedByCount)
                    {
                        if (pair.Value > 1 && pair.Key.Length > 1)
                        {
                            listResult.Items.Add($"{pair.Key}: {pair.Value}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle errors and log them
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.Error(ex, "An error occurred while uploading the file.");
                }
                finally
                {
                    Log.CloseAndFlush();
                }
            }
        }




    }
}
