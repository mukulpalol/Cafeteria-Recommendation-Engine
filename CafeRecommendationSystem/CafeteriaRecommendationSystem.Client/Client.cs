using CafeteriaRecommendationSystem.Common;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client
{
    public class Client
    {
        private static TcpClient client;
        private static NetworkStream stream;

        static void Main(string[] args)
        {
            try
            {
                client = new TcpClient("127.0.0.1", 8888);
                stream = client.GetStream();

                AuthenticateUser();

                RoleEnum role;
                int userId;
                (role, userId) = ReceiveAuthenticatesUserResponse();
                IMenu menu = MenuFactory.CreateMenu(role, userId, stream);

                while (true)
                {
                    menu.DisplayMenu();
                    Console.Write("\nEnter a choice: ");
                    int option = int.Parse(Console.ReadLine());
                    ICommand command = menu.GetCommand(option);

                    if (command == null) break;

                    command.Execute(role);
                }

                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void AuthenticateUser()
        {
            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            string loginRequest = "login|" + email + "|" + password;
            byte[] data = Encoding.ASCII.GetBytes(loginRequest);
            stream.Write(data, 0, data.Length);
        }

        static (RoleEnum, int) ReceiveAuthenticatesUserResponse()
        {
            byte[] roleData = new byte[256];
            int bytes = stream.Read(roleData, 0, roleData.Length);
            var response = Encoding.ASCII.GetString(roleData, 0, bytes);
            string[] parts = response.Split('|');
            var role = (RoleEnum)int.Parse(parts[1]);
            var userId = int.Parse(parts[2]);
            return (role, userId);
        }

    }
}