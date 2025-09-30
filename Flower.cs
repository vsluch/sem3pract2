using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract2
{
    public class Flower : Plant
    {
        private short quantity;
        public FlowerColor Color {  get; set; }
        public BloomingSeason Blooming_Season {  get; set; }

        // константное поле
        public const short MAX_QUANTITY = 500;

        public short Quantity
        {
            get { return quantity; }
            set
            {
                if (value >= 0 && value <= MAX_QUANTITY)
                    quantity = value;
                else
                    quantity = 0;
            }
        }

        

        
        public Flower(FlowerType type, Size size, short quantity, FlowerColor color, BloomingSeason bloomingSeason) : base(type, size)
        {
            Quantity = quantity;
            Color = color;
            Blooming_Season = bloomingSeason;
        }

        public Flower() : base()
        {
            Quantity = 15;
            Color = FlowerColor.White;
            Blooming_Season = BloomingSeason.Summer;
        }

        // конструктор копирования
        public Flower(Flower orig) : base(orig.type, orig.size)
        {
            this.Quantity = orig.Quantity;
            this.Color = orig.Color;
            this.Blooming_Season = orig.Blooming_Season;
        }

        public override string ToString()
        {
            return $"Цветок: {type}, Цвет: {Color}, Размер: {size}, " +
                   $"Количество лепестков: {Quantity}, Сезон цветения: {Blooming_Season}";
        }



        public FlowerType getFlowerType()
        {
            return type;
        }
        public FlowerColor getFlowerColor()
        {
            return Color;
        }
        public BloomingSeason getBloomingSeason()
        {
            return Blooming_Season;
        }


        // полить
        public void WaterFlower()
        {
            Console.WriteLine($"Цветок {Color} {type} полит");
        }

        // вдохнуть аромат
        public void SmellFlower()
        {
            if(size.Diametr == 0)       // цветок срезан
            {
                Console.WriteLine("Насладиться ароматом не получится, цветок срезан");
                return;
            }

            Console.Write("*Вдохнул аромат ");
            switch(type)
            {
                case FlowerType.Lily:
                    Console.Write("лилии");
                    break;
                case FlowerType.Peony:
                    Console.Write("пионов");
                    break;
                case FlowerType.Rose:
                    Console.Write("розы");
                    break;
                case FlowerType.Orchid:
                    Console.Write("орхидеи");
                    break;
                case FlowerType.Tulip:
                    Console.Write("тюльпана");
                    break;
                default:
                    Console.Write("цветка");
                    break;
            }
            Console.WriteLine("*");
        }

        // срезать цветок
        public void Cut()
        {
            size.Height = 5;
            size.Diametr = 0;
            quantity = 0;
            Console.WriteLine($"Цветок {Color} {type} срезан");
        }


        // узнать, как ухаживать
        public static void FlowerInfo(FlowerType type)
        {
            if (type == FlowerType.Lily || type == FlowerType.Rose || type == FlowerType.Peony)
            {
                Console.WriteLine("Как ухаживать: поливать 1 раз в неделю");
            }
            else
            {
                Console.WriteLine("Как ухаживать: поливать 2 раза в неделю");
            }
        }



        // перегрузка оператора -
        public static Flower operator -(Flower flower, short quantityToRemove)
        {
            short newQuantity = (short)Math.Max(0, flower.Quantity -  quantityToRemove);
            return new Flower(flower.type, flower.size, newQuantity, flower.Color, flower.Blooming_Season);
        }
    }
}
