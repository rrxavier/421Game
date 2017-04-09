using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace _421Game
{
    class Dice : PictureBox
    {
        private int _lastRoll;
        private string _imgName;
        private bool _checked;
        public bool _clickable;

        public Dice()
        {
            this._lastRoll = -1;
            this._checked = false;
            this._clickable = false;
            base.SizeMode = PictureBoxSizeMode.StretchImage;
            base.Size = new Size(75, 75);
            base.MouseDown += delegate (object sender, MouseEventArgs e)
            {
                if (this._imgName != null && this._clickable)
                {
                    this._checked = !this._checked;
                    SetImage();
                }
            };
        }

        public string ImgName
        {
            get { return this._imgName; }
            set
            {
                this._imgName = value;
                System.GC.Collect();        // Avoids the excessive usage of memory.
            }
        }

        public bool Checked
        {
            get { return this._checked; }
            set { this._checked = value; }
        }

        public bool Clickable
        {
            get { return this._clickable; }
            set { this._clickable = value; }
        }
        /// <summary>
        /// The value of the last roll. If this contains 0, it means that the Dice hasn't been rolled yet.
        /// </summary>
        public int LastRoll
        {
            get { return _lastRoll; }
        }

        /// <summary>
        /// Roll a number between 1 and 6.
        /// </summary>
        public void Roll()
        {
            // 7 Because the last value's exclusive.
            _lastRoll = new Random().Next(1, 7);
            Thread.Sleep(25);   // Avoids the Random to take the same numbers.
        }

        public void Reset()
        {
            this._lastRoll = 0;
        }

        public override string ToString()
        {
            return LastRoll.ToString();
        }

        public void SetImage()
        {
            this.ImgName = this.LastRoll.ToString() != "-1" && this.ToString() != "0" ? string.Format("dice{0}{1}.png", this.LastRoll.ToString(), this._checked ? "checked" : string.Empty) : null;
            if (_imgName != null)
            {
                if (base.Image != null)
                    base.Image.Dispose();   // Avoids the excessive usage of memory.
                base.Image = new Bitmap(this._imgName);
            }
            else
                base.Image = null;
        }
    }
}
