using System.Collections.Generic;

class PersonList
{
    private List<Person> personList;

    public PersonList()
    {
        this.personList = new List<Person>();
    }
    public void AddNewPerson(Person person)
    {
        this.personList.Add(person);
    }

    public List<Person> GetListPerson()
    {
        return this.personList;
    }
    public void FetchCollegianPersonList()
    {
        Console.Clear();

        Console.WriteLine("All Collegian Exhibitor List");
        Console.WriteLine("*************************************************");

        foreach (Person person in this.personList)
        {
            if (person is Collegian)
            {
                Console.WriteLine("{0} {1} {2} \n",
                person.Getprefix(),
                person.Getname(),
                person.Getsurname());
            }
        }
        Console.WriteLine("*************************************************");
        Console.WriteLine("Please Enter Someting To Continue");
        Console.ReadLine();
    }
    public void FetchStudentPersonList()
    {
        Console.Clear();

        Console.WriteLine("All Student Exhibitor List");
        Console.WriteLine("*************************************************");

        foreach (Person person in this.personList)
        {
            if (person is Student)
            {
                Console.WriteLine("{0} {1} {2} \n",
                person.Getprefix(),
                person.Getname(),
                person.Getsurname());
            }
        }
        Console.WriteLine("*************************************************");
        Console.WriteLine("Please Enter Someting To Continue");
        Console.ReadLine();
    }
    public void FetchTeacherPersonList()
    {
        Console.Clear();

        Console.WriteLine("All Teacher Exhibitor List");
        Console.WriteLine("*************************************************");

        foreach (Person person in this.personList)
        {
            if (person is Teacher)
            {
                Console.WriteLine("{0} {1} {2} \n",
                person.Getprefix(),
                person.Getname(),
                person.Getsurname());
            }
        }
        Console.WriteLine("*************************************************");
        Console.WriteLine("Please Enter Someting To Continue");
        Console.ReadLine();
    }
    public void FetchShowExhibitorStatistics()
    {
        Console.Clear();

        Console.WriteLine("Exhibitor Statistics List");
        Console.WriteLine("*************************************************");
        int TotalTeacher = 0;
        int TotalStudent = 0;
        int TotalCollegian = 0;
        int Year4 = 0;
        int Year5 = 0;
        int Year6 = 0;

        foreach (Person person in this.personList)
        {
            if (person is Teacher)
            {
                TotalTeacher++;
            }
            if (person is Student)
            {
                TotalStudent++;
                foreach (Student student in this.personList)
                {
                    if (student.GetEducationLevel() == "Secondary school Grade 4")
                    {
                        Year4++;
                    }
                    if (student.GetEducationLevel() == "Secondary school Grade 5")
                    {
                        Year5++;
                    }
                    if (student.GetEducationLevel() == "Secondary school Grade 6")
                    {
                        Year6++;
                    }
                }
            }
            if (person is Collegian)
            {
                TotalCollegian++;
            }

        }

        Console.WriteLine("Total number of Teachers: {0}", TotalTeacher);
        Console.WriteLine("Total number of Student: {0}", TotalStudent);
        Console.WriteLine("Total number of Collegian: {0}", TotalCollegian);
        Console.WriteLine("Total number of Students in Grade 4: {0}", Year4);
        Console.WriteLine("Total number of Students in Grade 5: {0}", Year5);
        Console.WriteLine("Total number of Students in Grade 6: {0}", Year6);
        Console.WriteLine("*************************************************");
        Console.WriteLine("Please Enter Someting To Continue");
        Console.ReadLine();
    }
}