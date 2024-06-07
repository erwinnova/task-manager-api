using System.ComponentModel;

namespace TaskManagerAPI.Models
{
    public class TodoModel
    {
        public string todo { get; set; }
        
        [DefaultValue(false)]
        public bool completed { get; set; }
        
    }
}
