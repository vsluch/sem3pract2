using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract2
{
    public struct Size
    {
        private float height;       // высота цветка - в см
        private float diametr;      // диаметр цветка - в см

        public float Height
        {
            get { return height; }
            set
            {
                if (value < 0)
                    height = 20;
                else
                    height = value;
            }
        }

        public float Diametr
        {
            get { return diametr; }
            set
            {
                if (value < 0)
                    diametr = 5;
                else
                    diametr = value;
            }
        }


        public Size(float height, float diametr)
        {
            Height = height;
            Diametr = diametr;
        }

        public override string ToString()
        {
            return $"Высота: {Height:F1} см, Диаметр: {Diametr:F1} см";
        }
    }
}
