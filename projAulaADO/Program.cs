using projAulaADO.Controllers;
using projAulaADO.Models;

namespace projAulaADO
{
    internal class Program
    {
        List<Airplane> airplanes = new();

        static void Main(string[] args)
        {
            Console.WriteLine("Proj MVC - ADO.NET");

            Console.WriteLine("Teste Inclusão de dados");

            Engine engine = new()
            {
                Description = "Teste"
            };

            Airplane airplane = new()
            {
                Description = "Para testes",
                Id = 1,
                Name = "TOP TURBO",
                NumberOfPassagers = 20,
                Engine = engine
            };

            if (new AirplaneController().Insert(airplane))
                Console.WriteLine("Registro foi inserido com Sucesso!");
            else
                Console.WriteLine("Erro ao inserir registro");

            new AirplaneController().FindAll().ForEach(item => Console.WriteLine(item));
        }
    }
}