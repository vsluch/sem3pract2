using pract2;
using System;



public class Programm
{
    static void Main(string[] args)
    {
        Garden garden = new Garden();

        MenuFunctions.printMainMenu();
        int choice = MenuFunctions.choiceMenu(4);


        switch (choice)
        {
            case 1:
                MenuFunctions.addToGarden(garden);
                garden.ShowPlants();
                break;

            case 3:
                garden.ShowPlants();
                break;

            default:
                Console.WriteLine("Неизвестная ошибка");
                break;
        }
    }
}
