using BOOSE;

namespace ASE_Assignment;

/// <summary>
/// Command to draw a triangle on the canvas.
/// </summary>
public class Tri : CommandTwoParameters
{
    private int width;
    private int height;

    /// <summary>
    /// Initialises a new instance of <see cref="AppCanvas.Tri"/> using no parameters.
    /// </summary>
    public Tri()
    {

    }

    /// <summary>
    /// Initialises a new instance of <see cref="AppCanvas.Tri"/> using a specified width and height.
    /// </summary>
    /// <param name="width">Width to be used to draw triangle</param>
    /// <param name="height">Height to be used to draw triangle</param>
    public Tri(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    /// <summary>
    /// Calls <see cref="BOOSE.Command.Execute"/>, then draws a triangle using specified width and height.
    /// </summary> 
    public override void Execute()
    {
        base.Execute();
        width = paramsint[0];
        height = paramsint[1];
        Canvas.Tri(width, height);
    }

    /// <summary>
    /// Checks if the <see cref="AppCanvas.Tri"/> command has been called with the correct amount of parameters.
    /// </summary>
    /// <param name="parameterList">String array to be checked to ensure the correct number of parameters has been passed.</param>
    /// <exception cref="CommandException">Thrown if the number of parameters is not 2.</exception>
    public override void CheckParameters(string[] parameterList)
    {
        if (parameterList.Length != 2)
            throw new CommandException("Incorrect amount of parameters provided to " + this.ToString());
    }
}