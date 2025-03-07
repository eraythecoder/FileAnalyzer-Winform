using Serilog;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileAnalyzer_Winform
{
    public static class UploadFile  
    {
        // Reads a file asynchronously and updates the progress bar based on the read progress.
        public static async Task UploadFileAsync(string sourcePath, string destinationPath, ProgressBar prgBar)
        {
            byte[] buffer = new byte[4096]; 
            long totalBytes = new FileInfo(sourcePath).Length; 
            long readBytes = 0;

            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            {
                int bytesRead;
                while ((bytesRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    readBytes += bytesRead;

                    
                    int progress = (int)((readBytes * 100) / totalBytes);
                    prgBar.Invoke((MethodInvoker)(() => prgBar.Value = progress));

                    await Task.Delay(650); 
                }
            }
        }
    }
}
