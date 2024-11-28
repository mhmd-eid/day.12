﻿using System.ComponentModel.DataAnnotations;

namespace toDoList.Models
{
    public class Task
    {
        [Key] public int Id { get; set; }
        public  string Name { get; set; }
        public  string Description { get; set; }
        public DateTime Time { get; set; }

    }
}
