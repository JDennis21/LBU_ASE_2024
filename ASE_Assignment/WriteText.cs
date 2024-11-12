using BOOSE;

namespace ASE_Assignment;

/// <summary>
/// Command to write a string on the canvas.
/// </summary>
public class WriteText : CommandOneParameter
{
    private string text;

    /// <summary>
    /// Initialises new instance of <see cref="WriteText"/> with no parameters.
    /// </summary>
    public WriteText()
    {
    }

    /// <summary>
    /// Initialises new instance of <see cref="WriteText"/> with a specified canvas and string.
    /// </summary>
    /// <param name="text"></param>
    public WriteText(string text)
    {
        this.text = text;
    }

    /// <summary>
    /// Calls <see cref="BOOSE.Command.Execute"/>, then writes text using the specified string. 
    /// </summary>
    public override void Execute()
    {
        base.Execute();
        text = parameters[0];
        Canvas.WriteText(text);
    }

    /// <summary>
    /// Checks if <see cref="WriteText"/> has been called with the correct amount of parameters.
    /// </summary>
    /// <param name="parameterList">String array to be checked to ensure the correct number of parameters has been passed.</param>
    /// <exception cref="CommandException">Thrown if the number of parameters is not 1.</exception>
    public override void CheckParameters(string[] parameterList)
    {
        if (parameterList.Length != 1)
            throw new CommandException("Incorrect amount of parameters in " + this.ToString());
    }
}