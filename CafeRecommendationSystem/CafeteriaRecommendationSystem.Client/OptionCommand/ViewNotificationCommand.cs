﻿using CafeteriaRecommendationSystem.Common;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    public class ViewNotificationCommand : ICommand
    {
        private readonly NetworkStream _stream;
        private readonly int _userId;
        public ViewNotificationCommand(int userId, NetworkStream stream)
        {
            _userId = userId;
            _stream = stream;
        }
        public void Execute(RoleEnum role)
        {
            string optionRequest = $"option|{(int)role}|2|{_userId}";
            byte[] data = Encoding.ASCII.GetBytes(optionRequest);
            _stream.Write(data, 0, data.Length);

            byte[] response = new byte[1024];
            int bytes = _stream.Read(response, 0, response.Length);
            string serverResponse = Encoding.ASCII.GetString(response, 0, bytes);
            Console.WriteLine(serverResponse);
        }
    }
}
