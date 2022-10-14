class Student : Person
{

    private string school;
    private string educationLevel;
    public Student(Prefix prefix,
             string name,
             string surname,
             string age,
             string educationLevel,
             string allergic,
             Religion religion,
             string school)
    : base(prefix, name, surname, age, allergic, religion)
    {
        this.educationLevel = educationLevel;
        this.school = school;
    }
    public string GetEducationLevel()
    {
        return this.educationLevel;
    }

}