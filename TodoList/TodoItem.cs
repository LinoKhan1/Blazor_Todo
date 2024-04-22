// TodoItem.cs 

namespace BlazorSample
{

    // Todo Item classs that defines the values of the item title and status
    public class TodoItem
    {
        // Attributes
        public string? Title { get; set; }  // Todo item name
        public bool IsDone { get; set; } // variable to store the status of the item, where completed or not
    }
}
