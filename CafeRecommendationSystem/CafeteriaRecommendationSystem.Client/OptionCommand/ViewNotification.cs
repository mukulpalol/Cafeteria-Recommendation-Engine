using CafeteriaRecommendationSystem.Common;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    public class ViewNotification : ICommand
    {
        private readonly NetworkStream _stream;
        private readonly int _userId;

        public ViewNotification(int userId, NetworkStream stream)
        {
            _userId = userId;
            _stream = stream;
        }

        public void Execute(RoleEnum role)
        {
            try
            {
                SendViewNotificationRequest(role);
                ReceiveAndDisplayServerResponse();
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Network error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void SendViewNotificationRequest(RoleEnum role)
        {
            string optionRequest = $"option|{(int)role}|2|{_userId}";
            byte[] data = Encoding.ASCII.GetBytes(optionRequest);
            _stream.Write(data, 0, data.Length);
        }

        private void ReceiveAndDisplayServerResponse()
        {
            byte[] response = new byte[8192];
            int bytes = _stream.Read(response, 0, response.Length);
            string serverResponse = Encoding.ASCII.GetString(response, 0, bytes);
            Console.WriteLine($"\nNotifications:\n\n{serverResponse}\n");
        }
    }

}
