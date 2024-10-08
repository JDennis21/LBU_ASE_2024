namespace ASE_Assignment
{

    using BOOSE;
    /// <summary>
    /// 
    /// </summary>
    public class CommandFactory : BOOSE.CommandFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandType"></param>
        /// <returns></returns>
        /// <exception cref="FactoryException"></exception>
        public override ICommand MakeCommand(string commandType)
        {
            commandType = commandType.ToLower().Trim();
            return commandType switch
            {
                "moveto" => new MoveTo(),
                "drawto" => new DrawTo(),
                "circle" => new Circle(),
                "rect" => new Rect(),
                "pen" => new PenColour(),
                "eval" => new Evaluation(),
                "if" => new If(),
                "end" => new End(),
                "else" => new Else(),
                "while" => new While(),
                "for" => new For(),
                "int" => new Int(),
                "real" => new Real(),
                "write" => new Write(),
                "array" => new Array(),
                "poke" => new Poke(),
                "peek" => new Peek(),
                "cast" => new Cast(),
                "method" => new Method(),
                "call" => new Call(),
                _ => throw new FactoryException("Command does not exist")
            };
        }
    }
}