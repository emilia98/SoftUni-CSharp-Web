using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Cookies
{
    class StartUp
    {
        static async Task Main()
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 1234);
            tcpListener.Start();

            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
                await Task.Run(() => ProcessClientAsync(tcpClient));
            }
        }

        private static async Task ProcessClientAsync(TcpClient tcpClient)
        {
            const string NewLine = "\r\n";

            using NetworkStream networkStream = tcpClient.GetStream();
            // TODO: Use buffer
            byte[] requestBytes = new byte[1000000];
            int bytesRead = await networkStream.ReadAsync(requestBytes, 0, requestBytes.Length);
            string request = Encoding.UTF8.GetString(requestBytes, 0, bytesRead);

            var username = Regex.Match(request, @"Cookie: user=[^\n]*\n").Value;

            string responseText = $"<h1>{username}</h1>";
            string responseForm = @"<form action='/Account/Login' method='post'> 
                                                <input type='date' name='date' />
                                                <input type='text' name='username' />
                                                <input type='password' name='password' />
                                                <input type='submit' value='Login' />
                                            </form>" + "<h1>" + DateTime.UtcNow + "</h1>";
            // Thread.Sleep(10000);
            string response =
                            "HTTP/1.0 200 OK" + NewLine
                            // "HTTP/1.0 307 OK" + NewLine
                            + "Server: SoftUniServer/1.0" + NewLine
                            // + "Content-Disposition: attachment; filename=emilia.html" + NewLine
                            // + "Location: https://google.com" + NewLine
                            + "Content-Type: text/html" + NewLine
                            // + $"Set-Cookie: user=Niki; Expires={DateTime.UtcNow.ToString("R")}" + NewLine
                            + $"Set-Cookie: user=Niki; Expires={new DateTime(2021, 1, 1).ToString("R")}; HttpOnly" + NewLine
                            + "Set-Cookie: lang=bg; Path=/lang; Max-Age=3600" + NewLine
                            // + "Set-Cookie: lang=bg; Path=/lang; Max-Age=3600; Secure" + NewLine
                            + $"Content-Length: {responseText.Length + responseForm.Length}" + NewLine
                            + NewLine
                            + responseText + responseForm;
            byte[] responseBytes = Encoding.UTF8.GetBytes(response);
            await networkStream.WriteAsync(responseBytes, 0, responseBytes.Length);
            Console.WriteLine(request);
            Console.WriteLine(new string('=', 60));
        }
    }
}
