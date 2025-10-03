using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract2
{
    public class Garden : IGarden
    {
        private List<Plant> Plants;

        public Garden()
        {
            Plants = new List<Plant>();
        }

        public List<Plant> getPlants()
        {
            return Plants;
        }


        // добавить растение
        public void addPlant(Plant plant)
        {
            Plants.Add(plant);
        }
        
        // удалить растение
        public void removePlant(Plant plant)
        {
            Plants.Remove(plant);
        }


        // вывод всех растений
        public void ShowPlants()
        {

            if(Plants == null || Plants.Count == 0)
            {
                Console.WriteLine("Сад пуст или не существует.");
                return;
            }

            Console.WriteLine("_____________________________________________________________________________________________________________________");
            Console.WriteLine("Сад:");
            foreach(var plant in Plants)
            {
                Console.WriteLine(plant.ToString());
            }
            Console.WriteLine("_____________________________________________________________________________________________________________________\n");
        }

        // вывод всех растений с нумерацией от 1
        public void ShowPlantsWithNumbers()
        {
            if (Plants == null || Plants.Count == 0)
            {
                Console.WriteLine("Сад пуст или не существует.");
                return;
            }

            for (int i = 0; i < Plants.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                Console.WriteLine(Plants[i].ToString());
            }
        }
    }
}
