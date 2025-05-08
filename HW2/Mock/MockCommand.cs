using HW2.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW2.Mock
{
    public class MockCommand : ICommand
    {
        public string State { get; private set; }

        public void Execute()
        {
            State = "Executed";
        }

        public void UnExecute()
        {
            State = "UnExecuted";
        }
    }
}
