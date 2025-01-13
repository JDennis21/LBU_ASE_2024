using BOOSE;

namespace ASE_Assignment;

/// <summary>
/// End command for if, while and for commands. This handles the termination of loops and conditional blocks.
/// </summary>
public class AppEnd : End
{
    /// <summary>
    /// Executes the end command logic, updating the program counter based on the loop type (if, while, or for).
    /// For if loops it simply returns, for while loops it returns to the line of the while, and for "for" loops it returns to the line after the loop is
    /// initiated.
    /// </summary>
    /// <exception cref="CommandException"></exception>
    public override void Execute()
    {
        //If CorrespondingCommand is AppWhile set the program counter to the line of the AppWhile command
        if (this.CorrespondingCommand is AppWhile)
            this.Program.PC = this.CorrespondingCommand.LineNumber - 1;
        //Else if CorrespondingCommand is AppFor set the program counter to the line after the AppFor command
        else if (this.CorrespondingCommand is AppFor)
        {
            For correspondingCommand = (For)this.CorrespondingCommand;
            Evaluation loopVariable = correspondingCommand.LoopControlV;

            //Next value of the loop after the step has been added
            int nextValue = loopVariable.Value + correspondingCommand.Step;
            this.Program.UpdateVariable(loopVariable.VarName, nextValue);

            //Checks if the loop will run infinitely
            if (correspondingCommand.From > correspondingCommand.To && correspondingCommand.Step > 0 || correspondingCommand.From < correspondingCommand.To && correspondingCommand.Step < 0)
                throw new CommandException("Loop starting point and step size are incompatible, at line: " + this.program.PC);
            if (correspondingCommand.Step == 0)
                throw new CommandException("Infinite loop caused by step size of zero, at line: " + this.program.PC);

            //Check if the loop has completed, first case represents ascending step value, whereas second represents descending step value
            bool conditionMet;
            if (correspondingCommand.Step > 0)
            {
                conditionMet = nextValue >= correspondingCommand.To;
            }
            else
            {
                conditionMet = nextValue <= correspondingCommand.To;
            }
            if (conditionMet)
                return;
            //Return to the line after the for loop
            this.Program.PC = correspondingCommand.LineNumber;
        }
        //Else if CorrespondingCommand is AppIf return
        if (this.CorrespondingCommand is AppIf)
        {
            return;
        }
    }
}