using System.Windows.Forms;

namespace Calc.Base
{
    public abstract class BaseClass
    {
        public void CloseWindow(Form form)
        {
            DialogResult dr = MessageBox.Show("Close the window ?", "Warning", MessageBoxButtons.OK);
            if(dr == DialogResult.OK)
            {
                form.Hide();
            }
        }
    }
}
