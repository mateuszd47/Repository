using System;
using System.Collections.Generic;

namespace Logger
{
    public class Student : Person, IEquatable<Student>
    {
        protected string group;
        protected List<Task> tasks = new List<Task>();
        public string Group { get => group; set => group = value; }

        public Student(string name, int age, string group) : base(name, age)
        {
            Group = group;
        }

        public Student(string name, int age, string group, List<Task> tasks) : base(name, age)
        {
            Group = group;
            this.tasks = tasks;
        }

        public void AddTask(string taskName, TaskStatus taskStatus)
        {
            var task = new Task(taskName, taskStatus);
            tasks.Add(task);
        }

        public void RemoveTask(int index)
        {
            tasks.RemoveAt(index);
        }

        public void UpdateTask(int index, TaskStatus taskStatus)
        {
            var task = tasks[index];
            tasks.Insert(index, task);
            tasks.RemoveAt(index + 1);
        }

        public string RenderTasks(string prefix = "\t")
        {
            string result = "";

            for (int i = 0; i < tasks.Count; i++)
            {
                result += "\r\n" + prefix + i.ToString() + ". " + tasks[i];
            }

            return result;
        }

        public override string ToString() => $"Student: {Name} ({Age} y.o.)\r\nGroup: {Group}\r\nTasks: {RenderTasks()}";

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Student otherStudent = obj as Student;

            if (otherStudent == null)
                return false;
            else
                return Equals(otherStudent);
        }

        public bool Equals(Student? other)
        {
            if (other == null)
                return false;

            if (Name == other.Name && Age == other.Age && Group == other.Group && RenderTasks() == other.RenderTasks())
                return true;
            else
                return false;
        }


        private bool SequenceEquals(List<Task> a, List<Task> b)
        {
            foreach (Task taskA in a)
            {
                foreach (Task taskB in b)
                {
                    if (!taskA.Equals(taskB))
                        return false;
                }
            }
            return true;
        }
    }
}
