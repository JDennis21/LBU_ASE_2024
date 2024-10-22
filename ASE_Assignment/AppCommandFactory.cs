using BOOSE;

namespace ASE_Assignment
{
    public class AppCommandFactory : BOOSE.CommandFactory
    {
        public override ICommand MakeCommand(string commandType)
        {
            commandType = commandType.ToLower().Trim();

            return commandType switch
            {
                "circle" => new Circle(),
                "rect" => new Rect(),
                "moveto" => new MoveTo(),
                "pen" => new PenColour(),
                _ => base.MakeCommand(commandType)
            };
        }
    }
}