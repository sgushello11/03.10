using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using MahApps.Metro;
using ControlzEx.Theming;

namespace ProjectManager
{
    public partial class MainWindow : MetroWindow
    {
        public ObservableCollection<Project> Projects { get; set; } = new ObservableCollection<Project>();
        public ObservableCollection<TaskItem> Tasks { get; set; } = new ObservableCollection<TaskItem>();

        public MainWindow()
        {
            InitializeComponent();

            // Тестовые данные
            Projects.Add(new Project { Name = "Сайт", Status = "В работе" });
            Projects.Add(new Project { Name = "Мобильное приложение", Status = "Завершён" });
            ProjectsList.ItemsSource = Projects;

            Tasks.Add(new TaskItem
            {
                Title = "Разработать интерфейс",
                Priority = "НГН",
                Status = "В работе",
                Deadline = new System.DateTime(2026, 10, 12)
            });
            TasksGrid.ItemsSource = Tasks;
        }

        // Переключение страниц
        private void Nav_Click(object sender, RoutedEventArgs e)
        {
            PageHome.Visibility = Visibility.Collapsed;
            PageProjects.Visibility = Visibility.Collapsed;
            PageTasks.Visibility = Visibility.Collapsed;
            PageStats.Visibility = Visibility.Collapsed;
            PageSettings.Visibility = Visibility.Collapsed;

            Button btn = sender as Button;
            if (btn == null) return;

            switch (btn.Tag as string)
            {
                case "home": PageHome.Visibility = Visibility.Visible; break;
                case "projects": PageProjects.Visibility = Visibility.Visible; break;
                case "tasks": PageTasks.Visibility = Visibility.Visible; break;
                case "stats": PageStats.Visibility = Visibility.Visible; break;
                case "settings": PageSettings.Visibility = Visibility.Visible; break;
            }
        }

        // Добавить проект
        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new NewProjectDialog();
            dlg.Owner = this;
            if (dlg.ShowDialog() == true)
            {
                if (string.IsNullOrWhiteSpace(dlg.ProjectName))
                {
                    MessageBox.Show("Необходимо указать название проекта",
                                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                Projects.Add(new Project { Name = dlg.ProjectName, Status = "Новый" });
                MessageBox.Show("Проект успешно создан",
                                "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Изменить проект
        private void EditProject_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectsList.SelectedItem == null)
            {
                MessageBox.Show("Выберите проект", "Внимание",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            MessageBox.Show("Изменение проекта", "Информация");
        }

        // Удалить проект
        private void DeleteProject_Click(object sender, RoutedEventArgs e)
        {
            Project p = ProjectsList.SelectedItem as Project;
            if (p != null)
            {
                Projects.Remove(p);
                MessageBox.Show("Проект удалён", "Успех",
                                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Выберите проект", "Внимание",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Открыть проект
        private void OpenProject_Click(object sender, RoutedEventArgs e)
        {
            Project p = ProjectsList.SelectedItem as Project;
            if (p != null)
                MessageBox.Show("Открыт проект: " + p.Name, "Информация");
            else
                MessageBox.Show("Выберите проект", "Внимание",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        // Смена темы
        private void Theme_Checked(object sender, RoutedEventArgs e)
        {
            ThemeManager.Current.ChangeTheme(this, "Dark.Blue");
        }

        private void Theme_Unchecked(object sender, RoutedEventArgs e)
        {
            ThemeManager.Current.ChangeTheme(this, "Light.Blue");
        }
    }
}