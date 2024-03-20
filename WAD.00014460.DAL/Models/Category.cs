namespace WAD._00014460.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TaskItem> Tasks { get; set; }
    }
}
