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

    /// <summary>
    /// Sets the pen colour used when drawing on the canvas.
    /// </summary>
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
        _graphics.DrawLine(pen, Xpos, Ypos, x, y);
        Xpos = x;
        Ypos = y;
    }

    /// <summary>
    /// Draws a circle from the current position with the specified radius, filled or unfilled.
    /// </summary>
    /// <param name="radius">Radius of the circle drawn</param>
    /// <param name="filled">Bool representing if the circle should be filled</param>
    public override void Circle(int radius, bool filled)
    {
        var diameter = radius * 2;

        if (filled)
        {
            using SolidBrush brush = new SolidBrush((Color)PenColour);
            _graphics.FillEllipse(brush, this.Xpos, this.Ypos, diameter, diameter);
        }
        else
        {
            using Pen pen = new Pen((Color)PenColour);
            _graphics.DrawEllipse(pen, this.Xpos, this.Ypos, diameter, diameter);
        }
    }

    /// <summary>
    /// Draws a rectangle with the specified width and height, filled or unfilled.  
    /// </summary>
    /// <param name="width">Width of the rectangle</param>
    /// <param name="height">Height of the rectangle</param>
    /// <param name="filled">Bool representing if the rectangle should be filled</param>
    public override void Rect(int width, int height, bool filled)
    {
        if (filled)
        {
            using SolidBrush brush = new SolidBrush((Color)PenColour);
            _graphics.FillRectangle(brush, this.Xpos, this.Ypos, width, height);
        }
        else
        {
            using Pen pen = new Pen((Color)PenColour);
            _graphics.DrawRectangle(pen, this.Xpos, this.Ypos, width, height);
        }
    }
}