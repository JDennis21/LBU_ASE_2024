using BOOSE;

namespace ASE_Assignment
{
    public class MoveTo : CommandTwoParameters
    {
        public override void Execute()
        {
            base.Execute();
            Canvas.MoveTo(Paramsint[0], Paramsint[1]);
        }
    }
}
