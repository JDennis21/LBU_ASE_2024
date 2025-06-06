﻿namespace ASE_Assignment;

using BOOSE;
using System.Drawing;

/// <summary>
/// Initialises drawing surface and provides methods for drawing and also manages the drawing surface.
/// </summary>
public class AppCanvas : ICanvas
{
    private Graphics _graphics;
    private Bitmap _drawingSurface;
    private Color _penColour;
    private Color _backgroundColour;

    private int _surfaceWidth, _surfaceHeight;

    /// <summary>
    /// Sets the pen colour used when drawing on the canvas.
    /// </summary>
    public object PenColour { get => _penColour; set => _penColour = (Color)value; }

    /// <summary>
    /// The current X position of the pen.
    /// </summary>
    public int Xpos { get; set; }

    /// <summary>
    /// The current Y position of the pen.
    /// </summary>
    public int Ypos { get; set; }

    /// <summary>
    /// Initialises an instance of the AppCanvas class using the width and height provided.
    /// </summary>
    /// <param name="width">Width of the drawing surface</param>
    /// <param name="height">Height of the drawing surface</param>
    /// <example>
    /// <code>
    /// appCanvas = new AppCanvas(pictureBox1.Width, pictureBox1.Height);
    /// </code>
    /// </example>
    public AppCanvas(int width, int height)
    {
        Set(width, height);
    }

    /// <summary>
    /// Initialises then sets the default conditions of the canvas, such as background colour and pen colour.
    /// </summary>
    /// <param name="width">Width of the drawing surface</param>
    /// <param name="height">Height of the drawing surface</param>
    /// <example>
    /// <code>
    /// appCanvas.Set(width, height);
    /// </code>
    /// </example>
    public void Set(int width, int height) 
    {
        _surfaceWidth = width;
        _surfaceHeight = height;

        _drawingSurface = new Bitmap(width, height);
        _graphics = Graphics.FromImage(_drawingSurface);
        _backgroundColour = Color.Black;
        SetColour(255, 255, 255);
    }

    /// <summary>
    /// Clears the canvas by filling it with the current background colour.
    /// </summary>
    /// <example>
    /// <code>
    /// appCanvas.Clear();
    /// </code>
    /// </example>
    public void Clear()
    {
        _graphics.Clear(_backgroundColour);
    }

    /// <summary>
    /// Resets the pen position to (x,y) coordinates (0,0).
    /// </summary>
    public void Reset()
    {
        this.Xpos = 0;
        this.Ypos = 0;
    }

    /// <summary>
    /// Sets the pen colour using RGB values.
    /// </summary>
    /// <param name="red">Red value of pen colour</param>
    /// <param name="green">Green value of pen colour</param>
    /// <param name="blue">Blue value of pen colour</param>
    /// <example>
    /// <code>
    /// appCanvas.SetColour(255, 255, 255);
    /// </code>
    /// </example>
    public void SetColour(int red, int green, int blue)
    {
        PenColour = Color.FromArgb(red, green, blue);
    }

    /// <summary>
    /// Used to retrieve the bitmap of the AppCanvas drawing surface
    /// </summary>
    /// <returns>Object of the drawing surface</returns>
    /// <example>
    /// <code>
    /// Bitmap updatedBitmap = (Bitmap)appCanvas.getBitmap();
    /// </code>
    /// </example>
    public object getBitmap()
    {
        return _drawingSurface;
    }

    /// <summary>
    /// Checks if parameters given are within drawing surface bounds and throws <see cref="CommandException"/> if not.
    /// </summary>
    /// <param name="x">X position to be checked if within bounds.</param>
    /// <param name="y">Y position to be checked if within bounds.</param>
    /// <exception cref="CommandException">Thrown if X or Y provided are out of bounds.</exception>
    public void CheckWithinBounds(int x, int y)
    { 
        if (0 > x || x > this._surfaceWidth || 0 > y || y > this._surfaceHeight) 
            throw new CommandException("Location (" + x + "," + y + ") is out of bounds.");
    }

    /// <summary>
    /// Moves pen position to given (x,y) coordinate.
    /// </summary>
    /// <param name="x">X position to move to.</param>
    /// <param name="y">Y position to move to.</param>
    /// <example>
    /// <code>
    /// appCanvas.MoveTo(100, 100);
    /// </code>
    /// </example>
    public void MoveTo(int x, int y)
    {
        CheckWithinBounds(x, y);
        this.Xpos = x;
        this.Ypos = y;
    }

