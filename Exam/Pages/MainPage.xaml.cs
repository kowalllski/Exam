using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Exam.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void AddTaskListButton_Click(object sender, RoutedEventArgs e)
        {
            AddTaskListButton.Visibility = Visibility.Hidden;
            Text.Visibility = Visibility.Hidden;
            NewTaskListName.Visibility = Visibility.Visible;
        }

        private void NewTaskListName_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            NewTaskListName.Text = string.Empty;
        }

        private void NewTaskListName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NewTaskListName.Text))
                return;

            MainWindow window = Window.GetWindow(this) as MainWindow;

            window.Application.CreateTaskList(NewTaskListName.Text);
            window.InitializeTaskLists();
            window.InitializeTaskListNames();

            AddTaskListButton.Visibility = Visibility.Visible;
            Text.Visibility = Visibility.Visible;
            NewTaskListName.Visibility = Visibility.Hidden;
        }
    }
}
