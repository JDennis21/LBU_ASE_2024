using BOOSE;

namespace ASE_Assignment
{
    /// <summary>
    /// Command which moves the pen to specified (x,y) coordinates.
    /// </summary>
    /// <seealso cref="CommandTwoParameters"/>
    public class MoveTo : CommandTwoParameters
    {
        /// <summary>
        /// Calls <see cref="BOOSE.Command.Execute"/>, then moves the pen to specified (x,y) coordinates.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            Canvas.MoveTo(Paramsint[0], Paramsint[1]);
        }
    }
}
