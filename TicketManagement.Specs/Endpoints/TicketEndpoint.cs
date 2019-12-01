using RestSharp;
using TicketManagement.Application.Contracts.Commands;
using TicketManagement.Specs.Exceptions;

namespace TicketManagement.Specs.Endpoints
{
    public static class TicketEndpoint
    {
        private const string TicketingApiEndpoint = "http://localhost:7575";

        public static void SendTicket(RegisterTicket command)
        {
            var client = new RestClient(TicketingApiEndpoint);
            var request = new RestRequest("Ticket", Method.POST);
            request.AddJsonBody(command);
            var response = client.Execute(request);
            HandleRequestFailure(response);
        }

        private static void HandleRequestFailure(IRestResponse response)
        {
            if (!response.IsSuccessful)
                throw new TargetMachineNotWorkingProperly(response.ErrorMessage);
        }
    }
}