using CafeteriaRecommendationSystem.Common;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    internal class FinaliseMenuCommand : ICommand
    {
        private readonly NetworkStream _stream;
        public FinaliseMenuCommand(NetworkStream stream)
        {
            _stream = stream;
        }
        public void Execute(RoleEnum role)
        {
            Console.Write("Enter all menu item id for finalising menu (comma seperated): ");
            string menuItemIdsInput = Console.ReadLine();
            var menuItemIdList = menuItemIdsInput.Split(',').Select(int.Parse).ToArray().ToList();

            string finaliseMenuJson = JsonConvert.SerializeObject(menuItemIdList);
            string optionRequest = $"option|{(int)role}|3|{finaliseMenuJson}";
            byte[] data = Encoding.ASCII.GetBytes(optionRequest);
            _stream.Write(data, 0, data.Length);

            byte[] response = new byte[8192];
            int bytes = _stream.Read(response, 0, response.Length);
            string serverResponse = Encoding.ASCII.GetString(response, 0, bytes);
            Console.WriteLine("\nServer response: " + serverResponse);
        }
    }
}
