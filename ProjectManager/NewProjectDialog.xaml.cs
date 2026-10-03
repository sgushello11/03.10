using System.Windows;
using MahApps.Metro.Controls;

namespace ProjectManager
{
    public partial class NewProjectDialog : MetroWindow
    {
        public string ProjectName { get; private set; }

        public NewProjectDialog()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            ProjectName = NameBox.Text;
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}