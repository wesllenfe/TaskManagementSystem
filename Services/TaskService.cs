using System.Collections.Generic;
using System.Linq;
using TaskModel = TaskManagementSystem.Models.Task;

namespace TaskManagementSystem.Services
{
    public class TaskService
    {
        private List<TaskModel> tasks = new List<TaskModel>();

        public List<TaskModel> GetAllTasks()
        {
            return tasks;
        }

        public TaskModel GetTaskById(int taskId)
        {
            return tasks.FirstOrDefault(t => t.Id == taskId);
        }

        public void AddTask(TaskModel task)
        {
            task.Id = tasks.Count + 1;
            tasks.Add(task);
        }

        public void UpdateTask(TaskModel updatedTask)
        {
            var existingTask = tasks.FirstOrDefault(t => t.Id == updatedTask.Id);
            if (existingTask != null)
            {
                existingTask.Title = updatedTask.Title;
                existingTask.Description = updatedTask.Description;
                existingTask.IsCompleted = updatedTask.IsCompleted;
            }
        }

        public void DeleteTask(int taskId)
        {
            tasks.RemoveAll(t => t.Id == taskId);
        }
    }
}