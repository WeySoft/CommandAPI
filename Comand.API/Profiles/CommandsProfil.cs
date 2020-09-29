using AutoMapper;
using Comand.API.Dtos;
using Comand.API.Models;

namespace Comand.API.Profiels
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //Source --> Target
            CreateMap<Command, CommandRead>();

            CreateMap<CommandCreate, Command>();

            CreateMap<CommandUpdate, Command>();

            CreateMap<Command, CommandUpdate>();
        }
    }
}