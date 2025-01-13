using BOOSE;

namespace ASE_Assignment;

/// <summary>
/// AppElse class extends BOOSE.Else to provide to simplify AppCommandFactory, rather that requiring Else to be called from the BOOSE CommandFactory. 
/// </summary>
public class AppElse : Else
{
    /// <summary>
    /// Default empty constructor for AppElse to be used by AppCommandFactory
    /// </summary>
    public AppElse()
    {

    }
}