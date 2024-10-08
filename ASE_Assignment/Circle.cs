using BOOSE;

namespace ASE_Assignment
{
    public class Circle : CommandOneParameter
    {
        private int radius;

        public Circle()
        {
        }

        public Circle(Canvas c, int radius) : base(c)
        {
            this.radius = radius;
        }

        public override void Execute()
        {
            base.Execute();
            radius = Paramsint[0];
            Canvas.Circle(radius, false);
        }

        public override void CheckParameters(string[] parameterList)
        {
            if (parameterList.Length != 1)
                throw new CommandException("Incorrect amount of parameters in " + this.ToString());
        }
    }
}