using System.Diagnostics;

namespace FluentExample.Helpers
{

    public class GeneratePDF
    {
        private string url { get; set; }

        public GeneratePDF(string _url)
        {
            this.url = _url;
        }

        public byte[] getPdf()
        {
            var switches = $"{url} -";

            string rotativaLocation = Path.Combine(Directory.GetCurrentDirectory(), "converter", "weasyprint.exe");

            using (var proc = new Process())
            {
                try
                {
                    proc.StartInfo = new ProcessStartInfo
                    {
                        FileName = rotativaLocation,
                        Arguments = switches,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        RedirectStandardInput = true,
                        CreateNoWindow = true
                    };

                    proc.Start();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                using (var ms = new MemoryStream())
                {
                    proc.StandardOutput.BaseStream.CopyTo(ms);
                    return ms.ToArray();
                }
            }
        }
    }
}
