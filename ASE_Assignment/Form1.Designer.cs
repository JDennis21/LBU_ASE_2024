namespace ASE_Assignment;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        button1 = new Button();
        pictureBox1 = new PictureBox();
        textBox1 = new TextBox();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new Point(47, 545);
        button1.Name = "button1";
        button1.Size = new Size(125, 51);
        button1.TabIndex = 0;
        button1.Text = "RUN";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // pictureBox1
        // 
        pictureBox1.BackColor = Color.Black;
        pictureBox1.Location = new Point(382, 55);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(656, 541);
        pictureBox1.TabIndex = 1;
        pictureBox1.TabStop = false;
        pictureBox1.Paint += pictureBox1_Paint;
        // 
        // textBox1
        // 
        textBox1.BorderStyle = BorderStyle.FixedSingle;
        textBox1.Location = new Point(12, 55);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(340, 468);
        textBox1.TabIndex = 2;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1058, 653);
        Controls.Add(textBox1);
        Controls.Add(pictureBox1);
        Controls.Add(button1);
        DoubleBuffered = true;
        Name = "Form1";
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button button1;
    private PictureBox pictureBox1;
    private TextBox textBox1;
}