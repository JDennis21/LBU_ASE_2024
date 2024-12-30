using BOOSE;

namespace ASE_Assignment;

/// <summary>
/// Represents peek operation within the application, inherits from <see cref="AppArray"/> and overrides functionality to perform compilation and execution
/// of the peek command.
/// </summary>
public class AppPeek : AppArray
{
    /// <summary>
    /// Compiles the peek command by processing the provided parameters.
    /// </summary>
    public override void Compile()
    {
        this.ProcessArrayParametersCompile(false);
    } 

    /// <summary>
    /// Executes the array command by retrieving the variable value based on the provided parameters.
    /// </summary>
    /// <exception cref="CommandException">Thrown if an unknown variable type is encountered.</exception>
    public override void Execute()
    {
        this.ProcessArrayParametersExecute(false);
        switch (this.variableType)
        {
            case "int":
                this.Program.UpdateVariable(this.peekValue, this.valueInt);
                break;
            case "real":
                this.Program.UpdateVariable(this.peekValue, this.valueReal);
                break;
            default:
                throw new CommandException("Variable type should be int or real");
        }
    }
}