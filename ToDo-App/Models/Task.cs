using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace ToDo_App.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Task(string title, string description)
        {
            Id = MainPage.nextRecID;
            Title = title;
            Description = description;
        }

        [JsonConstructor]
        public Task(int id, string title, string description) {
            Id = id;
            Title = title;
            Description = description;
        }

        public string getTask()
        {
            return Title + " " + Description;
        }
    }
}
