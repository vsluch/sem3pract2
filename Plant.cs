using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract2
{
    public class Plant
    {
        protected FlowerType type;
        protected Size size;

        public Plant(FlowerType _type, Size _size)
        {
            type = _type;
            size = _size;
        }

        public Plant()
        {
            type = FlowerType.Rose;
            size = new Size(20, 6);
        }

        public override string ToString()
        {
            return $"Растение: {type}, Высота: {size.Height}, Диаметр: {size.Diametr} ";
        }
    }
}
