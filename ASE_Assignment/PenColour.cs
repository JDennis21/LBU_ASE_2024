using BOOSE;

namespace ASE_Assignment
{
    /// <summary>
    /// Command which sets the pen colour to draw with using RGB values.
    /// </summary>
    /// <seealso cref="CommandThreeParameters"/>
    public class PenColour : CommandThreeParameters
    {
        /// <summary>
        /// Calls <see cref="BOOSE.Command.Execute"/>, then sets the pen colour to the specified RGB values.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            Canvas.SetColour(Paramsint[0], Paramsint[1], Paramsint[2]);
        }
    }
}