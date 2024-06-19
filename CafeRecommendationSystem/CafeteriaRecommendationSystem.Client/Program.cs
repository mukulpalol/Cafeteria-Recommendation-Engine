using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.DAL.Models;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("127.0.0.1", 8888);
            NetworkStream stream = client.GetStream();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            string loginRequest = $"login|{email}|{password}";
            byte[] loginRequestBytes = Encoding.ASCII.GetBytes(loginRequest);
            stream.Write(loginRequestBytes, 0, loginRequestBytes.Length);

            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string loginResponse = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            string[] responseParts = loginResponse.Split('|');
            string loginStatus = responseParts[0];

            if (loginStatus == "Login successful")
            {
                int role = int.Parse(responseParts[1]);
                ShowOptions(role, stream);
            }
            else
            {
                Console.WriteLine("Login failed");
            }

            client.Close();
        }
        private static void ShowOptions(int role, NetworkStream stream)
        {
            string optionRequest;
            byte[] optionRequestBytes;

            while (true)
            {
                if (role == (int)RoleEnum.Admin)
                {
                    Console.WriteLine("1. Add menu item");
                    Console.WriteLine("2. Update menu item");
                    Console.WriteLine("3. View menu");
                    Console.WriteLine("0. Exit");
                }
                else if (role == (int)RoleEnum.Chef)
                {
                    Console.WriteLine("1. Role out menu for next day");
                    Console.WriteLine("2. Finalise menu for next day");
                    Console.WriteLine("3. Generate monthly report");
                    Console.WriteLine("0. Exit");
                }
                else if (role == (int)RoleEnum.Employee)
                {
                    Console.WriteLine("1. Submit feedback on food item");
                    Console.WriteLine("2. Vote for tomorrow's food selection");
                    Console.WriteLine("3. View Notifications");
                    Console.WriteLine("4. View Menu");
                    Console.WriteLine("0. Exit");
                }

                string option = Console.ReadLine();
                if (option == "0")
                {
                    break;
                }

                if (role == (int)RoleEnum.Admin && option == "1")
                {
                    MenuItem menuItem = new MenuItem();
                    Console.Write("Enter menu item name: ");
                    menuItem.Name = Console.ReadLine();
                    Console.Write("Enter menu item price: ");
                    menuItem.Price = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter menu type: ");
                    menuItem.TypeId = int.Parse(Console.ReadLine());
                    menuItem.AvailabilityStatusId = (int)AvailabilityStatusEnum.Available;

                    string menuItemJson = JsonConvert.SerializeObject(menuItem);
                    optionRequest = $"option|{role}|{option}|{menuItemJson}";
                    optionRequestBytes = Encoding.ASCII.GetBytes(optionRequest);
                    stream.Write(optionRequestBytes, 0, optionRequestBytes.Length);
                }
                else
                {
                    optionRequest = $"option|{role}|{option}";
                    optionRequestBytes = Encoding.ASCII.GetBytes(optionRequest);
                    stream.Write(optionRequestBytes, 0, optionRequestBytes.Length);
                }
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                Console.WriteLine(response);
            }
        }        
    }
}