class Collegian : Person
{
    private string studentID;

    public Collegian(Prefix prefix,
             string name,
             string surname,
             string studentID,
             string age,
             string allergic,
             Religion religion
                        )
    : base(prefix, name, surname, age, allergic, religion)
    {
        this.studentID = studentID;
    }
}