using System.Collections.Generic;
class AdminList
{
    private List<Admins> adminList;
    public AdminList()
    {
        this.adminList = new List<Admins>();
    }
    public void AddNewAdmin(Admins admin)
    {
        this.adminList.Add(admin);
    }
    public List<Admins> GetListAdmin()
    {
        return this.adminList;
    }
}