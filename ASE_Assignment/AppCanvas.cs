namespace ASE_Assignment;

using BOOSE;

/// <summary>
/// Initialises drawing surface and provides methods for drawing and also manages the drawing surface.
/// </summary>
public class AppCanvas : Canvas
{
    private readonly Graphics _graphics;
    private readonly Bitmap _drawingSurface;
    private Color _penColour;

    /// <inheritdoc />
    public override object PenColour { get => _penColour; set => _penColour = (Color)value; }

    /// <summary>
    /// Initialises an instance of the AppCanvas class using the width and height provided.
    /// </summary>
    /// <param name="width">Width of the drawing surface</param>
    /// <param name="height">Height of the drawing surface</param>
    public AppCanvas(int width, int height)
    {
        _drawingSurface = new Bitmap(width, height);
        _graphics = Graphics.FromImage(_drawingSurface);
        Set(width, height);
    }

    /// <summary>
    /// Sets the default conditions of the canvas, such as background colour and pen colour.
    /// </summary>
    /// <param name="width">Width of the drawing surface</param>
    /// <param name="height">Height of the drawing surface</param>
    public override void Set(int width, int height)
    {
        background_colour = Color.Black;
        SetColour(255, 255, 255);
        Clear();
        Reset();
    }

    /// <summary>
    /// Clears the canvas by filling it with the current background colour.
    /// </summary>
    public override void Clear()
    {
        _graphics.Clear(background_colour);
    }

    /// <summary>
    /// Sets the pen colour using RGB values.
    /// </summary>
    /// <param name="red">Red value of pen colour</param>
    /// <param name="green">Green value of pen colour</param>
    /// <param name="blue">Blue value of pen colour</param>
    public override void SetColour(int red, int green, int blue)
    {
        PenColour = Color.FromArgb(red, green, blue);
    }

    /// <summary>
    /// Used to retrieve the bitmap of the AppCanvas drawing surface
    /// </summary>
    /// <returns>Object of the drawing surface</returns>
    public override object getBitmap()
    {
        return _drawingSurface;
    }

    /// <summary>
    /// Draws a line from the current position to the specified (x,y) coordinates and sets the current position to the (x,y) coordinates.
    /// </summary>
    /// <param name="x">X coordinate to draw to</param>
    /// <param name="y">Y coordinate to draw to</param>
    public override void DrawTo(int x, int y)
    {
        using Pen pen = new Pen((Color)PenColour);
        _graphics.DrawLine(pen, this.Xpos, this.Ypos, x, y);
        this.Xpos=x; 
        this.Ypos=y;
    }
}


