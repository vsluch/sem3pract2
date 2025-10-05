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
        public Bush(FlowerType _type, Size _size)
        {
            size = _size;
            if(_type == FlowerType.Rose || _type == FlowerType.Peony)
            {
                type = _type;
            }
            else
            {
                Console.WriteLine($"{_type} не является кустом. Установлено значение по умолчанию (Rose)");
                type = FlowerType.Rose;
            }
        }


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