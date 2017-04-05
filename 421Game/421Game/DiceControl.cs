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
            base.MouseDown += delegate (object sender, MouseEventArgs e)
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
            set
            {
                this._imgName = value;
                this._checked = false;
                SetImage();
                System.GC.Collect();        // Avoids the excessive usage of memory.
            }
        }

        public bool Checked
        {
            get { return _checked; }
        }

        private void SetImage()
        {
            if (_imgName != null)
            {
                if (base.Image != null)
                    base.Image.Dispose();   // Avoids the excessive usage of memory.
                base.Image = new Bitmap(this._checked ? this._imgName.Split('.')[0] + "checked.png" : this._imgName);
            }
            else
                base.Image = null;
        }
    }
}
