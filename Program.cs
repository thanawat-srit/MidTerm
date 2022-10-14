enum Menu
{
    RegisterExhibition = 1,
    ShowExhibitorStatistics,
    Login
}
enum AdminMenu
{
    RegisterExhibition = 1,
    ShowAllCollegianExhibitor,
    ShowAllStudentExhibitor,
    ShowAllTeacherExhibitor,
    LogOut
}
enum PersonType
{
    Collegian = 1,
    Student,
    Teacher
}

class Program
{
    static PersonList personList;
    static AdminList adminList;
    static int count = 0;

    static void Main(string[] args)
    {
        PreparePersonListWhenProgramIsLoad();
        PrepareAdminListWhenProgramIsLoad();

        PrintMenuScreen();
    }
    static void PrintMenuScreen()
    {
        Console.Clear();

        PrintListMenu();
        InputMenuFromKeyBoard();
    }
    static void PrintListMenu()
    {
        Console.WriteLine("Menu Idia camp 2022");
        Console.WriteLine("*************************************************");
        Console.WriteLine("1. Registeration Exhibition");
        Console.WriteLine("2. Show Exhibitor Statistics");
        Console.WriteLine("3. Login");
        Console.WriteLine("*************************************************");
    }
    static void BackToMenu()
    {
        Console.Clear();

        PrintListMenu();
        InputMenuFromKeyBoard();
    }
    static void InputMenuFromKeyBoard()
    {
        Console.Write("Please input Menu:");
        Menu menu = (Menu)(int.Parse(Console.ReadLine()));

        PersentMenu(menu);
    }
    static void PersentMenu(Menu menu)
    {
        switch (menu)
        {
            case Menu.RegisterExhibition:
                ShowInputRegisterationExhibitionScreen();
                break;
            case Menu.ShowExhibitorStatistics:
                Program.personList.FetchShowExhibitorStatistics();
                BackToMenu();
                break;
            case Menu.Login:
                ShowInputLoginExhibitionScreen();
                break;
            default:
                break;
        }
    }
    static void PersentAdminMenu(AdminMenu adminMenu)
    {
        switch (adminMenu)
        {
            case AdminMenu.RegisterExhibition:
                count = 1;
                ShowInputRegisterationExhibitionScreen();
                break;
            case AdminMenu.ShowAllCollegianExhibitor:
                Program.personList.FetchCollegianPersonList();
                count = 1;
                BackToMenu();
                break;
            case AdminMenu.ShowAllStudentExhibitor:
                Program.personList.FetchStudentPersonList();
                count = 1;
                BackToMenu();
                break;
            case AdminMenu.ShowAllTeacherExhibitor:
                Program.personList.FetchTeacherPersonList();
                count = 1;
                BackToMenu();
                break;
            case AdminMenu.LogOut:
                count = 0;
                BackToMenu();
                break;
            default:
                break;
        }
    }
    static void ShowInputRegisterationExhibitionScreen()
    {
        Console.Clear();

        PrintListTypePerson();
        InputTypePersonFromKeyBoard();
    }
    static void ShowInputLoginExhibitionScreen()
    {
        Console.Clear();
        if (count == 1)
        {
            Console.Clear();
            PrintInsideMenu();

            Console.Write("Please input Menu:");
            AdminMenu adminmenu = (AdminMenu)(int.Parse(Console.ReadLine()));

            PersentAdminMenu(adminmenu);
        }
        string inEmail = InputEmail();
        string inPassword = InputPassword();
        LoginCheck(inEmail, inPassword);

    }
    static void PrintListTypePerson()
    {
        Console.WriteLine("Menu Registeration Idia camp 2022");
        Console.WriteLine("*************************************************");
        Console.WriteLine("1. Registeration New Collegian");
        Console.WriteLine("2. Registeration New Student");
        Console.WriteLine("3. Registeration New Teacher");
        Console.WriteLine("*************************************************");
    }
    static void PrintInsideMenu()
    {
        Console.WriteLine("Menu Admin Idia camp 2022");
        Console.WriteLine("*************************************************");
        Console.WriteLine("1. Registeration Exhibition");
        Console.WriteLine("2. Show all collegian participating in Idia camp 2022");
        Console.WriteLine("3. Show all student participating in Idia camp 2022");
        Console.WriteLine("4. Show all teacher participating in Idia camp 2022");
        Console.WriteLine("5. Log out");
        Console.WriteLine("*************************************************");
    }
    static void InputTypePersonFromKeyBoard()
    {
        Console.Write("Please input Person Type:");
        PersonType persontype = (PersonType)(int.Parse(Console.ReadLine()));

        PersentPersonType(persontype);
    }
    static void PersentPersonType(PersonType persontype)
    {
        switch (persontype)
        {
            case PersonType.Collegian:
                ShowInputRegisterationNewCollegianScreen();
                break;
            case PersonType.Student:
                ShowInputRegisterationNewStudentScreen();
                break;
            case PersonType.Teacher:
                ShowInputRegisterationNewTeacherScreen();
                break;
            default:
                break;
        }
    }
    static void ShowInputRegisterationNewCollegianScreen()
    {
        Console.Clear();

        PrintHeaderRegisterCollegian();

        InputNewCollegianFromKeyboard();
        BackToMenu();
    }
    static void ShowInputRegisterationNewStudentScreen()
    {
        Console.Clear();

        PrintHeaderRegisterStudent();

        InputNewStudentFromKeyboard();
        BackToMenu();
    }
    static void ShowInputRegisterationNewTeacherScreen()
    {
        Console.Clear();

        PrintHeaderRegisterTeacher();

        InputNewTeacherFromKeyboard();
        BackToMenu();
    }
    static void PrintHeaderRegisterCollegian()
    {
        Console.Clear();
        Console.WriteLine("Register New Collegian");
        Console.WriteLine("*************************************************");
    }
    static void PrintHeaderRegisterStudent()
    {
        Console.Clear();
        Console.WriteLine("Register New Student");
        Console.WriteLine("*************************************************");
    }
    static void PrintHeaderRegisterTeacher()
    {
        Console.Clear();
        Console.WriteLine("Register New Teacher");
        Console.WriteLine("*************************************************");
    }

