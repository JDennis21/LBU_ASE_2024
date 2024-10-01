using BOOSE;

namespace ASE_Assignment
{
    public class PenColour : CommandThreeParameters
    {
        public override void Execute()
        {
            base.Execute();
            this.Canvas.SetColour(this.Paramsint[0], this.Paramsint[1], this.Paramsint[2]);
        }
    }
}