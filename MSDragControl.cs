using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace milano88.UI.Controls
{
    public class MSDragControl : Component
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        Control _targetControl;
        [Category("Misc")]
        [DefaultValue(typeof(Form), null)]
        public Control TargetControl
        {
            get { return _targetControl; }
            set
            {
                _targetControl = value;
                _targetControl.MouseDown += TargetControl_MouseDown;
            }
        }

        private void TargetControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(_targetControl.FindForm().Handle, 161, 2, 0);
            }
        }


    }
}
