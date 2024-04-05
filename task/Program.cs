namespace task
{
    internal class Program
    {
        static Group group = new Group();
        static void Main(string[] args)
        {
            Console.WriteLine("Yeni telebe yarat:");
            Student student = new Student();
          

            int choice;
            do
            {
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("1. Show user info");
                Console.WriteLine("2. Yeni group yarat");
                Console.WriteLine("3. Telebe parametrleri");
                Console.WriteLine("0. programdan cix");
                Console.Write("Secimini qeyd et: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        student.ShowInfo();
                        break;
                    case 2:
                        CreateNewGroup(group);
                        break;
                    case 3:
                        StudentOperationsMenu();
                        break;
                    case 0:
                        Console.WriteLine("Programdan cixilir.");
                        break;
                    default:
                        Console.WriteLine("Bele bir secom yoxdur.");
                        break;
                }
            } while (choice != 0);
        }

        static Student CreateUser()
        {
            Student user = new Student();
            Console.Write(" Fullname daxil edin: ");
            user.FullName = Console.ReadLine();
            Console.Write("Bal daxxil edib: ");
            user.Point = Convert.ToDouble(Console.ReadLine());
            return user;
        }

        static void CreateNewGroup(Group group)
        {           
            Console.WriteLine($"Group No: {group.GroupNo}");
            Console.WriteLine("Yeni qrup yaradilid.");
        }

        static void StudentOperationsMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("\nTelebe parametr Menu:");
                Console.WriteLine("1. Butun telebeleri goster");
                Console.WriteLine("2. id gore telebeleri goster");
                Console.WriteLine("3. Telebe elave et");
                Console.WriteLine("0. Geri qayit");
                Console.Write("Seciminizi qeyd edin: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        group.GetAllStudent();
                        break;
                    case 2:
                        Console.Write("ID qey edin: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Student student = group.GetStudent(id);
                        if (student != null)
                            student.ShowInfo();
                        else
                            Console.WriteLine("Telebe tapilmadi.");
                        break;
                    case 3:
                        Student newStudent = CreateUser();
                        group.AddStudent(newStudent);
                        break;
                    case 0:
                        Console.WriteLine("Evvelki menuya qayidilir");
                        break;
                    default:
                        Console.WriteLine("bele bir secim yoxdur.");
                        break;
                }
            } while (choice != 0);
        }
    }

} 
    
    
    internal class Student
    {
        public int Id { get; set; }
        private static int _id;
        public string FullName { get; set; }
        public double Point
        {
            get
            {
                return Point;
            }
            set
            {
                if (value < 0)
                {
                    Point = value;
                }
            }
        }
        public Student()
        {
            _id++;
            _id = Id;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"FullName: {FullName}, Point: {Point}");
        }
    }
    internal class Group
    {
        public int GroupNo { get; set; }
        public Student[] Students = { };

        public int StudentLimit
        {
            get
            {
                return StudentLimit;
            }
            set
            {
                if (StudentLimit > 5 && StudentLimit < 18)
                {
                    StudentLimit = value;
                }
            }
        }
        public void AddStudent(Student student)
        {


            if (Students.Length < StudentLimit)
            {
                Array.Resize(ref Students, Students.Length + 1);
                Students[Students.Length - 1] = student;
            }
            else
            {
                Console.WriteLine("Sizin ucun ayrilan limiti kecmisiniz");
            }

        }
        public Student GetStudent(int id)
        {
            for (int i = 0; i < Students.Length; i++)
            {
                if (Students[i].Id == id)
                {
                    return Students[i];
                }
            }
            return null;
        }
        public void GetAllStudent()
        {
            Console.WriteLine(Students);
        }
        public void CheckGroupNo(string groupNo)
        {
            bool check = false;

            if (groupNo.Length == 5)
            {
                if (char.IsUpper(groupNo[0])) check = true;
                if (char.IsUpper(groupNo[1])) check = true;
                if (char.IsDigit(groupNo[2])) check = true;
                if (char.IsDigit(groupNo[3])) check = true;
                if (char.IsDigit(groupNo[4])) check = true;
            }
            else
            {
                Console.WriteLine("Qrupun adi duzgun daxil edilmemisdir");
            }

        }
    }
