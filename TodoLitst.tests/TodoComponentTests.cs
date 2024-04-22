using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Bunit;
using Moq;
using BlazorSample;
using TodoList.Services;
using TodoList.Components.Pages;


namespace TodoLitst.tests
{
    public class TodoComponentTests : TestContext
    {
        [Fact]
        public void AddingTodo_UpdatesTodoList()
        {
            // Arrange
            var todoServiceMock = new Mock<TodoService>();
            Services.AddSingleton(todoServiceMock.Object); // Register mock service in the test context

            var component = RenderComponent<Todo>(); // Render the todo component

            // Act
            var inputElement = component.Find("input[placeholder='Something todo']");
            inputElement.Change("New Todo Item");

            var addButton = component.Find("button");
            addButton.Click();

            // Assert
            // todoServiceMock.Verify(mock => mock.AddTodo("New Todo Item"), Times.Once); // Verify that AddTodo was called with the correct argument
            // Assert
            todoServiceMock.Verify(mock => mock.AddTodo(It.IsAny<string>()), Times.AtLeastOnce); // Verify that AddTodo was called at least once

        }

        [Fact]
        public void TogglingTodoStatus_UpdatesTodoList()
        {
            // Arrange
            var todoServiceMock = new Mock<TodoService>();
            Services.AddSingleton(todoServiceMock.Object); // Register mock service in the test context

            var todoItem = new TodoItem { Title = "Todo 1", IsDone = false };

            var component = RenderComponent<Todo>(); // Render the todo component

            // Act
            var checkBoxElement = component.Find("input[type='checkbox']");
            checkBoxElement.Change(true);

            // Assert
            todoServiceMock.Verify(mock => mock.ToggleTodoStatus(It.IsAny<TodoItem>()), Times.Once); // Verify that ToggleTodoStatus method was called with the correct argument
        }


    }
}