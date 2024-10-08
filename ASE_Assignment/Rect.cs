using BOOSE;

namespace ASE_Assignment
{
    public class Rect : CommandOneParameter
    {
        private int width;
        private int height;

        public Rect()
        {
        }
        public Rect(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public override void Execute()
        {
            base.Execute();
            width = Paramsint[0];
            height = Paramsint[1];
            Canvas.Rect(Paramsint[0], Paramsint[1], false);
        }

        public override void CheckParameters(string[] parameterList)
        {
            if (parameterList.Length != 2)
                throw new CommandException("Incorrect amount of parameters provided to " + this.ToString());
        }
    }
}