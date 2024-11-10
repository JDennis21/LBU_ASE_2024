using BOOSE;

namespace ASE_Assignment
{
    /// <summary>
    /// Command to draw a rectangle on the canvas.
    /// </summary>
    /// <seealso cref="CommandOneParameter"/>
    public class Rect : CommandOneParameter
    {
        private int width;
        private int height;

        /// <summary>
        /// Initialises new instance of <see cref="Rect"/> with no parameters.
        /// </summary>
        public Rect()
        {
        }

        /// <summary>
        /// Initialises new instance of <see cref="Rect"/> using specified width and height.
        /// </summary>
        /// <param name="width">Width of rectangle to be created</param>
        /// <param name="height">Height of rectangle to be created</param>
        public Rect(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Calls <see cref="BOOSE.Command.Execute"/>, then draws a rectangle with specified width and height.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            width = Paramsint[0];
            height = Paramsint[1];
            Canvas.Rect(this.width, this.height, false);
        }

        /// <summary>
        /// Checks if the Rect command has been called with the correct amount of parameters.
        /// </summary>
        /// <param name="parameterList">String array to be checked to ensure the correct number of parameters has been passed.</param>
        /// <exception cref="CommandException">Thrown if the number of parameters is not 1.</exception>
        public override void CheckParameters(string[] parameterList)
        {
            if (parameterList.Length != 2)
                throw new CommandException("Incorrect amount of parameters provided to " + this.ToString());
        }
    }
}