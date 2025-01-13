using BOOSE;

namespace ASE_Assignment;

/// <summary>
/// Represents a compound command (such as an if, while, or for loop) that corresponds to a conditional command.
/// </summary>
public class AppCompoundCommand : ConditionalCommand
{
    private ConditionalCommand correspondingCommand;

    /// <summary>
    /// Gets or sets the corresponding conditional command that this compound command is paired with.
    /// </summary>
    public ConditionalCommand CorrespondingCommand
    {
        get => this.correspondingCommand;
        set => this.correspondingCommand = value;
    }
}