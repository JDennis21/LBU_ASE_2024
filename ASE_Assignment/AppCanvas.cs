namespace ASE_Assignment;

using BOOSE;

public class AppCanvas : Canvas
{
    private readonly Graphics _graphics;
    private readonly Bitmap _drawingSurface;
    private Color _penColour;

    public override object PenColour { get => _penColour;  set => _penColour = (Color)value; }

    public AppCanvas(int width, int height)
    {
        _drawingSurface = new Bitmap(width, height);
        _graphics = Graphics.FromImage(_drawingSurface);
        Set(width, height);
    }

    public override void Set(int width, int height)
    {
        background_colour = Color.Black;
        Clear();
        Reset();
    }

    public override void Clear()
    {
        _graphics.Clear(background_colour);
    }

    public override void SetColour(int red, int green, int blue)
    {
        PenColour = Color.FromArgb(red, green, blue);
    }

    public override object getBitmap()
    {
        return _drawingSurface;
    }
}


