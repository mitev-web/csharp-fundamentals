using System;
using System.Linq;
using System.Net;


    class FileDownloader
    {
        //Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg) 
        //and stores it the current directory. Find in Google how to download files in C#. Be sure to catch 
        //all exceptions and to free any used resources in the finally block.

        static void Main(string[] args)
        {
            string url = "http://www.devbg.org/img/Logo-BASD.jpg";
            string localPath = @Environment.CurrentDirectory + "\\Logo-BASD.jpg";
            try
            {
               DownloadFile(url, localPath);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Data);
                Console.WriteLine(e.StackTrace);
            }
            catch (AccessViolationException e)
            {
                Console.WriteLine("You cannot save the file in this location {0}", localPath);
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Data);
                Console.WriteLine(e.StackTrace);
            }
            finally
            { 
                //TODO: free up some resources
            }
        }

        private static void DownloadFile(string url, string localPath)
        {
            WebClient webClient = new WebClient();

            webClient.DownloadFile(url, localPath);
            webClient.Dispose();
        }
    }