    static void InputNewCollegianFromKeyboard()
    {

        Console.Clear();
        PrintHeaderRegisterCollegian();
        Prefix inPrefix = InputPrefix();
        string inName = InputName();
        string inSurName = InputSurName();
        string inStudentID = InputStudentID();
        string inAge = InputAge();
        string inAllergic = InputAllergic();
        Religion inReligion = InputReligion();

        Collegian collegian = new Collegian(inPrefix,
         inName,
         inSurName,
         inStudentID,
         inAge,
         inAllergic,
         inReligion);

        if (CheckPersonList(inPrefix, inName, inSurName))
        {
            Program.personList.AddNewPerson(collegian);
            if (CheckInputAdmin())
            {
                string inEmail = InputEmail();
                string inPassword = InputPassword();
                Admins admin = new Admins(inEmail, inPassword);
                if (CheckAdminList(inEmail))
                {
                    Program.adminList.AddNewAdmin(admin);
                    BackToMenu();
                }
                else
                {
                    InputNewCollegianFromKeyboard();
                }
            }
        }
        else
        {
            InputNewCollegianFromKeyboard();
        }
    }
    static void InputNewStudentFromKeyboard()
    {

        Console.Clear();
        PrintHeaderRegisterStudent();
        Prefix inPrefix = InputPrefix();
        string inName = InputName();
        string inSurName = InputSurName();

        Student student = new Student(inPrefix,
         inName,
         inSurName,
         InputAge(),
         InputEducationLevel(),
         InputAllergic(),
         InputReligion(),
         InputSchool()
        );

        if (CheckPersonList(inPrefix, inName, inSurName))
        {
            Program.personList.AddNewPerson(student);
            BackToMenu();
        }
        else
        {
            InputNewStudentFromKeyboard();
        }


    }

    static void InputNewTeacherFromKeyboard()
    {

        Console.Clear();
        PrintHeaderRegisterTeacher();
        Prefix inPrefix = InputPrefix();
        string inName = InputName();
        string inSurName = InputSurName();
        string inAge = InputAge();
        Placement inPlacement = InputPlacement();
        string inAllergic = InputAllergic();
        Religion inReligion = InputReligion();
        InputCar();

        Teacher teacher = new Teacher(inPrefix,
         inName,
         inSurName,
         inAge,
         inPlacement,
         inAllergic,
         inReligion
        );

        if (CheckPersonList(inPrefix, inName, inSurName))
        {
            Program.personList.AddNewPerson(teacher);
            if (CheckInputAdmin())
            {
                string inEmail = InputEmail();
                string inPassword = InputPassword();
                Admins admin = new Admins(inEmail, inPassword);
                if (CheckAdminList(inEmail))
                {
                    Program.adminList.AddNewAdmin(admin);
                    BackToMenu();
                }
                else
                {
                    InputNewTeacherFromKeyboard();
                }
            }
        }
        else
        {
            InputNewTeacherFromKeyboard();
        }


    }
    static void PreparePersonListWhenProgramIsLoad()
    {
        Program.personList = new PersonList();
    }
    static void PrepareAdminListWhenProgramIsLoad()
    {
        Program.adminList = new AdminList();
    }

