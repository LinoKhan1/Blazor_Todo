// Services/TodoService.cs
using BlazorSample; // Import the BlazorSample namespace to access the TodoItem class
using System.Collections.Generic;  // Import the namespace for List<T> and IReadOnlyList<T>

namespace TodoList.Services  
{
    public class TodoService
    {
        private List<TodoItem> _todoItems = new(); // Private field to store the list of todo items

        // Property to expose the list of todo items as read-only
        public IReadOnlyList<TodoItem> Todos => _todoItems;

        // Method to add a new todo item with specified title
        public virtual void AddTodo(string title)
        {
            // Check if the title is null or empty
            if(!string.IsNullOrEmpty(title))
            {
                // Create a new todo item with the given title and add it to the list
                _todoItems.Add(new TodoItem {  Title = title });    
            }
        }

        // Method to toggle the status (done/not done) of a todo item
        public virtual void ToggleTodoStatus(TodoItem todo)
        {
            // Toggle the IsDone property of the specified todo item
            todo.IsDone = !todo.IsDone;
        }
    }
}
