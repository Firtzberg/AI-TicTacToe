using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TicTacToeControl
{
    /// <summary>
    /// Cell in Tic-Tac-Toe Board
    /// </summary>
    [DefaultEvent("MarkChanged")]
    [DefaultProperty("Mark")]
    public partial class TicTacToeSquare : Control
    {
        /// <summary>
        /// Symbol of Square (O, X or None)
        /// </summary>
        private Symbol mark;
        [Description("Occurs when the mark changes.")]
        [Category("Property Changed")]
        public event EventHandler MarkChanged;

        public TicTacToeSquare()
        {
            InitializeComponent();
            mark = Symbol.None;
        }

        /// <summary>
        /// Raises the MarkChanged EventHandler.
        /// </summary>
        /// <param name="e">An System.EventArgs that contains the event data.</param>
        protected virtual void OnMarkChanged(EventArgs e)
        {
            EventHandler eh = this.MarkChanged;
            if (eh != null)
                eh(this, e);
        }

        /// <summary>
        /// Current mark of square
        /// </summary>
        [Description("The Mark to be displayed."),
        Category("Appearance")]
        public Symbol Mark
        {
            get { return mark; }
            set
            {
                if (mark == value) return;
                mark = value;
                this.OnMarkChanged(EventArgs.Empty);
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            // No mark
            if (mark == Symbol.None)
                return;
            Pen pen = new Pen(this.ForeColor, 3);
            // X
            if (mark == Symbol.X)
            {
                pe.Graphics.DrawLine(pen, new Point(this.Width / 10, this.Height / 10),
                    new Point(this.Width - this.Width / 10, this.Height - this.Height / 10));
                pe.Graphics.DrawLine(pen, new Point(this.Width - this.Width / 10, this.Height / 10),
                    new Point(this.Width / 10, this.Height - this.Height / 10));
            }
            else // O
            {
                pe.Graphics.DrawEllipse(pen,
                    new Rectangle(new Point(this.Width / 10, this.Height / 10),
                        new Size(this.Size.Width - this.Width / 5, this.Size.Height - this.Height / 5)));
            }
        }
    }
}
