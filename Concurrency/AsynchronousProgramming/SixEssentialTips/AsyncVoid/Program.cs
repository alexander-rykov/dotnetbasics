using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AsyncVoid
{
    // NOTE This example is taken from this video: https://channel9.msdn.com/Series/Three-Essential-Tips-for-Async/Tip-1-Async-void-is-for-top-level-event-handlers-only
    class Program
    {
        private string m_GetResponse;

        private async void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SendData("http://mydomain.com/api/service/users");
                await Task.Delay(2000);
                Debug.WriteLine("Received data {0}", m_GetResponse);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception when sending data: {0}.", e.Message);
            }
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SendData("http://mydomain.com/api/service/users");
                // await Task.Delay(2000);
                // Debug.WriteLine("Received data {0}", m_GetResponse);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception when sending data: {0}.", e.Message);
            }
        }

        private async void SendData(string url)
        {
            var request = WebRequest.Create(url);
            using (var response = await request.GetResponseAsync())
            using (var stream = new StreamReader(response.GetResponseStream()))
            {
                m_GetResponse = stream.ReadToEnd();
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