    static Prefix InputPrefix()
    {
        Console.WriteLine("1. Mr | 2. Mrs | 3. Ms");
        Console.WriteLine("*************************************************");
        Console.Write("Name Prefix: ");
        Prefix prefix = (Prefix)(int.Parse(Console.ReadLine()));

        return prefix;
    }
    static string InputEducationLevel()
    {
        Console.WriteLine("**************************************************************************************");
        Console.WriteLine("1. Secondary school Grade 4 | 2. Secondary school Grade 5 | 3. Secondary school Grade 6");
        Console.WriteLine("**************************************************************************************");
        Console.Write("Education Level: ");
        string educationLevel = (Console.ReadLine());
        switch (educationLevel)
        {
            case ("1"):
                return "Secondary school Grade 4";
            case ("2"):
                return "Secondary school Grade 5";
            case ("3"):
                return "Secondary school Grade 6";
        }

        return "";
    }
    static Placement InputPlacement()
    {
        Console.WriteLine("*************************************************");
        Console.WriteLine("1. Dean | 2. Department Head | 3. Full Time Teacher");
        Console.WriteLine("*************************************************");
        Console.Write("Placement: ");
        Placement placement = (Placement)(int.Parse(Console.ReadLine()));

        return placement;
    }
    static string InputName()
    {
        Console.Write("Name: ");

        return Console.ReadLine();
    }
    static string InputSurName()
    {
        Console.Write("Surname: ");

        return Console.ReadLine();
    }
    static string InputStudentID()
    {
        Console.Write("Student ID: ");

        return Console.ReadLine();
    }
    static string InputAge()
    {
        Console.Write("Age: ");

        return Console.ReadLine();
    }
    static string InputAllergic()
    {
        Console.Write("Allergic: ");

        return Console.ReadLine();
    }
    static string InputSchool()
    {
        Console.Write("School: ");

        return Console.ReadLine();
    }
    static Religion InputReligion()
    {
        Console.WriteLine("*************************************************");
        Console.WriteLine("1. Buddhist | 2. Christian | 3. Islam | 4. Other");
        Console.WriteLine("*************************************************");
        Console.Write("Religion: ");
        Religion religion = (Religion)(int.Parse(Console.ReadLine()));

        return religion;
    }

    static bool CheckInputAdmin()
    {
        Console.WriteLine("*************************************************");
        Console.WriteLine("1. Yes | 2. No");
        Console.WriteLine("*************************************************");
        Console.Write("Admin Register?: ");
        int checkAdmin = int.Parse(Console.ReadLine());
        if (checkAdmin == 1)
        {
            return true;
        }
        return false;
    }
    static void InputCar()
    {
        Console.WriteLine("*************************************************");
        Console.WriteLine("1. Yes | 2. No");
        Console.WriteLine("*************************************************");
        Console.Write("Have you brought a car to join Idia camp 2022?: ");
        int checkAdmin = int.Parse(Console.ReadLine());
        if (checkAdmin == 1)
        {
            Cars car = new Cars(InputCarNumberRegistration());
        }
    }
    static string InputEmail()
    {
        Console.Write("Email: ");

        return Console.ReadLine();
    }
    static string InputPassword()
    {
        Console.Write("Password: ");

        return Console.ReadLine();
    }
    static string InputCarNumberRegistration()
    {
        Console.Write("Car Number Registration: ");

        return Console.ReadLine();
    }
    static bool CheckPersonList(Prefix prefix, string name, string surname)
    {

        foreach (Person person in Program.personList.GetListPerson())
        {
            if (prefix == person.Getprefix() &&
            name == person.Getname() &&
            surname == person.Getsurname())
            {
                Console.Clear();
                Console.WriteLine("Invalid email. Please try again.");
                Console.WriteLine("*************************************************");
                Console.WriteLine("Please Enter Someting To Continue");
                Console.ReadLine();
                return false;
            }
        }
        return true;
    }
    static bool CheckAdminList(string email)
    {
        foreach (Admins admin in Program.adminList.GetListAdmin())
        {
            if (email == admin.GetEmail() ||
                email == "exit")
            {
                Console.Clear();

                Console.WriteLine("User is already registered. Please try again.");
                Console.WriteLine("*************************************************");
                Console.WriteLine("Please Enter Someting To Continue");
                Console.ReadLine();
                return false;
            }
        }
        return true;
    }
    static void LoginCheck(string email, string password)
    {
        foreach (Admins admin in Program.adminList.GetListAdmin())
        {
            if (email == admin.GetEmail() && password == admin.GetPassword())
            {
                Console.Clear();
                PrintInsideMenu();

                Console.Write("Please input Menu:");
                AdminMenu adminmenu = (AdminMenu)(int.Parse(Console.ReadLine()));

                PersentAdminMenu(adminmenu);
            }
            else if (email == "exit")
            {
                count = 0;
                BackToMenu();
            }
            else
            {
                Console.Clear();

                Console.WriteLine("Incorrect email or password. Please try again.");
                Console.WriteLine("*************************************************");
                Console.WriteLine("Please Enter Someting To Continue");

                Console.ReadLine();
                ShowInputLoginExhibitionScreen();
            }
        }
    }
}