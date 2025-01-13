using BOOSE;

namespace ASE_Assignment;

/// <summary>
/// 
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
    /// 
    /// </summary>
    /// <exception cref="StoredProgramException"></exception>
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