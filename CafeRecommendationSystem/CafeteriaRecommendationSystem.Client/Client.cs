using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client
{
    public class Client
    {
        private readonly TcpClient _client;
        private NetworkStream _stream;

        public Client(string ip, int port)
        {
            _client = new TcpClient(ip, port);
        }

        public async Task ConnectAsync()
        {
            await _client.ConnectAsync("127.0.0.1", 5000);
            _stream = _client.GetStream();
            Console.WriteLine("Client connected...");
        }

        public async Task<string> SendMessageAsync(string message)
        {
            var data = Encoding.ASCII.GetBytes(message);
            await _stream.WriteAsync(data, 0, data.Length);

            var buffer = new byte[1024];
            var bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);
            var response = Encoding.ASCII.GetString(buffer, 0, bytesRead);

            return response;
        }
    }
}
