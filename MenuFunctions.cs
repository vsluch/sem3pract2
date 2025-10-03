using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace pract2
{
    public static class MenuFunctions
    {
        public static void printMainMenu()
        {
            Console.WriteLine("ГЛАВНОЕ МЕНЮ");
            Console.WriteLine("1. Добавление растения в сад");
            Console.WriteLine("2. Удаление растения из сада");
            Console.WriteLine("3. Просмотр сада");
            Console.WriteLine("4. Работа с отдельным растением");
            Console.WriteLine("5. Выход");
            Console.Write("Выберите действие (цифру): ");
        }

        public static int choiceMenu(short numberOptions)
        {
            int choice;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice) && choice >= 1 && choice <= numberOptions)
                    break;
                else
                    Console.WriteLine("Неверный ввод. Попробуйте снова");      
            }
            return choice;
        }

        // добавление цветка
        public static void addToGarden(Garden garden)
        {
            Console.WriteLine("\n1. Добавить растение");
            Console.WriteLine("2. Добавить цветок");
            Console.WriteLine("3. Добавить куст");
            Console.Write("Выберите действие (цифру): ");
            int addChoice = MenuFunctions.choiceMenu(3);

            FlowerType flower_type = MenuFunctions.choosingFlowerType();
            Size size = MenuFunctions.sizing();

            switch (addChoice)
            {
                case 1:
                    Plant new_plant = new Plant(flower_type, size);
                    garden.addPlant(new_plant);
                    Console.WriteLine($"Растение {flower_type} добавлено в сад");
                    break;

                case 2:
                    FlowerColor color = MenuFunctions.choosingColor();
                    BloomingSeason blooming_season = MenuFunctions.choosingBloomingSeason();
                    short quantity = MenuFunctions.establishingQuantity();

                    Flower new_flower = new Flower(flower_type, size, quantity, color, blooming_season);
                    garden.addPlant(new_flower);
                    Console.WriteLine($"Цветок {flower_type} добавлен в сад");
                    break;

                case 3:
                    Bush new_bush = new Bush(flower_type, size);
                    garden.addPlant(new_bush);
                    Console.WriteLine($"Куст {flower_type} добавлен в сад");
                    break;

                default:
                    Console.WriteLine("Неизвестная ошибка");
                    break;
            }
        }




        // выбор размеров
        public static Size sizing()
        {
            Console.Write("Введите высоту: ");
            int height;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out height))
                    break;
                else
                    Console.Write("Неверный ввод. Попробуйте снова: ");
            }

            Console.Write("Введите диаметр: ");
            int diametr;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out diametr))
                    break;
                else
                    Console.Write("Неверный ввод. Попробуйте снова: ");
            }

            Size size = new Size(height, diametr);
            return size;
        }

        // выбор типа
        public static FlowerType choosingFlowerType()
        {
            FlowerType flower_type;
            Console.WriteLine("\n1. Роза");
            Console.WriteLine("2. Тюльпан");
            Console.WriteLine("3. Орхидея");
            Console.WriteLine("4. Лилия");
            Console.WriteLine("5. Пион");
            Console.Write("Выберите тип: ");
            int typeChoice = MenuFunctions.choiceMenu(5);

            switch (typeChoice)
            {
                case 1:
                    return FlowerType.Rose;
                case 2:
                    return FlowerType.Tulip;
                case 3:
                    return FlowerType.Orchid;
                case 4:
                    return FlowerType.Lily;
                case 5:
                    return FlowerType.Peony;
                default:
                    Console.WriteLine("Неизвестная ошибка. Установлено значение Rose");
                    return FlowerType.Rose;
            }
        }

        // выбор цвета
        public static FlowerColor choosingColor()
        {
            Color color;
            Console.WriteLine("\n1. Красный");
            Console.WriteLine("2. Розовый");
            Console.WriteLine("3. Желтый");
            Console.WriteLine("4. Белый");
            Console.WriteLine("5. Зеленый");
            Console.Write("Выберите цвет: ");
            int colorChoice = MenuFunctions.choiceMenu(5);

            switch (colorChoice)
            {
                case 1:
                    return FlowerColor.Red;
                case 2:
                    return FlowerColor.Pink;
                case 3:
                    return FlowerColor.Yellow;
                case 4:
                    return FlowerColor.White;
                case 5:
                    return FlowerColor.Green;
                default:
                    Console.WriteLine("Неизвестная ошибка при выборе цвета. Установлено значение Red");
                    return FlowerColor.Red;
            }
        }

        // выбор сезона цветения
        public static BloomingSeason choosingBloomingSeason()
        {
            BloomingSeason season;
            Console.WriteLine("\n1. Весна");
            Console.WriteLine("2. Лето");
            Console.WriteLine("3. Осень");
            Console.Write("Выберите сезон цветения: ");
            int seasonChoice = MenuFunctions.choiceMenu(3);

            switch (seasonChoice)
            {
                case 1:
                    return BloomingSeason.Spring;
                case 2:
                    return BloomingSeason.Summer;
                case 3:
                    return BloomingSeason.Autumn;
                default:
                    Console.WriteLine("Неизвестная ошибка при выборе сезона цветения. Установлено значение Summer");
                    return BloomingSeason.Summer;
            }
        }

        // установление количества лепестков
        public static short establishingQuantity()
        {
            short quantity;
            while (true)
            {
                Console.Write("Введите количество лепестков: ");
                string input = Console.ReadLine();
                if (short.TryParse(input, out quantity))
                    break;
                else
                    Console.WriteLine("Некорректный ввод. Попробуйте снова");
            }
            return quantity;
        }


        // удаление из сада
        public static void deleteFromGarden(Garden garden)
        {
            garden.ShowPlantsWithNumbers();
            if(garden.getPlants() == null || garden.getPlants().Count == 0)
            {
                Console.WriteLine("Удаление невозможно.\n");
                return;
            }
            Console.WriteLine($"{garden.getPlants().Count + 1}. Выйти в главное меню");

            Console.Write("Выберите растение для удаления (номер): ");
            int deletedObject = MenuFunctions.choiceMenu((short)(garden.getPlants().Count + 1));
            if (deletedObject == garden.getPlants().Count + 1)      // для выхода
                return;

            garden.removePlant(garden.getPlants()[deletedObject - 1]);
            Console.WriteLine($"Растение под номером {deletedObject} удалено.\n");
        }
    }
}
