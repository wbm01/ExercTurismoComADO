using AndreTurismo.Controllers;
using AndreTurismo.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        City city = new()
        {
            Description = "Ibitinga",
            //DtRegisterCity = DateTime.Now,
        };

        if(new CityController().InsertCity(city))
        {
            Console.WriteLine("Cidade inserida com sucesso!");
        }
        else
        {
            Console.WriteLine("Erro! Não foi possível incluir a cidade!");
        }

    }
}