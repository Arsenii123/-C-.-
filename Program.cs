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
        private List<int> exams = new List<int>();
        List<int> homeworks = new List<int>();
        List<int> lessons = new List<int>();
        public static int count;
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
        public void GetAdress()
        {
    
            foreach(string number in adress)
            {
                Console.WriteLine(number);
            }
           
        }
        public int GetBirthday()
        {

            foreach (int  number in birthday)
            {
                return number;
            }
            return 0;
        }
        public void  GetExam()
        {

            foreach (int exam in exams)
            {
                Console.WriteLine(exam);
            }
        }
        public void GetHomework()
        {

            foreach (int homework in homeworks)
            {
                Console.WriteLine(homework);
            }
          
        }
        public void  GetLessons()
        {

            foreach (int lesson in lessons)
            {
                Console.WriteLine(lesson);
            }
        }
        public int GetNumber()
        {
            return number;
        }
        public bool Bad_Exams()
        {
            bool chek =false;
            foreach(int exam in exams)
            {
                if (exam <= 5)
                {
                    chek = true;
                }

            }
            return chek;
            
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
            count++;
        }

    }
    class Group:Student 
    {
        List<string> students=new List <string>();
        string? group = "";
        string? type = "";
        int number_of_course = 0;
        int fails = 0;
        public Group(List<string> students)
        {
            foreach (string i in this.students)
            {
                students.Add(i);
            }
            Console.WriteLine("Name of group:");
            string? group = Console.ReadLine();
            this.group = group;
            Console.WriteLine("Type of group:");
            string? type = Console.ReadLine();
            this.type = type;
            Console.WriteLine("Placement:");
            int number_of_course = Console.Read();
            this.number_of_course = number_of_course;
        }
       public  Group()
        {

            Console.WriteLine("How many students?");
            int num = Console.Read();
            Console.WriteLine(num);
            for(int i = 0; i < 5+1; i++)
            {
                Console.WriteLine(i+":");
                string person = Console.ReadLine();
                this.students.Add(person);
            }
            Console.WriteLine("Name of group:");
            string? group = Console.ReadLine();
            this.group = group;
            Console.WriteLine("Type of group:");
            string? type = Console.ReadLine();
            this.type = type;
            Console.WriteLine("Placement:");
            int number_of_course = Console.Read();
            this.number_of_course = number_of_course;


        }
       public  Group(Group original,Group copy)
        {

            copy.students = original.students;
            copy.number_of_course = original.number_of_course;
            copy.group = original.group;
            copy.type = original.type;



        }
       public  void Print()
        {
            Console.WriteLine(this.group);
            Console.WriteLine(this.type);
            this.students.Sort();
            int num = 0;
            foreach(string name in this.students)
            {
               
                Console.WriteLine(num+"."+name);
                num++;
            }
          
        }
        public void Add_Student(string student)
        {
            students.Add(student);
        }
        public void Another_Group(string student,Group p_new)
        {
            students.Remove(student);
            p_new.students.Add(student);
        }
        public void Count_Bad(Student p)
        {
            if (p.Bad_Exams() == true)
            {
                fails++;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Student
            //Console.WriteLine("Hello, World!");
            //Student student = new Student(3, 2, 1, 12, 11, 1);
            //Console.WriteLine(student.GetExam());
            //Console.WriteLine(student.GetLessons());
            //Console.WriteLine(student.GetHomework());
            //Group

            Group group= new Group();
            group.Print();
            Group g2 = new Group();
            Group g3 = new Group(group, g2);
            g2.Print();
            g2.Add_Student( "Arsenii");
            g2.Another_Group("Arsenii", group);

        }
    }
}
