using System.Collections.Generic;
using sandwicherie.models;

namespace sandwicherie.core.interfaces
{
    public interface IParser
    {
        ParsedCommand ParseCommand(string command);
    }
}