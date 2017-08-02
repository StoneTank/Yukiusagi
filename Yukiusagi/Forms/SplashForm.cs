using System.Reflection;
using System.Windows.Forms;

namespace StoneTank.Yukiusagi
{
    public partial class SplashForm : Form
    {
        // ドロップシャドウ
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ClassStyle |= 0x20000;
                return createParams;
            }
        }

        public SplashForm()
        {
            InitializeComponent();
            this.Opacity = 1;
            titleLabel.Text = "";
            smallLabel.Text = $"Version {Assembly.GetExecutingAssembly().GetName().Version.Major}.{Assembly.GetExecutingAssembly().GetName().Version.Minor}";
        }

        public SplashForm(string labelText)
        {
            InitializeComponent();
            this.Opacity = 1;
            titleLabel.Text = "";
            smallLabel.Text = labelText;
        }

        private void SplashForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 消えるときフェードアウトする
            for (int i = 10; i >= 0; i--)
            {
                this.Opacity = 0.1 * i;
                System.Threading.Thread.Sleep(20);
            }

        }
    }
}
