namespace WAD._00014460.DTOs
{
    public class TaskItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public int CategoryId { get; set; }
    }
}
