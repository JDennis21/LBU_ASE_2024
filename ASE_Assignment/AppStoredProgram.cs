using BOOSE;

namespace ASE_Assignment;

/// <summary>
/// Extends the StoredProgram class within the BOOSE.dll to remove restrictions.
/// </summary>
public class AppStoredProgram : StoredProgram
{
    /// <summary>
    /// Constructor calls base constructor of the StoredProgram class within BOOSE with the canvas provided.
    /// </summary>
    /// <param name="canvas">Canvas to be passed to the stored program class.</param>
    public AppStoredProgram(ICanvas canvas) : base(canvas)
    {
        //
    }

    /// <summary>
    /// Overriden the base run method of StoredProgram to remove the restriction on execution cycles.
    /// </summary>
    /// <exception cref="StoredProgramException">Thrown if an error is caught whiles executing commands.</exception>
    public override void Run()
    {
        while (this.Commandsleft())
        {
            ICommand command = (ICommand)this.NextCommand();
            try
            {
                command.Execute();
            }
            catch (BOOSEException ex)
            {
                this.SyntaxOk = false;
                throw new StoredProgramException(ex.Message);
            }
        }
    }
}