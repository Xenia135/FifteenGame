using System;
using System.Collections.Generic;

namespace  _1/*Laba_3*/
{
    internal partial class Game
    {
        /// <summary>
        /// Создаем класс Game в котором опишется логика
        /// инициализируем двумерный массив field в котором будут хранится кнопки
        /// описываем переменные space_x, space_y в которых будем хранить координаты пустой ячейки
        /// counter - счетчик кол-ва ходов
        /// rand - инициализация случайного порядка цифр
        /// </summary>
        public int space_x { get; set; }
        public int space_y { get; set; }
        public int counter { get; set; }

        public int[,] field;
        public int size { get; set; }
        public CaraTaker caraTaker=new CaraTaker();
        public Random rand = new Random();

        /// <summary>
        /// инициализация поля
        /// </summary>
        /// <param name="sIze"></param>
        public Game(int sIze)
        {
            size=sIze;
            field = new int[sIze, sIze];
        }

        /// <summary>
        /// проверяет на возможность собрать данную пятнашку
        /// </summary>
        /// <returns></returns>
        public bool Check()
        {
            if (!(space_x == size - 1 && space_y == size - 1))
                return false;
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    if (!(x == size - 1 && y == size - 1))
                        if (!(field[x, y] == CoordinatesToPosition(x, y) + 1))
                            return false;
                }
            }
            return true;
        }

        /// <summary>
        /// перемещение кнопок с цифрами
        /// </summary>
        /// <param name="position"></param>
        public bool Shift(int position)
        {
            int x, y;
            PositionToCoordinates(position, out x, out y);
            if (Math.Abs(x - space_x) + Math.Abs(y - space_y) == 1)
            {
                counter++;
                Memento m = new Memento(field,space_x,space_y);
                caraTaker.Push(m);
                field[space_x, space_y] = field[x, y];
                field[x, y] = 0;
                space_x = x;
                space_y = y;
                return true;
            }
            return false;
        }

        /// <summary>
        /// функция перемешивания
        /// </summary>
        public void ShiftRandom()
        {
            int a = rand.Next(0, 4);
            int x = space_x;
            int y = space_y;
            switch (a)
            {
                case 0: x--; break;
                case 1: x++; break;
                case 2: y--; break;
                case 3: y++; break;
            }
            Shift(CoordinatesToPosition(x, y));
        }

        /// <summary>
        /// метод CoordinatesToPosition преобразует координаты элемента в его номер
        /// </summary>
        /// <param name="x">координата столбца</param>
        /// <param name="y">координата строчки</param>
        /// <returns></returns>
        public int CoordinatesToPosition(int x, int y)//x столбец y строка
        {
            if (x < 0) x = 0;
            if (x > size - 1) x = (size - 1);
            if (y < 0) y = 0;
            if (y > size - 1) y = (size - 1);
            return y * size + x;
        }

        /// <summary>
        /// метод PositionToCoordinates преобразует номер элемента в его координату
        /// </summary>
        /// <param name="position">позиция на поле</param>
        /// <param name="x">координата столбца</param>
        /// <param name="y">координата строки</param>
        public void PositionToCoordinates(int position, out int x, out int y)
        {
            if (position < 0) position = 0;
            if (position > size * size - 1) position = size * size - 1;
            x = position % size;
            y = position / size;
        }


        /// <summary>
        /// Заполняем игровое поле цифрами от 1 до 15
        /// Для последней ячейки указываем значение 0 
        /// </summary>
        public void Start()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    field[x, y] = CoordinatesToPosition(x, y) + 1; // присваиваем кнопке по координатам число равное ее позиции

            space_x = (size-1);
            space_y = (size-1);
            field[space_x, space_y] = 0; // для последней клетки ставим число 0
        }

        /// <summary>
        /// функция возвращает по позиции нажатой кнопки значение, хранящееся в соответствующей ячейке поля
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public int GetNumber(int position)
        {
            int x, y;
            PositionToCoordinates(position, out x, out y);
            return field[x, y];
        }
        CaraTaker save = new CaraTaker();
    }

    internal class Memento
    {
        /// <summary>
        /// класс Memento в котором сохраняем предыдущий ход
        /// </summary>
        public int[,] State { get;}
        public int space_x;
        public int space_y;

        public Memento(int[,] field, int space_x, int space_y)
        {
            State = (int[,])field.Clone();
            this.space_x = space_x;
            this.space_y = space_y;
        }

    }

    internal class CaraTaker
    {
        /// <summary>
        /// класс в котором хранятся все предыдущие ходы и методы работы с ними 
        /// </summary>
        public List<Memento> mementoes=new List<Memento>();

        /// <summary>
        /// добавление хода в хранилище
        /// </summary>
        /// <param name="memento"></param>
        public void Push(Memento memento)
        {
            mementoes.Add(memento);
        }

        /// <summary>
        /// удаление хода из хранилища с его возвратом
        /// </summary>
        /// <returns></returns>
        public Memento Pop()
        {
            Memento m = mementoes[mementoes.Count-1];
            mementoes.RemoveAt(mementoes.Count-1);
            return m;
        }
    }
}
