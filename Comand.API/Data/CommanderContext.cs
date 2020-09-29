using System.Collections.Generic;
using Comand.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Comand.API.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> options) : base(options)
        {
        }

        public DbSet<Command> Commands { get; set; }
    }
}