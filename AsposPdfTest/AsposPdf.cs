using Aspose.Pdf;
using System;
using System.IO;

namespace AsposPdfTest
{
    public class AsposPdf
    {
        public Document CreatePdf(string strImage)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(strImage);
                Document pdfDocument = new Document();
                Page page = pdfDocument.Pages.Add();
                using (MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length))
                {
                    Aspose.Pdf.Image pdfImage = new Aspose.Pdf.Image
                    {
                        ImageStream = ms
                    };
                    page.Paragraphs.Add(pdfImage);
                    MemoryStream ms2 = new MemoryStream();
                    pdfDocument.Save(ms2);
                                       
                    ms2 = null;
                }
                return pdfDocument;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
    }
}
