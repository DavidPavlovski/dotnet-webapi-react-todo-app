namespace TodoWebApp.Domain
{
    public class Todo
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCompleted { get; set; }



        public Todo(string text)
        {
            Text = text;
            IsCompleted = false;
        }

        public void Update(Todo todo)
        {
            Text = todo.Text;
            IsCompleted = todo.IsCompleted;
        }
    }
}