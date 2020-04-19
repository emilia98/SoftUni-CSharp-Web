using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ResponseFile
{
    class Startup
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
            byte[] fileContent = await File.ReadAllBytesAsync("cat.jpg");

            string headers =
                            "HTTP/1.0 200 OK" + NewLine
                            + "Server: SoftUniServer/1.0" + NewLine
                            + "Content-Type: image/jpeg" + NewLine
                            + $"Content-Length: {fileContent.Length}" + NewLine
                            + NewLine;
            byte[] headersBytes = Encoding.UTF8.GetBytes(headers);
            await networkStream.WriteAsync(headersBytes);
            await networkStream.WriteAsync(fileContent);
            Console.WriteLine(request);
            Console.WriteLine(new string('=', 60));
        }
    }
}
