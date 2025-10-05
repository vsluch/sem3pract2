using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract2
{
    public static class WorkingWithObject
    {
        // создание сада только из цветов
        public static Garden onlyFlowers(Garden garden)
        {
            Garden onlyFlowersGarden = new Garden();
            foreach(var plant in garden.getPlants())
            {
                if (plant.GetType() == typeof(Flower))
                    onlyFlowersGarden.addPlant(plant);
            }
            return onlyFlowersGarden;
        }


        // выбор объекта, с которым будет работать
        public static int selectObjectIndex(Garden onlyFlowers)
        {
            if(onlyFlowers.getPlants().Count() == 0)
            {
                throw new Exception("В саду нет цветов");
            }
            onlyFlowers.ShowPlantsWithNumbers();

            Console.Write("Выберите цветок для работы с ним: ");
            int selectedObjectIndex = MenuFunctions.choiceMenu((short)onlyFlowers.getPlants().Count) - 1;
            return selectedObjectIndex;
        }



        public static void printFlowerMenu()
        {
            Console.WriteLine("\nМЕНЮ ЦВЕТКА");
            Console.WriteLine("1. Вывод свойств");
            Console.WriteLine("2. Полить");
            Console.WriteLine("3. Вдохнуть аромат");
            Console.WriteLine("4. Оборвать лепестки");
            Console.WriteLine("5. Срезать");
            Console.WriteLine("6. Узнать, как ухаживать");
            Console.WriteLine("7. Вернуться в главное меню");
        }


        // работа с цветком
        public static void workWithFlower(Garden garden, int flower_index)
        {
            Console.Write("Выберите действие: ");
            int selectedAction = MenuFunctions.choiceMenu(7);

            switch (selectedAction)
            {
                case 1:
                    Console.WriteLine($"Свойства цветка: \n{((Flower)garden.getPlants()[flower_index]).ToString()}");
                    break;

                case 2:
                    ((Flower)garden.getPlants()[flower_index]).WaterFlower();
                    break;

                case 3:
                    ((Flower)garden.getPlants()[flower_index]).SmellFlower();
                    break;

                case 4:
                    if (((Flower)garden.getPlants()[flower_index]).Quantity == 0)
                    {
                        Console.WriteLine("У цветка нет лепестков, срывать нечего");
                        break;
                    }
                    Console.Write("Введите количество срываемых лепестков: ");
                    short removedPetals = (short)MenuFunctions.choiceMenu((short)((Flower)garden.getPlants()[flower_index]).Quantity);
                    garden.getPlants()[flower_index] = ((Flower)garden.getPlants()[flower_index]) - removedPetals;
                    break;

                case 5:
                    ((Flower)garden.getPlants()[flower_index]).Cut();
                    break;

                case 6:
                    Flower.FlowerInfo(((Flower)garden.getPlants()[flower_index]).getFlowerType());
                    break;

                case 7:
                    break;
            }
        }
    }
}
