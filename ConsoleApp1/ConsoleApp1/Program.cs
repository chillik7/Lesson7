using System;
public class AdminDeletionException : Exception
{
    public AdminDeletionException() : base("Невозможно удалить главного администратора.") { }

    public AdminDeletionException(string message) : base(message) { }

    public AdminDeletionException(string message, Exception innerException) : base(message, innerException) { }
}
public class UserManager
{
    public void DeleteUser(string role)
    {
        if (role == "Admin")
        {
            throw new AdminDeletionException();
        }
        Console.WriteLine($"Пользователь с ролью {role} успешно удален.");
    }
}
class Program
{
    static void Main()
    {
        UserManager userManager = new UserManager();

        try
        {
            userManager.DeleteUser("User");
            userManager.DeleteUser("Admin");
        }
        catch (AdminDeletionException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Операция удаления завершена.");
        }
    }
}

