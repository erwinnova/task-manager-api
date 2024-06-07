using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.DataModel
{
    public class TodoDataModel
    {
        [Key]
        public Guid Id { get; set; }
        public string todo { get; set; }
        public bool completed { get; set; }
    }
}
