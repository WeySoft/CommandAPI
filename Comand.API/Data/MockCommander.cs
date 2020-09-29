using System.Collections.Generic;
using Comand.API.Models;

namespace Comand.API.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands  = new List<Command>
            {
                new Command{Id=0, HowTo="Boli an egg", Line="Boil watter", Platform="Kettle & Pan"},
                new Command{Id=1, HowTo="Rösti", Line="Put Potato in Pan", Platform="Pan"},
                new Command{Id=2, HowTo="Salzkartoffel", Line="Put Potato in Kettle", Platform="Kettle"}
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command{Id=0, HowTo="Boli an egg", Line="Boil watter", Platform="Kettle & Pan"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}