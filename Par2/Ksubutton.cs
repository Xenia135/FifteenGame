using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Par2
{
    //ComponentLibrary
    public class Ksubutton1 : Button
    {
        private StringFormat SF = new StringFormat();

        private bool MouseEntered = false;
        private bool MousePressed = false;


        public Ksubutton1()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            SF.Alignment = StringAlignment.Center;
            SF.LineAlignment = StringAlignment.Center;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graph = e.Graphics;
            graph.SmoothingMode = SmoothingMode.HighQuality;


            graph.Clear(Parent.BackColor);

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            // Рисуем доп. прямоугольник (Наша шторка)
            graph.DrawRectangle(new Pen(BackColor), rect);
            graph.FillRectangle(new SolidBrush(BackColor), rect);

            if (MouseEntered)
            {
                graph.DrawRectangle(new Pen(Color.Aqua), rect);
                graph.FillRectangle(new SolidBrush(Color.Blue), rect);
            }
            if (MousePressed)
            {
                graph.DrawRectangle(new Pen(Color.Aquamarine), rect);
                graph.FillRectangle(new SolidBrush(Color.Cyan), rect);
            }
            graph.DrawString(Text, Font, new SolidBrush(ForeColor), rect, SF);
        }


        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            MouseEntered = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            MouseEntered = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            MousePressed = true;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            MousePressed = false;
            Invalidate();
        }

    }
}