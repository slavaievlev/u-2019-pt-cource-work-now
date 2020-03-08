namespace SIevlev.ClinicApp.Interfaces.Services
{
    /// <summary>
    /// Сервис авторизации. Сейчас используется для авторизации адмнистратора.
    /// Интерфейс для регистрации пациентов пока решил не делать, это все же часть Эльдара...
    /// </summary>
    public interface AuthService
    {
        string SignIn(string login, string password);
    }
}