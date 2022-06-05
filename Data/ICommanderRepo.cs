using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        Command GetCommandById(int id);
        IEnumerable<Command> GetAllCommands();

        void CreateCommand(Command cmd);

        void UpdateCommand(Command cmd);

        void DeleteCommand(Command cmd);

        bool SaveChanges();
    }

}
