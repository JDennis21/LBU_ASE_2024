﻿using BOOSE;
using Array = BOOSE.Array;

namespace ASE_Assignment
{
    /// <summary>
    /// Factory class for creating instances of ASE_Assignment and BOOSE commands.S
    /// </summary>
    public class AppCommandFactory : CommandFactory
    {
        /// <summary>
        /// Creates an instance of specified command based on commandType provided.
        /// </summary>
        /// <param name="commandType">String correlating to class constructor to be initialised. If commandType is not recognised <see cref="CommandFactory"/>
        /// is called to determine if the command exists within BOOSE library.</param>
        /// <returns>Returns ICommand object corresponding to the commandType</returns>
        public override ICommand MakeCommand(string commandType)
        {
            commandType = commandType.ToLower().Trim();

            return commandType switch
            {
                "circle" => new Circle(),
                "rect" => new Rect(),
                "moveto" => new MoveTo(),
                "pen" => new PenColour(),
                "write" => new WriteText(),
                "tri" => new Tri(),
                "int" => new AppInt(),
                "real" => new AppReal(),
                "array" => new AppArray(),
                "peek" => new AppPeek(),
                "poke" => new AppPoke(),
                "while" => new AppWhile(),
                "end" => new AppEnd(),
                "for" => new AppFor(),
                "if" => new AppIf(),
                "else" => new AppElse(),
                _ => base.MakeCommand(commandType)
            };
        }
    }
}