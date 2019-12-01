using System;

namespace TicketManagement.Specs.Exceptions
{
    public class TargetMachineNotWorkingProperly : Exception
    {
        public TargetMachineNotWorkingProperly(string message) : base(message)
        {
        }
    }
}