    /// <summary>
    /// Draws a line from the current position to the specified (x,y) coordinates and sets the current position to the (x,y) coordinates.
    /// </summary>
    /// <param name="x">X coordinate to draw to</param>
    /// <param name="y">Y coordinate to draw to</param>
    /// <exception cref="CommandException">Thrown if the length of the line to be drawn will be zero</exception>
    /// <example>
    /// <code>
    /// appCanvas.DrawTo(100, 100);
    /// </code>
    /// </example>
    public void DrawTo(int x, int y)
    {
        CheckWithinBounds(x, y);

        if (this.Xpos == x && this.Ypos == y)
        {
            throw new BOOSEException("Unable to draw line with a length of zero");
        }

        using Pen pen = new Pen((Color)PenColour);
        _graphics.DrawLine(pen, this.Xpos, this.Ypos, x, y);
        Xpos = x;
        Ypos = y;
    }

    /// <summary>
    /// Draws a circle from the current position with the specified radius, filled or unfilled.
    /// </summary>
    /// <param name="radius">Radius of the circle drawn</param>
    /// <param name="filled">Bool representing if the circle should be filled</param>
    /// <exception cref="CommandException">Thrown if radius provided is less than or equal to zero</exception>
    /// <example>
    /// <code>
    /// appCanvas.Circle(100, true);
    /// </code>
    /// </example>
    public void Circle(int radius, bool filled)
    {
        if (radius <= 0)
        {
            throw new CommandException("Unable to draw circle of size " + radius);
        }

        var diameter = radius * 2;

        if (filled)
        {
            using SolidBrush brush = new SolidBrush((Color)PenColour);
            _graphics.FillEllipse(brush, this.Xpos - radius, this.Ypos - radius, diameter, diameter);
        }
        else
        {
            using Pen pen = new Pen((Color)PenColour);
            _graphics.DrawEllipse(pen, this.Xpos - radius, this.Ypos - radius, diameter, diameter);
        }
    }

    /// <summary>
    /// Draws a rectangle with the specified width and height, filled or unfilled.  
    /// </summary>
    /// <param name="width">Width of the rectangle</param>
    /// <param name="height">Height of the rectangle</param>
    /// <param name="filled">Bool representing if the rectangle should be filled</param>
    /// <exception cref="CommandException">Thrown if either width or height are less than or equal to 0</exception>
    /// <example>
    /// <code>
    /// appCanvas.Rect(width, height, true);
    /// </code>
    /// </example>
    public void Rect(int width, int height, bool filled)
    {
        if (0 >= width || height <= 0 )
        {
            throw new CommandException("Unable to draw rectangle with side length of zero or less, rect(" + width + "," + height + ")");
        }

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

    /// <summary>
    /// Draws a triangle using the specified width and height.
    /// </summary>
    /// <param name="width">Width used to draw triangle</param>
    /// <param name="height">Height used to draw triangle</param>
    /// <exception cref="CommandException">Thrown if either width or height are less than or equal to 0</exception>
    /// <example>
    /// <code>
    /// appCanvas.Tri(width, height);
    /// </code>
    /// </example>
    public void Tri(int width, int height)
    {
        if (0 >= width || height <= 0 )
        {
            throw new CommandException("Unable to draw triangle with side length of zero or less, tri(" + width + "," + height + ")");
        }

        Point top = new Point(this.Xpos + width / 2, this.Ypos);
        Point right = new Point(this.Xpos + width, this.Ypos + height);
        Point left = new Point(this.Xpos, this.Ypos + height);

        using Pen pen = new Pen((Color)PenColour);
        _graphics.DrawPolygon(pen, new Point[] {top, right, left});
    
    }

    /// <summary>
    /// Writes text on the canvas using the provided <see cref="string"/>.
    /// </summary>
    /// <param name="text">Text to be written on the canvas</param>
    /// <exception cref="CommandException">Thrown if the string provided has a length of zero or less</exception>
    /// <example>
    /// <code>
    /// appCanvas.WriteText("hello");
    /// </code>
    /// </example>
    public void WriteText(string text)
    {
        if (text.Length <= 0)
        {
            throw new CommandException("Unable to write text with length: " + text.Length);
        }
        using SolidBrush brush = new SolidBrush((Color)PenColour);
        Font arial = new Font("Arial", 20, FontStyle.Regular);
        _graphics.DrawString(text, arial, brush, this.Xpos, this.Ypos);
    }
}