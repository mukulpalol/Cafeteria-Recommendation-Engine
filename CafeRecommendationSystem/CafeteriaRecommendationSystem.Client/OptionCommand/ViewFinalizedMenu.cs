﻿using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO.ResponseDTO;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace CafeteriaRecommendationSystem.Client.OptionCommand
{
    public class ViewFinalizedMenu : ICommand
    {
        private readonly NetworkStream _stream;

        public ViewFinalizedMenu(NetworkStream stream)
        {
            _stream = stream;
        }

        public void Execute(RoleEnum role)
        {
            try
            {
                SendViewFinalizedMenuRequest(role);
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

        private void SendViewFinalizedMenuRequest(RoleEnum role)
        {
            string optionRequest = $"option|{(int)role}|9";
            byte[] data = Encoding.ASCII.GetBytes(optionRequest);
            _stream.Write(data, 0, data.Length);
        }

        private void ReceiveAndDisplayServerResponse()
        {
            byte[] response = new byte[8192];
            int bytes = _stream.Read(response, 0, response.Length);
            string serverResponse = Encoding.ASCII.GetString(response, 0, bytes);

            if (serverResponse == "[]")
            {
                Console.WriteLine("Menu not finalized yet.");
            }
            else
            {
                var menuItems = JsonConvert.DeserializeObject<List<MenuItemResponseDTO>>(serverResponse);
                Console.WriteLine("Finalized Menu:\n\n");
                Console.WriteLine("Id\tName\tPrice\tType\tAvailability Status\tGeneral Sentiment\tSentiment Score\n");
                foreach (var item in menuItems)
                {
                    Console.WriteLine($"{item.Id}\t{item.Name}\t{item.Price}\t{item.Type}\t{item.Availability}\t{item.GeneralSentiment}\t{item.SentimentScore}\n");
                }
            }
        }
    }

}
