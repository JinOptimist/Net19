namespace MyCustomLinq.Models
{
    [Flags]
    public enum Permission
    {
        ReadNews = 1,
        WriteNews = 2,

        CommonUser = 3,

        EditNews = 4,

        DeleteUser = 16,
        AddUser = 32

    }
}
