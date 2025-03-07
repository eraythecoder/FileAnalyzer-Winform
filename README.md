# FileAnalyzer

FileAnalyzer is a Windows Forms application designed to analyze the contents of selected files (.txt, .docx, .pdf). It counts the frequency of words while excluding connectors (e.g., "the", "and") and numbers. The application also securely connects to a SQL Server database to store the results, and passwords are encrypted for added security.

## Features

- **File Processing**: Supports `.txt`, `.docx`, and `.pdf` file formats.
- **Word Frequency Count**: Excludes common connectors and numbers from the count.
- **Database Integration**: Connects to a SQL Server database to store analysis results.
- **Password Encryption**: User passwords are securely stored using encryption.
  
## Prerequisites

To run this application, you will need:

- **Microsoft SQL Server**: Ensure you have a running instance of SQL Server and access to the relevant database.
- **.NET Framework**: The project is built using the .NET Framework, so ensure it's installed on your system.
  
## Setup

1. Clone the repository:
    ```bash
    git clone https://github.com/your-username/FileAnalyzer.git
    ```

2. Open the project in **Visual Studio**.

3. Set up the SQL Server connection in the project by updating the connection string in the relevant configuration files.

4. Build and run the project from Visual Studio.

## Usage

1. Launch the application.
2. Select a file to analyze.
3. The program will count the frequency of words, excluding connectors and numbers.
4. The results will be displayed, and you can view the analysis stored in the SQL Server database.
