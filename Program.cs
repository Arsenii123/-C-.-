using System;
using System.Collections.Specialized;
using System.Text.Json.Serialization;
using System.Threading;
using System.Collections;
using System.Text;
namespace Homework2
{
    class Student
    {
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
        public void GetAdress()
        {

            foreach (string number in adress)
            {
                Console.WriteLine(number);
            }

        }
        public int GetBirthday()
        {

            foreach (int number in birthday)
            {
                return number;
            }
            return 0;
        }
        public void GetExam()
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
        public void GetLessons()
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

    class Group:Student 
    {
        List<string> students=new List <string>();
        string? group = "";
        string? type = "";
        int number_of_course = 0;
        int fails = 0;
        public int Count { get; set; }
        public string Type { get; set; }
        public int Number { get; set; }
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

            Console.WriteLine();



        }
    }
}
