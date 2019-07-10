using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace DCP_55
{
    /*
    Implement a URL shortener with the following methods:
        •	shorten(url), which shortens the url into a six-character alphanumeric string, such as zLg6wl.
        •	restore(short), which expands the shortened string into the original url. If no such shortened string exists, return null.

    Hint: What if we enter the same URL twice?
    */

    public class DCP_55
    {
        public static void Main()
        {
            UrlShortener shortener = new UrlShortener("ruby", 6);
            while (true)
            {
                Console.WriteLine(shortener.Shorten(Console.ReadLine()));
            }
        }
    }

    public class UrlShortener
    {
        string possibleChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        Random random = new Random();

        Dictionary<string, string> key2UrlDic;
        Dictionary<string, string> url2KeyDic;

        string prefix;
        int len;

        public UrlShortener(string shortenerName, int len)
        {
            key2UrlDic = new Dictionary<string, string>();
            url2KeyDic = new Dictionary<string, string>();

            this.prefix = "www." + shortenerName + ".com/";
            this.len = len;
        }

        public string Shorten(string url)
        {
            //This is before valid URL check only for debugging purposes
            if (Regex.IsMatch(url, "^" + prefix))
            {
                Console.WriteLine("We do not shorten our own links:)");
                string ori = Restore(url);
                if (ori.Length > 0) return ori;
                else
                {
                    Console.WriteLine("We do not have that link either");
                    return "";
                }
            }
            else if (url2KeyDic.ContainsKey(url))
            {
                Console.WriteLine("URL Found!");
                return prefix + url2KeyDic[url];
            }
            if (!CheckIfValidUrl(url))
            {
                Console.WriteLine("We weren't able to receive a response from that URL, please check the URL given and make sure the site is working");
                return "";
            }

            return CreateNewShortenedUrl(url);
        }

        public string Restore(string url)
        {
            int p = url.LastIndexOf("/") + 1;
            string k = url.Substring(p, url.Length - p);
            if (key2UrlDic.ContainsKey(k)) return key2UrlDic[k];
            return "";
        }

        string CreateNewShortenedUrl(string url)
        {
            Console.WriteLine("Creating new URL");

            string key = CreateRandomString(len);
            while (key2UrlDic.ContainsKey(key))
            {
                key = CreateRandomString(len);
            }

            key2UrlDic.Add(key, url);
            url2KeyDic.Add(url, key);

            return (prefix + key);
        }

        string CreateRandomString(int length)
        {
            char[] output = new char[length];
            for (int i = 0; i < length; i++)
            {
                output[i] = possibleChars[random.Next(possibleChars.Length)];
            }

            return new String(output);
        }

        bool CheckIfValidUrl(string url)
        {
            try
            {
                //Creating the HttpWebRequest
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //Setting the Request method HEAD, you can also use GET too.
                request.Method = "HEAD";
                //Getting the Web Response.
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //Returns TRUE if the Status code == 200
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch { return false; };
        }
    }

}