using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text;

namespace AgileContent.Core
{
    public class Sibling
    {
        /// <summary>
        /// N, returns the largest number in the family of N. 
        /// </summary>
        /// <param name="sib">A set consisting of a non-negative integer N</param>
        /// <returns>Biggest Sibling</returns>
        public int GetBiggestSibling(int sib)
        {
            if (sib > 100000000)
            {
                return -1;
            }
            else if (sib < 0)
            {
                return 0;
            }
            else
            {
                string sibStr = sib.ToString();

                int[] buffer = new int[sibStr.Length];

                for (int i = 0; i < sibStr.Length; i++)
                {
                    buffer[i] = Convert.ToInt32(sibStr[i].ToString());
                }

                Array.Sort(buffer);
                Array.Reverse(buffer);

                string result = string.Empty;
                for (int i = 0; i < buffer.Length; i++)
                {
                    result += buffer[i].ToString();
                }

                return Convert.ToInt32(result);
            }
        }
    }

    /// <summary>
    /// Convert log files to
    // /the desired format, which means that at this moment they need to convert them from
    /// the “MINHA CDN” format to the “Agora” format
    /// </summary>
    public class CDN
    {
        public string Provider { get; set; }
        public string HttpMethod { get; set; }
        public string StatusCode { get; set; }
        public string UriPath { get; set; }
        public int TimeTaken { get; set; }
        public string ResponseSize { get; set; }
        public string CacheStatus { get; set; }

        IFileWriter<CDN> _fileWriter;
        public CDN()
        {
            _fileWriter = new TxtWriter<CDN>();
        }

        public bool Converter(string fileName, string sourceUrl, string targetPath)
        {
            var file = Utility.GetStringFromAPI(sourceUrl);
            if (file == null)
                throw new Exception("Fail to get content from sourceUrl");
            else
            {
                string line = string.Empty;
                CDN cdnRow;
                List<CDN> ListCDN = new List<CDN>();

                using (var reader = new StringReader(file))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        try
                        {
                            string[] arrline = line.Split('|');
                            cdnRow = new CDN
                            {
                                Provider = fileName,
                                ResponseSize = arrline[0],
                                StatusCode = arrline[1],
                                CacheStatus = arrline[2],
                                TimeTaken = Convert.ToInt32(Double.Parse(arrline[4], CultureInfo.InvariantCulture)),
                                HttpMethod = arrline[3].Substring(1, arrline[3].IndexOf('/') - 2),
                                UriPath = arrline[3].Substring(arrline[3].IndexOf('/'), arrline[3].LastIndexOf(' ') - (arrline[3].IndexOf('/')))
                            };

                            if (cdnRow.CacheStatus != "INVALIDATE")
                                ListCDN.Add(cdnRow);

                        }
                        catch (Exception ex)
                        {
                            Utility.WriteException(line, ex);
                            return false;
                        }
                    }
                }

                try
                {
                    string header = $"#Version: 1.0\n#Date: { DateTime.Now}\n#Fields: provider http-method status-code uri-path time-taken\nresponse-size cache-status";

                    _fileWriter.WriteFiles(ListCDN, fileName, targetPath, header);
                }
                catch (Exception ex)
                {
                    Utility.WriteException("Fail to write file", ex);
                    return false;
                }

                return true;
            }
        }
    }

    public interface IFileWriter<T> where T : class
    {
        void WriteFiles(List<T> list, string fileName, string targetPath, string header);
    }

    public class TxtWriter<T> : IFileWriter<T> where T : CDN
    {
        public void WriteFiles(List<T> list, string fileName, string targetPath, string header)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(header);

            for (int x = 0; x < list.Count; x++)
            {
                sb.AppendFormat("\"{0}\" {1} {2} {3} {4} {5} {6}",
                    list[x].Provider,
                    list[x].HttpMethod,
                    list[x].StatusCode,
                    list[x].UriPath,
                    list[x].TimeTaken,
                    list[x].ResponseSize,
                    list[x].CacheStatus).AppendLine();
            }

            File.WriteAllText(targetPath, sb.ToString());
        }
    }

    public static class Utility
    {
        public static void WriteException(string description, Exception ex)
        {
            Console.WriteLine(description);
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.InnerException.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine(string.Empty);
        }

        public static string GetStringFromAPI(string sourceUrl)
        {
            try
            {
                var client = new System.Net.Http.HttpClient
                {
                    BaseAddress = new System.Uri(sourceUrl)
                };

                HttpResponseMessage message = client.GetAsync(sourceUrl).Result;

                return message.IsSuccessStatusCode ? message.Content.ReadAsStringAsync().Result : null;
            }
            catch 
            {
                return null;
            }
        }
    }
}
