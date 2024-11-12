using BOOSE;

namespace ASE_Assignment
{
    /// <summary>
    /// Command to draw a circle on the canvas.
    /// </summary>
    public class Circle : CommandOneParameter
    {
        private int radius;

        /// <summary>
        /// Initialises new instance of <see cref="Circle"/> with no parameters.
        /// </summary>
        public Circle()
        {
        }

        /// <summary>
        /// Initialises new instance of <see cref="Circle"/> with a specified canvas and radius.
        /// </summary>
        /// <param name="radius">The radius of the circle that will be drawn.</param>
        public Circle(int radius)
        {
            this.radius = radius;
        }

        /// <summary>
        /// Calls <see cref="BOOSE.Command.Execute"/>, then draws a circle with specified radius. 
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            radius = Paramsint[0];
            Canvas.Circle(radius, false);
        }

        /// <summary>
        /// Checks if Circle command has been called with the correct amount of parameters.
        /// </summary>
        /// <param name="parameterList">String array to be checked to ensure the correct number of parameters has been passed.</param>
        /// <exception cref="CommandException">Thrown if the number of parameters is not 1.</exception>
        public override void CheckParameters(string[] parameterList)
        {
            if (parameterList.Length != 1)
                throw new CommandException("Incorrect amount of parameters in " + this.ToString());
        }
    }
}