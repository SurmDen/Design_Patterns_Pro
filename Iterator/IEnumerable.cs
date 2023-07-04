using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    public class Student
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Country { get; set; }

        public Student()
        {
            Country = "Russia";
        }

        public Student(string name):this()
        {
            Name = name;
        }

        public Student(string name, int age) :this(name)
        {
            Age = age;
        }
    }

    public class StudentsEnumerator : IEnumerator
    {
        private List<Student> students;

        public StudentsEnumerator(List<Student> students)
        {
            this.students = students;
        }

        private int current = -1;

        public Object Current
        {
            get 
            {
                if (current > -1 && current <= students.Count())
                {
                    return students[current];
                }

                throw new ArgumentOutOfRangeException();
            }
        }

        public bool MoveNext()
        {
            if (current < students.Count())
            {
                current++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            current = -1;
        }
    }

    public class University : IEnumerable
    {
        private List<Student> Students = new List<Student>();

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public IEnumerator GetEnumerator()
        {
            return new StudentsEnumerator(Students);
        }
    }

    //lets try this all with YIELD RETURN

    public class SchoolMan
    {
        public string Name { get; set; }

        public SchoolMan(string name)
        {
            Name = name;
        }
    }

    //we don't need to create class, inherited from IEnumenator

    public class School : IEnumerable
    {
        private List<SchoolMan> Men;

        public School()
        {

        }

        public void AddSchoolMan(SchoolMan man)
        {
            Men.Add(man);
        }

        //instead realize 'MoveNext', 'Current', 'Reset' we also use yield return...))
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Men.Count()-1; i++)
            {
                yield return Men[i];
            }
        }
    }
}
