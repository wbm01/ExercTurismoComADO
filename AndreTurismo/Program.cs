using System.Net;
using AndreTurismo.Controllers;
using AndreTurismo.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        //INSERT CLIENT OK
        /*var pessoa = new Client()
        {
            NameClient = "José",
            Phone = "222222",

            AddressClient = new()
            {
                Street = "AV. 8 de Setembro",
                Number = 392,
                Neighborhood = "Centro",
                Cep = "14920-000",
                Complement = "Casa",
                
                City = new()
                {
                    Description = "São Paulo",
                }
            }
            

        };
        
        if (new ClientController().InsertClient(pessoa))
        {
            Console.WriteLine("Sucesso! Registro inserido!");
            
        }
        else
        {
            Console.WriteLine("Erro ao inserir o registro!");
            
        }*/


        //INSERT HOTEL OK
        /*var hotel = new Hotel()
        {
            NameHotel = "Hotel Classe B",
            ValueHotel = 120,

            AddressHotel = new Address()
            {
                Street = "Rua Nove de Junho",
                Number = 100,
                Neighborhood = "São José",
                Cep = "14940-000",
                Complement = "Hotel",

                City = new City()
                {
                    Description = "Itápolis",
                }
            }
        };

        if (new HotelController().InsertHotel(hotel))
        {
            Console.WriteLine("Sucesso! Registro inserido!");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Erro ao inserir o registro!");
            Console.ReadKey();
        }*/

        //UPDATE CLIENTE OK
        /*var pessoa = new Client()
        {
            NameClient = "Maria",
            Phone = "3333",
            IdClient = 4,

            AddressClient = new()
            {
                Street = "AV. 8 de Setembro",
                Number = 391,
                Neighborhood = "Selmi Dei",
                Cep = "14900-000",
                Complement = "Casa",

                City = new()
                {
                    Description = "Ribeirão",
                }
            }


        };

        if (new ClientController().UpdateClient(pessoa))
        {
            Console.WriteLine("Sucesso! Registro alterado!");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Erro ao alterar o registro!");
            Console.ReadKey();
        }*/

        //DELETE OK
        /*var pessoa = new Client()
        {
            NameClient = "Willian",
        };

        if (new ClientController().DeleteClient(pessoa))
        {
            Console.WriteLine("Sucesso! Registro deletado!");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Erro ao deletar o registro!");
            Console.ReadKey();
        }*/

        //SELECT OK
        //new ClientController().GetClientList().ForEach(i => Console.WriteLine(i));

        //SELECT ADDRESS OK
        //new AddressController().GetAddressList().ForEach(i => Console.WriteLine(i));


        //UPDATE ADDRESS OK
        /*var address = new Address()
        {
            Street = "AV. 10 de Setembro",
            Number = 400,
            Neighborhood = "Selmi Dei II",
            Cep = "14700-000",
            Complement = "sobrado",
            IdAddress = 1,

            City = new()
            {
                Description = "Ribeirão Pires",
            }
        };

        if (new AddressController().UpdateAddress(address))
        {
            Console.WriteLine("Sucesso! Registro alterado!");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Erro ao alterar o registro!");
            Console.ReadKey();
        }*/


        //SELECT CITY OK
        //new CityController().GetCityList().ForEach(i => Console.WriteLine(i));


        //UPDATE CITY OK
        /*var city = new City()
        {
            Description = "Osasco",
            IdCity = 1
        };

        if (new CityController().UpdateCity(city))
        {
            Console.WriteLine("Sucesso! Registro alterado!");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Erro ao alterar o registro!");
            Console.ReadKey();
        }*/


        //UPDATE HOTEL OK
        /*var hotel = new Hotel()
        {
            NameHotel = "Hotel Classe C",
            ValueHotel = 150,
            IdHotel = 1,
        };

        if (new HotelController().UpdateHotel(hotel))
        {
            Console.WriteLine("Sucesso! Registro alterado!");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Erro ao alterar o registro!");
            Console.ReadKey();
        }*/


        //SELECT HOTEL OK
        //new HotelController().GetHotelList().ForEach(i => Console.WriteLine(i));
    }
}