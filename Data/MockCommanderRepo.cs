using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command{Id=0, HowTo="Cold shutdown", Line="shift + shutdown", Platform="Windows"},
                new Command{Id=1, HowTo="copy a file", Line="cp file directory/", Platform="Linux"},
                new Command{Id=2, HowTo="list all containers", Line="docker ps -a", Platform="Docker"}
            };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command{Id=0, HowTo="Cold shutdown", Line="shift + shutdown", Platform="Windows"};
        }
    }
}