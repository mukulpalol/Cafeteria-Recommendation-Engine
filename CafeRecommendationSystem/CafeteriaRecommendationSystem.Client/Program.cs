using CafeteriaRecommendationSystem.Common;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client
{
    public class Program
    {
        private static TcpClient client;
        private static NetworkStream stream;

        static void Main(string[] args)
        {
            try
            {
                InitializeConnection("127.0.0.1", 8888);

                AuthenticateUser();

                var (role, userId) = ReceiveAuthenticatesUserResponse();
                IMenu menu = MenuFactory.CreateMenu(role, userId, stream);

                while (true)
                {
                    try
                    {
                        if (!DisplayMenuAndExecuteCommand(menu, role))
                        {
                            break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid option.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred while executing the command: {ex.Message}");
                    }
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Socket error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                DisposeResources();
            }
        }

        static void InitializeConnection(string address, int port)
        {
            client = new TcpClient(address, port);
            stream = client.GetStream();
        }

        static bool DisplayMenuAndExecuteCommand(IMenu menu, RoleEnum role)
        {
            Console.WriteLine();
            menu.DisplayMenu();
            Console.Write("\nEnter a choice: ");
            if (int.TryParse(Console.ReadLine(), out int option))
            {
                if (option == 0)
                {
                    return false;
                }

                ICommand command = menu.GetCommand(option);
                command?.Execute(role);
            }
            else
            {
                throw new FormatException();
            }
            return true;
        }

        static void DisposeResources()
        {
            if (stream != null)
            {
                stream.Close();
                stream = null;
            }
            if (client != null)
            {
                client.Close();
                client = null;
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