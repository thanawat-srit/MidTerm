enum Prefix {
    Mr = 1,
    Mrs,
    Ms
}
enum Religion {
    Buddhist = 1,
    Christian,
    Islam
}

abstract class Person{
    private Prefix prefix;
    private string name;
    private string surname;
    private string age;
    private string allergic;
    private Religion religion;

    public Person(
             Prefix prefix, 
             string name, 
             string surname, 
             string age, 
             string allergic, 
             Religion religion
            )
    {
        this.prefix = prefix;
        this.name = name;
        this.surname =surname;
        this.age = age;
        this.allergic = allergic;
        this.religion = religion;
    }

    public Prefix Getprefix(){
        return this.prefix;
    }
    public string Getname(){
        return this.name;
    }
    public string Getsurname(){
        return this.surname;
    }
    public string Getage(){
        return this.age;
    }
    public string Getallergic(){
        return this.allergic;
    }
    public Religion Getreligion(){
        return this.religion;
    }
}