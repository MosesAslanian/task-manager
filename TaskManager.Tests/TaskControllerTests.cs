using Microsoft.AspNetCore.Mvc;
using TaskManager.Controllers;
using TaskManager.Models;

namespace TaskManager.Tests
{
    public class TaskControllerTests
    {
        [Fact]
        public void CreateTask_ReturnsCreatedResult()
        {
            // Arrange
            var controller = new TaskController();
            var task = new TaskModel
            {
                Id = 1,
                Title = "First Task",
                Description = "This is the First Task."
            };

            // Act
            var result = controller.CreateTask(task) as JsonResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);

            // Additional assertions to verify task creation logic
        }

        [Fact]
        public void CreateTask_IncrementsTaskCounter()
        {
            // Arrange
            var controller = new TaskController();
            TaskController.tasks = new();
            var task1 = new TaskModel();
            var task2 = new TaskModel();

            // Act
            controller.CreateTask(task1);
            controller.CreateTask(task2);

            // Assert
            Assert.Equal(2, task2.Id);
        }

        [Fact]
        public void CreateTask_AddsTaskToTasksList()
        {
            // Arrange
            var controller = new TaskController();
            var task = new TaskModel();

            // Act
            controller.CreateTask(task);

            // Assert
            Assert.Contains(task, TaskController.tasks);
        }

    }
}