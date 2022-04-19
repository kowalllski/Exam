using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ApplicationTest
    {
        private readonly Application application = new Application();

        [TestMethod]
        public void GetApplication()
        {
            var expApplicationExist = true;
            var actApplicationExist = true;

            var newApplication = application.GetApplication();
            if (newApplication == null)
                actApplicationExist = false;

            Assert.AreEqual(expApplicationExist, actApplicationExist);
        }

        [TestMethod]
        public void CreateTaskList()
        {
            int? taskListCountBefore = application.taskLists?.Count;
            application.CreateTaskList("new");

            int taskListCountAfter = application.taskLists.Count;

            Assert.AreNotEqual(taskListCountBefore, taskListCountAfter);

        }

        [TestMethod]
        public void GetTaskListByName()
        {
            var name = "new";
            var expTaskListExist = true;
            var actTaskListExist = true;

            application.CreateTaskList(name);
            var taskList = application.GetTaskListByName(name);
            if (taskList == null)
                actTaskListExist = false;

            Assert.AreEqual(expTaskListExist, actTaskListExist);
        }

        [TestMethod]
        public void GetTaskListNames()
        {
            int expTaskListCount = 2;
            int? actTaskListCount;

            application.CreateTaskList("1");
            application.CreateTaskList("2");

            System.Collections.Generic.List<string> taskListNames = application.GetTaskListNames();
            actTaskListCount = taskListNames.Count;

            Assert.AreEqual(expTaskListCount, actTaskListCount);
        }

        [TestMethod]
        public void GetTasksByToday()
        {

        }

        [TestMethod]
        public void GetTasksByFuture()
        {

        }
    }
}
