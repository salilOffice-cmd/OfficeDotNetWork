using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace linq

{
    internal class Sagar
    {
        static void Main(string[] args)
        {
            List<student> students = new List<student>()
            {
                new student { id = 1, name = "sagar", rollno = 23 },
                new student { id = 2, name = "rohit", rollno = 24 },
                new student { id = 3, name = "salil", rollno = 25 },

            };
            foreach (var m in students)
            {
                Console.WriteLine(m.id + " " + m.name + " " + m.rollno + " " + m.rollno);

            }

            List<Marks> markss = new List<Marks>();

            new Marks { id = 1, Totalmarks = 99, rollno = 23 };
            new Marks { id = 2, Totalmarks = 95, rollno = 24 };
            new Marks { id = 3, Totalmarks = 85, rollno = 25 };

            var methodsyntax = students.Join(
                markss,
                student => student.rollno,
                Marks => Marks.rollno,
                (student, Marks) =>
                new studentmarks()
                {
                    id = student.id,
                    name = student.name,
                    rollno = student.rollno,
                    totalmarks = Marks.Totalmarks,

                }
                );
            foreach (var m in methodsyntax)
            {
                Console.WriteLine(m.id + " " + m.name + " " + m.rollno + " " + m.totalmarks);

            }


        }
    }

    public class student
    {
        public int id { get; set; }
        public string name { get; set; }

        public int rollno { get; set; }



    }

    public class Marks
    {
        public int id { get; set; }

        public int Totalmarks { get; set; }

        public int rollno { get; set; }

    }
    public class studentmarks
    {
        public int id { get; set; }

        public string name { set; get; }

        public int rollno { get; set; }

        public int totalmarks { get; set; }

    }
}
