namespace ASE_Assignment
{

    using BOOSE;
    public class CommandFactory : BOOSE.CommandFactory
    {
        public override ICommand MakeCommand(string commandType)
        {
            commandType = commandType.ToLower().Trim();
            switch (commandType)
            {
                case "moveto":
                    return (ICommand) new MoveTo();
                case "drawto":
                    return (ICommand) new DrawTo();
                case "circle":
                    return (ICommand) new Circle();
                case "rect":
                    return (ICommand) new Rect();
                case "pen":
                    return (ICommand) new PenColour();
                case "eval":
                    return (ICommand) new Evaluation();
                case "if":
                    return (ICommand) new If();
                case "end":
                    return (ICommand) new End();
                case "else":
                    return (ICommand) new Else();
                case "while":
                    return (ICommand) new While();
                case "for":
                    return (ICommand) new For();
                case "int":
                    return (ICommand) new Int();
                case "real":
                    return (ICommand) new Real();
                case "write":
                    return (ICommand) new Write();
                case "array":
                    return (ICommand) new Array();
                case "poke":
                    return (ICommand) new Poke();
                case "peek":
                    return (ICommand) new Peek();
                case "cast":
                    return (ICommand) new Cast();
                case "method":
                    return (ICommand) new Method();
                case "call":
                    return (ICommand) new Call();
                default:
                    throw new FactoryException("No such command '" + commandType + "'");
            }
        }
    }
}