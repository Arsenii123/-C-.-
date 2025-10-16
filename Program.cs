using System.Text.Json.Serialization;

namespace Homework2
{
    class Student
    {
         string? name;
         string? secondname;
         string? father;
         List<int> birthday=new List<int>();
        List<string> adress = new List<string>();
        List<int> exams = new List<int>();
        List<int> homeworks = new List<int>();
        List<int> lessons = new List<int>();
        int number;
        public  void SetName(string name)
        {
            this.name = name;
        }
        public void SetSecondname(string secondname)
        {
            this.secondname = secondname;
        }
        public void SetFather(string father)
        {
            this.father = father;
        }
        public void SetDay(int day)
        {
            birthday.Insert(day,'1');
        }
        public void SetMonth(int month)
        {
            birthday.Insert(month, '2');
        }
        public void SetYear(int year)
        {
            birthday.Insert(year, '3');
        }
        public void SetAdress(string street,string house)
        {
            adress.Add(street);
            adress.Add( house);
        }
        public void SetNumber(int number)
        {
            this.number = number;
        }
        public void SetExam(int exam)
        {
            exams.Add(exam);
        }
        public void SetHomework(int homework)
        {
            homeworks.Add(homework);
        }
        public void SetLesson(int lesson)
        {
            lessons.Add(lesson);
        }
        public  string? GetName()
        {
            return name;
        }
        public string? GetSecondnamet()
        {
            return secondname;
        }
        public string? GetFather()
        {
            return father;
        }
        public string GetAdress()
        {
    
            foreach(string number in adress)
            {
                return number;
            }
            return "";
        }
        public int GetBirthday()
        {

            foreach (int  number in birthday)
            {
                return number;
            }
            return 0;
        }
        public int GetExam()
        {

            foreach (int exam in exams)
            {
                return exam;
            }
            return 0;
        }
        public int GetHomework()
        {

            foreach (int homework in homeworks)
            {
                return homework;
            }
            return 0;
        }
        public int GetLessons()
        {

            foreach (int lesson in lessons)
            {
                return lesson;
            }
            return 0;
        }
        public int GetNumber()
        {
            return number;
        }
        public Student(string? name,string? secondname,string? father,int day,int month,int year,string street,string home,int lesson,int exam,int homework,int number)
        {
            SetName(name);
            SetSecondname(secondname);
            SetFather(father);
            SetDay(day);
            SetMonth(month);
            SetYear(year);
            SetAdress(street,home);
            SetLesson(lesson);
            SetExam(exam);
            SetHomework(homework);
            SetNumber(number);
        }
        public Student(int count_lesson, int count_homework, int count_exam, int lesson, int exam, int homework)
        {
            for (int i = 0; i < count_lesson;i++) 
            {
                SetLesson(lesson);
            }
            for (int i = 0; i < count_homework; i++)
            {
                SetHomework(homework);
            }
            for (int i = 0; i < count_exam; i++)
            {
                SetExam(exam);
            }
        }
        public Student() : this("", "", "", 0, 0, 0, "", "", 0, 0, 0, 0)
        {

        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Student student = new Student(3, 2, 1, 12, 11, 1);
            Console.WriteLine(student.GetExam());
            Console.WriteLine(student.GetLessons());
            Console.WriteLine(student.GetHomework());

        }
    }
}
