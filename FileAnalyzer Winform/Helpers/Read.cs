using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Text;

namespace FileAnalyzer_Winform
{
    static class Read
    {
        public static string ReadDocxText(string filePath)  // Reads the text content from a .docx file.
        {
            StringBuilder text = new StringBuilder();
            using (WordprocessingDocument doc = WordprocessingDocument.Open(filePath, false))
            {
                DocumentFormat.OpenXml.Wordprocessing.Body body = doc.MainDocumentPart.Document.Body;
                foreach (var para in body.Elements<Paragraph>())
                {
                    foreach (var run in para.Elements<Run>())
                    {
                        text.Append(run.InnerText);
                        text.Append(" ");
                    }
                }
            }
            return text.ToString();
        }

        public static string ReadPdfText(string filePath) // Reads the text content from a .pdf file and removes special characters, numbers, and extra spaces.
        {
            StringBuilder text = new StringBuilder();
            using (PdfReader reader = new PdfReader(filePath))
            {
                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                    string pageText = PdfTextExtractor.GetTextFromPage(reader, page);
                    pageText = System.Text.RegularExpressions.Regex.Replace(pageText, @"[^\w\s]", "");
                    pageText = System.Text.RegularExpressions.Regex.Replace(pageText, @"\d+", "");
                    pageText = System.Text.RegularExpressions.Regex.Replace(pageText, @"\s{2,}", " ");
                    text.Append(pageText);
                }
            }
            return text.ToString().ToLower();
        }
    }
}
