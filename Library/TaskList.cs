using System;
using System.Collections.Generic;

namespace Library
{
    public class TaskList
    {
        public string Name { get; set; }
        public List<Task> Tasks { get; set; }

        public TaskList(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Метод получения имени списка задач
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return Name;
        }

        /// <summary>
        /// Метод добавления задачи в список задач
        /// </summary>
        /// <param name="task">Задача</param>
        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }

        /// <summary>
        /// Метод получения задач списка задач
        /// </summary>
        /// <returns></returns>
        public List<Task> GetTasks()
        {
            return Tasks;
        }

        /// <summary>
        /// Метод удаления задачи из списка задач
        /// </summary>
        /// <param name="task">Задача</param>
        public void Remove(Task task)
        {
            if (Tasks.Contains(task))
            {
                Tasks.Remove(task);
            }
        }

        /// <summary>
        /// Метод получения задач на сегодня
        /// </summary>
        /// <returns></returns>
        public List<Task> GetTasksByToday()
        {
            List<Task> tasksByToday = new List<Task>();

            foreach (Task task in Tasks)
            {
                if (task.Due.ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    tasksByToday.Add(task);
                }
            }

            return tasksByToday;
        }

        /// <summary>
        /// Метод получения задач на сегодня и позднее
        /// </summary>
        /// <returns></returns>
        public List<Task> GetTasksByFuture()
        {
            List<Task> tasksByFuture = new List<Task>();

            foreach (Task task in Tasks)
            {
                if (task.Due > DateTime.Now)
                {
                    tasksByFuture.Add(task);
                }
            }

            return tasksByFuture;
        }
    }
}
