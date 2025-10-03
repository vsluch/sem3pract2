using pract2;
using System;



public class Programm
{
    static void Main(string[] args)
    {
        Garden garden = new Garden();

        while (true)
        {
            MenuFunctions.printMainMenu();
            int choice = MenuFunctions.choiceMenu(5);


            switch (choice)
            {
                case 1:
                    MenuFunctions.addToGarden(garden);
                    break;
                case 2:
                    MenuFunctions.deleteFromGarden(garden);
                    break;

                case 3:
                    garden.ShowPlants();
                    break;

                case 4:
                    Garden onlyFlowers = WorkingWithObject.onlyFlowers(garden);
                    int selectedIndex;
                    try
                    {
                        selectedIndex = WorkingWithObject.selectObjectIndex(onlyFlowers);
                        WorkingWithObject.printFlowerMenu();
                        WorkingWithObject.workWithFlower(garden, selectedIndex);
                        break;
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                        break;
                    }
                    
                    

                case 5:
                    Console.WriteLine("Завершение работы программы...");
                    return;

                default:
                    Console.WriteLine("Неизвестная ошибка");
                    break;
            }
        }
    }
}
