using System;
using System.Drawing;
using System.Windows.Forms;

namespace _421Game
{
    class DiceControl : PictureBox
    {
        string _imgName;
        bool _checked;

        public DiceControl()
        {
            this._checked = false;
            base.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Click += delegate (object sender, EventArgs e)
            {
                if (this._imgName != null)
                {
                    this._checked = !this._checked;
                    SetImage();
                }
            };
        }

        public string ImgName
        {
            get { return this._imgName; }
            set { this._imgName = value; this._checked = false; SetImage(); System.GC.Collect(); }
        }

        private void SetImage()
        {
            if (_imgName != null)
            {
                base.Image = new Bitmap(this._checked ? this._imgName.Split('.')[0] + "checked.png" : this._imgName);
            }
            else
                base.Image = null;
        }
    }
}
