using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        Command GetCommandById(int id);
        IEnumerable<Command> GetAllCommands();
    }

}
