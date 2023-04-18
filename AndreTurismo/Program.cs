﻿using AndreTurismo.Controllers;
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
        

        /*var pessoa = new Client()
        {
            NameClient = "José",
            Phone = "11111",
            IdClient = 2,

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

        new ClientController().GetClientList().ForEach(i => Console.WriteLine(i));
    }
}