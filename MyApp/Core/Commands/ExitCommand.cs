using System;
using MyApp.Core.Commands.Interface;

namespace MyApp.Core.Commands
{
    public class ExitCommand : ICommand
    {
        public string Execute(string[] inputArgs)
        {
            Environment.Exit(Environment.ExitCode);
            return "Bye Man! See ypu soon :) Have I a nice day.";
        }
    }
}