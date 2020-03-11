using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace AnonFileAIO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[AnonFilesAIO]");
            Console.WriteLine();


            // Create request for server.
            try
            {
                WebRequest request = WebRequest.Create("https://api.anonfile.com/v2/file/Fbd6X5g1o7/info");

                // Get response.
                WebResponse response = request.GetResponse();

                using (Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.  
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.  
                    string responseFromServer = reader.ReadToEnd();

                    // Regular expression for fullURL.
                    Regex regex = new Regex(@"https\S+short");

                    Match match = regex.Match(responseFromServer);

                    if (match.Success)
                    {
                        // Remove excess in 'fullURL' string and display.
                        string fullURL = match.Value.Replace("\u0022,\u0022short", "");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Full URL: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(fullURL);
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR: Could not find any matches.");
                    }

                    // Regular expression for name.
                    regex = new Regex(@"name\S+size");

                    match = regex.Match(responseFromServer);

                    if (match.Success)
                    {
                        // Remove excess in 'id' string and display.
                        string name = match.Value.Replace("name\u0022:\u0022", "");
                        name = name.Replace("\u0022,\u0022size", "");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Name: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(name);
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR: Could not find any matches.");
                    }

                    // Regular expression for id.
                    regex = new Regex(@"id\S+name");

                    match = regex.Match(responseFromServer);

                    if (match.Success)
                    {
                        // Remove excess in 'id' string and display.
                        string id = match.Value.Replace("id\u0022:\u0022", "");
                        id = id.Replace("\u0022,\u0022name", "");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Id: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(id);
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR: Could not find any matches.");
                    }

                    // Regular expression for bytes.
                    regex = new Regex(@"bytes\S+read");

                    match = regex.Match(responseFromServer);

                    if (match.Success)
                    {
                        // Remove excess in 'bytes' string and display.
                        string bytes = match.Value.Replace("bytes\u0022:", "");
                        bytes = bytes.Replace(",\u0022read", "");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Bytes: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(bytes);
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR: Could not find any matches.");
                    }

                    // Regular expression for readable.
                    regex = new Regex(@"readable\S+\W\S{3}");

                    match = regex.Match(responseFromServer);

                    if (match.Success)
                    {
                        // Remove excess in 'readable' string and display.
                        string readable = match.Value.Replace("readable\u0022:\u0022", "");
                        readable = readable.Replace("\u0022", "");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Readable: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(readable);
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR: Could not find any matches.");
                    }

                }
                // Close the response.  
                response.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            // Wait for input.
            Console.ReadKey();
        }
    }
}