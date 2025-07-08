namespace Lab11_LindaAroni.Application.Services.Notifications;

public class NotificationService
{
    public void SendNotification(string user)
    {
        Console.WriteLine($"Intentando enviar notificación a {user} en {DateTime.Now}");

        throw new Exception("Error simulado para probar reintentos de Hangfire");
    }
}