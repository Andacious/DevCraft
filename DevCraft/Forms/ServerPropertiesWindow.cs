using System.Windows.Forms;
using DevCraft.Core.Logic;

namespace DevCraft.UI.Forms
{
    internal partial class ServerPropertiesWindow : Form
    {
        internal ServerPropertiesWindow(string serverFolder)
        {
            InitializeComponent();

            dataGridView1.AutoSize = true;
            dataGridView1.DataSource = new ServerProperties(serverFolder);
        }
    }
}
