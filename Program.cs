using System;
using System.Collections.Specialized;
using System.Text.Json.Serialization;
using System.Threading;
using System.Collections;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.Reflection;
using static Homework2.Student;
using System.Security.Cryptography.X509Certificates;
namespace Homework2
{
    delegate bool StudentFilter(Student chelovek);
    delegate bool StudentsFilter(Student chelovek,Student p);
    class Student
    {
        public delegate void MyEventHandler();
        private MyEventHandler? CheckTime;
        private MyEventHandler? Automat;
        private MyEventHandler? Awarded;

        public event MyEventHandler? Time
        {
            add
            {
                Console.WriteLine("Обробник події додано");
                MyEventHandler? currentHandler;
                MyEventHandler? newHandler;
                do
                {
                    currentHandler = CheckTime;
                    newHandler = (MyEventHandler?)Delegate.Combine(currentHandler, value);
                }
                while (Interlocked.CompareExchange(ref CheckTime, newHandler, currentHandler) != currentHandler);
            }
            remove
            {
                Console.WriteLine("Обробник події прибрано");
                MyEventHandler? currentHandler;
                MyEventHandler? newHandler;
                do
                {
                    currentHandler = CheckTime;
                    newHandler = (MyEventHandler?)Delegate.Remove(currentHandler, value);
                }
                while (Interlocked.CompareExchange(ref CheckTime, newHandler, currentHandler) != currentHandler);
            }
        }
        public event MyEventHandler? Auto
        {
            add
            {
                Console.WriteLine("Обробник події додано");
                MyEventHandler? currentHandler;
                MyEventHandler? newHandler;
                do
                {
                    currentHandler = Automat;
                    newHandler = (MyEventHandler?)Delegate.Combine(currentHandler, value);
                }
                while (Interlocked.CompareExchange(ref Automat, newHandler, currentHandler) != currentHandler);
            }
            remove
            {
                Console.WriteLine("Обробник події прибрано");
                MyEventHandler? currentHandler;
                MyEventHandler? newHandler;
                do
                {
                    currentHandler = Automat;
                    newHandler = (MyEventHandler?)Delegate.Remove(currentHandler, value);
                }
                while (Interlocked.CompareExchange(ref Automat, newHandler, currentHandler) != currentHandler);
            }
        }
        public event MyEventHandler? Award
        {
            add
            {
                Console.WriteLine("Обробник події додано");
                MyEventHandler? currentHandler;
                MyEventHandler? newHandler;
                do
                {
                    currentHandler = Awarded;
                    newHandler = (MyEventHandler?)Delegate.Combine(currentHandler, value);
                }
                while (Interlocked.CompareExchange(ref Awarded, newHandler, currentHandler) != currentHandler);
            }
            remove
            {
                Console.WriteLine("Обробник події прибрано");
                MyEventHandler? currentHandler;
                MyEventHandler? newHandler;
                do
                {
                    currentHandler = Awarded;
                    newHandler = (MyEventHandler?)Delegate.Remove(currentHandler, value);
                }
                while (Interlocked.CompareExchange(ref Awarded, newHandler, currentHandler) != currentHandler);
            }
        }
        public void StartEventTime()
        {
            if (CheckTime != null)
               CheckTime();
        }
        public void StartEventAutomat()
        {
            if (Automat != null)
                Automat();
        }
        public void StartEventAward()
        {
            if (Awarded != null)
                Awarded();
        }
        string? name;
        string? secondname;
        string? father;
        List<int> birthday = new List<int>();
        List<string> adress = new List<string>();
        List<int> exams = new List<int>();
        List<int> homeworks = new List<int>();
        List<int> lessons = new List<int>();
        public static int count;
        int number;
        int average;
        public string Name { get; set; }
        public string Secondname { get; set; }
        public int Age { get; set; }
        public int Averagemark { get; set; }
        public void SetName(string name)
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
            birthday.Insert(day, '1');
        }
        public void SetMonth(int month)
        {
            birthday.Insert(month, '2');
        }
        public void SetYear(int year)
        {
            birthday.Insert(year, '3');
        }
        public void SetAdress(string street, string house)
        {
            adress.Add(street);
            adress.Add(house);
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
        public string? GetName()
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
        public int GetExamMark(int index)
        {
            return exams[index];
        }
        public int GetLessonMark(int index)
        {
            return lessons[index];
        }
        public List<string> GetAdress()
        {

            return adress;

        }
        public int GetBirthday()
        {

            foreach (int number in birthday)
            {
                return number;
            }
            return 0;
        }
        public List<int>  GetExam()
        {
            return exams  ;

        }
        public List<int> GetHomework()
        {

            return homeworks;

        }
        public List<int> GetLessons()
        {

            return lessons;
        }
        public int GetNumber()
        {
            return number;
        }
        public bool BadExams()
        {
            bool chek = false;
            foreach (int exam in exams)
            {
                if (exam <= 5)
                {
                    chek = true;
                }

            }
            return chek;

        }
       public  void TimeOf()
        {
            TimeOnly now = TimeOnly.FromDateTime(DateTime.Now);
            TimeOnly lesson = new TimeOnly(16, 45);
            if (now > lesson)
            {
                Console.WriteLine($" YOU'RE LATE FOR {now-lesson} !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
            else if (now == lesson)
            {
                Console.WriteLine("Lesson started");
            }
            else
            {
                Console.WriteLine($"Lesson star's in {now-lesson} ");
            }

           

        }
        public void AutoRecived()
        {
            int result = 0;
            foreach(int marks in exams)
            {
                if (marks == 12)
                {
                    result++;
                }
            }
            if (result == exams.Count)
            {
                Console.WriteLine("Good job!");
            }
        }
        public void Stipendia()
        {
            if (average >= 10)
            {
                Console.WriteLine("You have a 'salary' ");
            }
        }
       public  class AverageGradeComparer : IComparer<Student?>
        {
            public int Compare(Student? x, Student? y)
            {
                if(x==null || y==null) {
                    throw new ArgumentNullException("надати нормальні об'єкти, а не порожні посилання");
                }
                else  if (x.Averagemark.CompareTo(y.Averagemark) == 0)
                {
                     new Student.FullNameComparer();
                }
             
                
                  return x.Averagemark.CompareTo(y.Averagemark);
                
            }
        }

        public class FullNameComparer : IComparer<Student>
        {
            public int Compare(Student? x, Student? y)
            {
                if (x == null || y == null)
                {
                    throw new ArgumentNullException("надати нормальні об'єкти, а не порожні посилання");
                }
                else if (string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    new Student.AverageGradeComparer();
                }
             
                
                 return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
                
            }
        }
        public Student(string? name, string? secondname, string? father, int day, int month, int year, string street, string home, int lesson, int exam, int homework, int number)
        {
            SetName(name);
            SetSecondname(secondname);
            SetFather(father);
            SetDay(day);
            SetMonth(month);
            SetYear(year);
            SetAdress(street, home);
            SetLesson(lesson);
            SetExam(exam);
            SetHomework(homework);
            SetNumber(number);
            Name = name;
            Secondname = secondname;
            Age = 2025 - year;
            Averagemark = average;
            count++;

        }
        public Student(int count_lesson, int count_homework, int count_exam, int lesson, int exam, int homework)
        {
            for (int i = 0; i < count_lesson; i++)
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
            count++;
        }
        public Student() : this("", "", "", 0, 0, 0, "", "", 0, 0, 0, 0)
        {
            count++;
        }
        //Homework 6 overload
        public override bool Equals(object? someStranger)
        {
            if (someStranger is not Student whoIsIt)
            {
                Console.WriteLine("це не student або посилання є null");
                return false;
            }

 
            return whoIsIt.average == average;
        }
        public static bool operator ==(Student left, Student right)
        {

            if (left is null)
            {
                return right is null;
            }

            if (right is null)
            {
                return false;
            }

            return left.Equals(right);
        }
        public static bool operator !=(Student left, Student right)
        {
            return !(left == right);
        }
        public void  SetMiddle()
        {
            int midhomework=0;
            int midlesson=0;
            int midexam=0;
            foreach(int mid in lessons)
            {
                midlesson = midlesson + mid;
            }
            midlesson = midlesson / lessons.Count;
            foreach (int mid in exams)
            {
                midexam = midexam + mid;
            }
            midexam = midexam / exams.Count;
            foreach (int mid in homeworks)
            {
                midhomework = midhomework + mid;
            }
            midhomework = midhomework / homeworks.Count;
            average = (midhomework + midexam + midlesson) / 3;
        }
        //Homework 6 Overload
        public static bool operator true(Student s)
        {
            return s.average >= 7;
        }
        public static bool operator false(Student s)
        {
            return s.average < 7; 
        }

    }

    class Group 
    {
        List<string> students=new List <string>();
        List<Student> students2 = new List<Student>();
        string? group = "";
        string? type = "";
        int number_of_course = 0;
        int fails = 0;
        public int Count { get; set; }
        public string Type { get; set; }
        public int Number { get; set; }
        public delegate void MyEventGroup();
        private MyEventGroup? Party;
        private MyEventGroup? Session;

        public event MyEventHandler? GroupParty
        {
            add
            {
                Console.WriteLine("Обробник події додано");
                MyEventGroup? currentHandler;
                MyEventGroup? newHandler;
                do
                {
                    currentHandler = Party;
                    newHandler = (MyEventGroup?)Delegate.Combine(currentHandler, value);
                }
                while (Interlocked.CompareExchange(ref Party, newHandler, currentHandler) != currentHandler);
            }
            remove
            {
                Console.WriteLine("Обробник події прибрано");
                MyEventGroup? currentHandler;
                MyEventGroup? newHandler;
                do
                {
                    currentHandler = Party;
                    newHandler = (MyEventGroup?)Delegate.Remove(currentHandler, value);
                }
                while (Interlocked.CompareExchange(ref Party, newHandler, currentHandler) != currentHandler);
            }
        }
        public event MyEventGroup? Sessionpass
        {
            add
            {
                Console.WriteLine("Обробник події додано");
                MyEventGroup? currentHandler;
                MyEventGroup? newHandler;
                do
                {
                    currentHandler = Session;
                    newHandler = (MyEventGroup?)Delegate.Combine(currentHandler, value);
                }
                while (Interlocked.CompareExchange(ref Session, newHandler, currentHandler) != currentHandler);
            }
            remove
            {
                Console.WriteLine("Обробник події прибрано");
                MyEventGroup? currentHandler;
                MyEventGroup? newHandler;
                do
                {
                    currentHandler = Session;
                    newHandler = (MyEventGroup?)Delegate.Remove(currentHandler, value);
                }
                while (Interlocked.CompareExchange(ref Session, newHandler, currentHandler) != currentHandler);
            }
        }
        public void StartPartyTime()
        {
            if (Party != null)
                Party();
        }
        public void StartEventPass()
        {
            if (Session != null)
                Session();
        }
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
        public Group(Student[] students)
        {
            for(int i = 0; i < students.Count(); i++)
            {
                students2[i] = students[i];
            }
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
            Count = students.Count;
            Type = type;
            Number = number_of_course;


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
        public void AddStudent(string student)
        {
            students.Add(student);
        }
        public void AnotherGroup(string student,Group p_new)
        {
            students.Remove(student);
            p_new.students.Add(student);
        }
        public void CountBad(Student p)
        {
            if (p.BadExams() == true)
            {
                fails++;
            }
        }
        public void Celebrate(){
            int goodjob = 0;
          for(int i=0; i < students2.Count(); i++)
            {
                if (students2[i].GetExamMark(0) == 12)
                {
                    goodjob++;
                }
            }
            if (students2.Count() == goodjob)
            {
                Console.WriteLine("WE HAVE PARTY");
            }
            else
            {
                Console.WriteLine("We are loser`s");
            }

            }
        public void Passed()
        {
            int goodjob = 0;
            for (int i = 0; i < students2.Count(); i++)
            {
                if (students2[i].GetLessonMark(0) == 12)
                {
                    goodjob++;
                }
            }
            if (students2.Count() == goodjob)
            {
                Console.WriteLine("WE CAN HAVE A BREAK");
            }
            else
            {
                Console.WriteLine("We are loser`s");
            }

        }
        public override bool Equals(object? someStranger)
        {
            if (someStranger is not Group whoIsIt)
            {
                Console.WriteLine("це не student або посилання є null");
                return false;
            }


            return whoIsIt.students == students;
        }
        public static bool operator ==(Group left, Group  right)
        {

            if (left is null)
            {
                return right is null;
            }

            if (right is null)
            {
                return false;
            }

            return left.Equals(right);
        }
        public static bool operator !=(Group left, Group right)
        {
            return !(left == right);
        }
        public int  this[string name]
        {
            get
            {
                return students.IndexOf(name);
            }
            set
            {
                students.Sort();
            }
        }
    }
    //Homework 5 Exeptions
    class StudentManagmentExeption:ApplicationException // ApplicationException — базовий клас для користувацьких винятків
    {      
            public StudentManagmentExeption() { }
            public StudentManagmentExeption(string message) : base(message) { } 
    }
    class InvalidGradeExeption : StudentManagmentExeption
    {
        private string GradeDescription = "";

        public InvalidGradeExeption() { }
        public InvalidGradeExeption(string message) : base(message) { }

        public string GetGrade() 
        {
            return GradeDescription;
        }

        public void SetGrade(string value)
        {
            GradeDescription = value;
        }
    }
    class StudentNotFoundExeptcion : StudentManagmentExeption
    {
        private string StudentDescription = "";

        public StudentNotFoundExeptcion() { }
        public StudentNotFoundExeptcion(string message) : base(message) { }

        public string GetStudent()
        {
            return StudentDescription;
        }

        public void SetStudent(string value)
        {
            StudentDescription = value;
        }
    }
    class InvalidStudentDataExpetion : StudentManagmentExeption
    {
        private string DataDescription = "";

        public InvalidStudentDataExpetion() { }
        public InvalidStudentDataExpetion(string message) : base(message) { }

        public string GetData()
        {
            return DataDescription;
        }

        public void SetData(string value)
        {
            DataDescription = value;
        }
    }
    class GroupManagmentExeption : ApplicationException // ApplicationException — базовий клас для користувацьких винятків
    {
        public GroupManagmentExeption() { }
        public GroupManagmentExeption(string message) : base(message) { }
    }
    class GroupFullExeption : GroupManagmentExeption
    {
        private string FullDescription = "";

        public GroupFullExeption() { }
        public GroupFullExeption(string message) : base(message) { }

        public string GetGrade()
        {
            return FullDescription;
        }

        public void SetGrade(string value)
        {
            FullDescription = value;
        }
    }
    class InvalidDataExeptcion : GroupManagmentExeption
    {
        private string GroupDataDescription = "";

        public InvalidDataExeptcion() { }
        public InvalidDataExeptcion(string message) : base(message) { }

        public string GetGroupData()
        {
            return GroupDataDescription;
        }

        public void SetGroupData(string value)
        {
            GroupDataDescription = value;
        }
    }
    class FailedTransferExpetion : GroupManagmentExeption
    {
        private string TransferDescription = "";

        public FailedTransferExpetion() { }
        public FailedTransferExpetion(string message) : base(message) { }

        public string GetData()
        {
            return TransferDescription;
        }

        public void SetData(string value)
        {
            TransferDescription = value;
        }
    }
    class GroupCollection : IEnumerable<Student?> // явно реалізуємо інтерфейс IEnumerable<T>
    {
        // зазвичай у такому класі присутнє інкапсульоване поле-колекція з будь-якою кількістю елементів та будь-якими типами
        private Student[] student = new Student[3];
        // List<Monster> monsters = new List<Monster>();

        public GroupCollection()
        {
            student[0] = new Student();
            student[1] = new Student();
            student[2] = new Student();
        }

        // при бажанні, можна буде дописати методи Add, Remove, Clear, Count, Search ...

        // у класі-колекції повинен бути публічний метод GetEnumerator без параметрів
        public IEnumerator<Student?> GetEnumerator()
        {
            // з цього методу потрібно повернути посилання на об'єкт-перелічувач колекції
            return new StudentEnumerator(student); // зазвичай у конструктор при створенні об'єкта-перелічувача відправляється посилання на колекцію даних
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator(); // неузагальнений варіант (для повної сумісності з legacy-кодом, наприклад, методами, які приймають IEnumerable без <T>, потрібно реалізувати обидві версії)
    }

    // окремий клас, який описує алгоритм перелічення елементів
    class StudentEnumerator : IEnumerator<Student?>
    {
        // ще одне посилання на колекцію (але вже для перелічувача)
        private Student[]? student = null;

        // явний конструктор для отримання посилання на колекцію
        public StudentEnumerator(Student[]? student)
        {
            this.student = student; // запам'ятали посилання на колекцію
            index = -1; // початковий стан перед першим викликом MoveNext
        }

        // у класі-перелічувачі обов'язково повинно бути свойство Current (посилання на наступний необроблений об'єкт)
        public Student? Current
        {
            get;
            private set; // зазвичай секція set закрита (бо для стандартних колекцій через цю властивість не можна змінювати значення елементів колекції)
            // класично, foreach - це цикл на перегляд (читання) елементів
        }

        object? IEnumerator.Current => Current;

        // у класі можуть бути додаткові поля (щоб не загубитися в процесі огляду колекції)
        private int index = 0;

        // у класі-перелічувачі обов'язково повинен бути метод MoveNext
        // він перевіряє, чи є взагалі елементи в колекції, якщо їх спочатку немає - повертає false (умова виходу з foreach)
        // також перевіряє, чи залишилися необроблені елементи - якщо все переглянули - повертається false (у колекції більше нічого робити)
        // якщо необроблені елементи ще є - виставляється посилання (через Current) на наступний елемент, і повертається true
        public bool MoveNext()
        {
            if (student?.Length == 0 || index >= student?.Length - 1)
                return false;

            Current = student?[++index];
            return true;
        }

        // скидає перелічувач на початок
        public void Reset()
        {
            index = -1;
        }

        // звільняє ресурси (для простоти прикладу - порожній)
        public void Dispose() { }
    }
 
    internal class Program
    {
        static void Main(string[] args)
        {
            //Student
            //Console.WriteLine("Hello, World!");
            Student student = new Student(3, 2, 1, 12, 11, 1);
            Student student2 = new Student(3, 5, 1, 12, 11, 8);
            student.SetMiddle();
            student2.SetMiddle();
            Console.WriteLine(student==student2);//Hom6
            //Console.WriteLine(student.GetExam());
            //Console.WriteLine(student.GetLessons());
            //Console.WriteLine(student.GetHomework());
            InvalidGradeExeption error = new InvalidGradeExeption();
            error.SetGrade("Grade must be higher that null");
            Console.WriteLine($"error:{error.GetGrade()}");
            Group group= new Group();
            group.Print();
            Group g2 = new Group();
            Group g3 = new Group(group, g2);
            g2.Print();
            g2.AddStudent( "Arsenii");
            Console.WriteLine(g2["Arsenii"]);//Hom 7
            g2.AnotherGroup("Arsenii", group);
            Console.WriteLine(student.Name);//Hom7
            Console.WriteLine(group.Count);// Hom7
            Student[] crowd = [
                new Student(),
                new Student(),
                new Student()
             ];
            Array.Sort(crowd, new Student.AverageGradeComparer());
            for (var tmp = (StudentEnumerator?)crowd.GetEnumerator(); tmp.MoveNext();)
            {
                var item = tmp?.Current;
                Console.Write(item + " ");
            }
            Student[] clever = Filter(crowd, p => p.Averagemark > 10,p2=> p2.Averagemark==10);
            foreach (var person in clever) Console.WriteLine(person);
            Student[] name = Filter(crowd, p => p.Name.StartsWith("B"), p2 => p2.Name.StartsWith("Б"));
            foreach (var person in clever) Console.WriteLine(person);
            List<int> fail = student.GetExam();
            int i = 0;
            Student[] exam= Filter2(crowd, p => p.GetExamMark(i) == fail[0]); 
            foreach (var mark in fail) {
                i++;
               exam = Filter2(crowd, p => p.GetExamMark(i) == mark);
            }
            foreach (var person in exam) Console.WriteLine(person);
            Student[] homework = Filter2(crowd, p => p.GetHomework()==null);
            foreach (var person in homework) Console.WriteLine(person);
            Array.Sort(crowd, new Student.AverageGradeComparer());
            Student[] bestaverege = Filter2(crowd, p => p.Averagemark == crowd[0].Averagemark);
            foreach (var person in bestaverege) Console.WriteLine(person);
            Student[] longname = Filter(crowd, p => p.Name.Length >5,p2 => p2.Name.Length ==5 );
            foreach (var person in longname) Console.WriteLine(person);
            Student[] marks = Filter3(crowd, p => p.GetExam() == crowd[0].GetExam(), p2 => p2.GetHomework() == crowd[0].GetHomework(), p3 => p3.GetLessons() == crowd[0].GetLessons());
            for(int a=0;a<crowd.Length;a++)
            {
                marks = Filter3(crowd, p => p.GetExam() == crowd[a].GetExam(), p2 => p2.GetHomework() == crowd[a].GetHomework(), p3 => p3.GetLessons() == crowd[a].GetLessons());
            }
            foreach (var person in marks) Console.WriteLine(person);
            Student[] istwo = Filter3(crowd, p => p.GetExam().Count%2 ==0 , p2 => p2.GetHomework().Count % 2 == 0, p3 => p3.GetLessons().Count % 2 == 0);
            Console.WriteLine();
            var miss = new Student();
            miss.Time += student2.TimeOf;
            var autos = new Student();
            autos.Auto += student2.AutoRecived;
            var awarded = new Student();
            awarded.Award += student2.Stipendia;
            miss.StartEventTime();
            autos.StartEventAutomat();
            awarded.StartEventAward();
            Group groups = new Group(crowd);
            var party = new Group();
            party.GroupParty += groups.Celebrate;
            var sucsees = new Group();
            sucsees.Sessionpass += groups.Passed;
            party.StartPartyTime();
            sucsees.StartEventPass();






        }

        private static void Miss_Time()
        {
            throw new NotImplementedException();
        }

        static Student[] Filter(Student[] student, StudentFilter condition, StudentFilter condition2)
        {
            var result = new List<Student>();
            foreach (var p in student)
            {
                if (condition(p) || condition2(p))
                {
                    result.Add(p);
                }
            }
            return result.ToArray();


        }
        static Student[] Filter2(Student[] student, StudentFilter condition)
        {
            var result = new List<Student>();
            foreach (var p in student)
            {
                if (condition(p))
                {
                    result.Add(p);
                }
            }
            return result.ToArray();


        }
        static Student[] Filter3(Student[] student, StudentFilter condition, StudentFilter condition2, StudentFilter condition3)
        {
            var result = new List<Student>();
            foreach (var p in student)
            {

                
                    if (condition(p) && condition2(p) && condition3(p))
                    {
                        result.Add(p);
                    }
                

            }
            return result.ToArray();


        }
    }
}
