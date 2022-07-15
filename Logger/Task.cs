using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class Task : IEquatable<Task>
    {
        private string name;
        private TaskStatus status;
        public string Name { get => name; set => name = value; }
        public TaskStatus Status { get => status; set => status = value; }

        public Task(string name, TaskStatus status)
        {
            Name = name;
            Status = status;
        }



        public override string ToString()
        {
            return $"{Name} [{Status}]";
        }

        public override bool Equals(Object obj)
        {
            if(obj == null)
                return false;
            Task otherTask = obj as Task;
            if(otherTask == null)
                return false;
            else
                return Equals(otherTask);

        }

        public override int GetHashCode() => HashCode.Combine(Name, Status);

        public bool Equals(Task other)
        {
            if (other == null)
                return false;

            if (Name == other.Name && Status == other.Status)
                return true;
            else
                return false;
        }
    }
}
