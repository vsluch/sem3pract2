using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract2
{
    public class Bush : Plant
    {
        public Bush() 
        {
            type = FlowerType.Rose;
            size = new Size(40, 40);
        }
        public Bush(FlowerType _type, Size _size) : base(_type, _size) { }


        public override string ToString()
        {
            return $"Куст: {type}, Высота: {size.Height}, Диаметр: {size.Diametr}";
        }


        public void Cut()
        {
            size.Height = 5;
            size.Diametr = 0;
        }
    }
}
