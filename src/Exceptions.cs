
using System;

namespace TextAdventure.Exceptions;

public class SaveException : Exception
{
    public SaveException(string message) : base(message) {}
}