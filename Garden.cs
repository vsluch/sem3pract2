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

        public void addPlant(Plant plant)
        {
            Plants.Add(plant);
        }
        
        public void removePlant(Plant plant)
        {
            Plants.Remove(plant);
        }


        public void ShowPlants()
        {
            Console.WriteLine("Сад:");
            foreach(var plant in Plants)
            {
                Console.WriteLine(plant.ToString());
            }
            Console.WriteLine("_____________________________________________________________________________________________________________________");
        }
    }
}
