using System.Windows.Forms;
using DevCraft.Core.Logic;

namespace DevCraft.UI.Forms
{
    public partial class ServerPropertiesWindow : Form
    {
        public ServerPropertiesWindow(string serverFolder)
        {
            InitializeComponent();

            dataGridView1.AutoSize = true;
            dataGridView1.DataSource = new ServerProperties(serverFolder);
        }
    }
}
