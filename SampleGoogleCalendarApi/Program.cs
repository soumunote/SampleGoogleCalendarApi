using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Text;
using System.Threading;

namespace SampleGoogleCalendarApi
{
    class Program
    {
        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "Google Calendar API .NET Quickstart";
        static void Main(string[] args)
        {
            UserCredential credential;

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(Properties.Resources.CREDENTIAL)))
            {
                var credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }
        }
    }
}
