using Framework.Testing.Hosting.Core;
using Framework.Testing.Hosting.NetCoreHosting;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TicketManagement.Application.Contracts.Commands;
using TicketManagement.Specs.Constants;
using TicketManagement.Specs.Endpoints;

namespace TicketManagement.Specs.Steps
{
    [Binding]
    public class TicketingSteps
    {
        private readonly ScenarioContext _context;
        private readonly IStartableHost _startableHost;

        public TicketingSteps(ScenarioContext context)
        {
            _context = context;
            _startableHost = new DotNetCoreHost(new DotNetCoreHostOptions
            {
                Port = 7576,
                CsProjectPath = @"../../TicketManagement.Presentation.Rest/TicketManagement.Presentation.Rest.csproj"
            });
        }

        [Given(@"I have a request with the following information")]
        public void GivenIHaveARequestWithTheFollowingInformation(Table table)
        {
            _startableHost.Start();
            var ticket = table.CreateInstance<RegisterTicket>();
            _context.Add(TicketKeys.CreateTicketKey, ticket);
        }

        [When(@"I press send")]
        public void WhenIPressSend()
        {
            var ticket = _context.Get<RegisterTicket>(TicketKeys.CreateTicketKey);
            TicketEndpoint.SendTicket(ticket);
        }

        [Then(@"the ticket should be available in the ticket list")]
        public void ThenTheTicketShouldBeAvailableInTheTicketList()
        {
            _startableHost.Stop();
        }
    }
}