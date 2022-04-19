using Library;
using System.Collections.Generic;
using System.Windows;


namespace Exam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Title = "Список задач";

            InitializeApplication();
        }

        public Library.Application Application = new Library.Application();
        public List<string> taskListNames;

        public void InitializeApplication()
        {
            InitializeTaskLists();
            InitializeTaskListNames();
            InitializeTaskListName();

            Application.application = Application.GetApplication();
        }

        public void InitializeTaskLists()
        {
            TaskLists.Items.Clear();

            if(Application.taskLists == null || Application.taskLists.Count == 0)
                Application.taskLists = new List<TaskList>()
                {
                    new TaskList("Входящие"), new TaskList("Сегодня"), new TaskList("Предстоящие")
                };

            foreach (TaskList taskList in Application.taskLists)
            {
                TaskLists.Items.Add(taskList.Name);
            }

            if (Application.taskLists.Count == 3)
                TaskLists.SelectedItem = "Входящие";

            else
                TaskLists.SelectedItem = Application.taskLists.FindLast(tl => tl.Name != null).Name;
        }

        public void InitializeTaskListNames()
        {
            taskListNames = Application.GetTaskListNames();
        }

        private void InitializeTaskListName()
        {
            var name = TaskLists.SelectedItem;
            TaskListNameLabel.Content = name;
        }

        private void TaskLists_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            InitializeTaskListName();
        }
    }
}
