enum Placement
{
    Dean = 1,
    DepartmentHead,
    FullTimeTeacher
}
class Teacher : Person
{
    private Placement placement;

    public Teacher(Prefix prefix,
             string name,
             string surname,
             string age,
             Placement placement,
             string allergic,
             Religion religion)
    : base(prefix, name, surname, age, allergic, religion)
    {
        this.placement = placement;
    }
}