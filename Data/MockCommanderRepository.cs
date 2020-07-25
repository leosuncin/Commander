using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepository : ICommanderRepository
    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return new List<Command> {
                new Command { Id = 0, HowTo = "Boil an eggg", Line = "Boil water", Platform = "Kettle & pan" },
                new Command { Id = 1, HowTo = "Cut bread", Line = "Get a knife", Platform = "Knife & chopping board" },
                new Command { Id = 2, HowTo = "Make a cup of tea", Line = "Place a teabag in cup", Platform = "Kettle & cup" },
            };
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = id, HowTo = "Boil an eggg", Line = "Boil water", Platform = "Kettle & pan" };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}
