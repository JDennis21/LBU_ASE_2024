using BOOSE;

namespace ASE_Assignment;

/// <summary>
/// Represents poke operation within the application, inherits from <see cref="AppArray"/> and overrides functionality to perform compilation and execution
/// of the poke command.
/// </summary>
public class AppPoke : AppArray
{
    /// <summary>
    /// Compile the poke commands by processing array parameters.
    /// </summary>
    public override void Compile()
    {
        this.ProcessArrayParametersCompile(true);
    } 

    /// <summary>
    /// Executes the poke command by updating the value at the specified row and column.
    /// </summary>
    public override void Execute()
    {
        this.ProcessArrayParametersExecute(true);
    }
}