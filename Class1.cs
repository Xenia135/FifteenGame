//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Drawing;
//using System.Windows.Forms;

//namespace _1
//{
//    partial class Game
//    {
        
//        int[,] map;
//        int size;
//        static Random rand = new Random();
//        int spase_x;
//        int spase_y;
        
//        public Game(int size)
//        {
//            if (size < 2) size = 2;
//            if (size > 5) size = 5;
//            this.size = size;
//            map = new int[size, size];
//        }

//        public void start()
//        {
//            for (int x = 0; x < size; x++)
//                for (int y = 0; y < size; y++)
//                    map[x, y] = coords_to_position(x, y) + 1;
//            spase_x = size - 1;
//            spase_y = size - 1;
//            map[spase_x, spase_y] = 0;
//        }

//        public bool shift(int position)
//        {
//            int x, y;
//            position_to_coords(position, out x, out y);
//            if (Math.Abs(spase_x - x) + Math.Abs(spase_y - y) != 1)
//                return false;
//            map[spase_x, spase_y] = map[x, y];
//            map[x, y] = 0;
//            spase_x = x;
//            spase_y = y;
//            return true;
//        }
//        public void shift_random()
//        {
//            //shift(rand.Next(0, size * size));
//            int a = rand.Next(0, 4);
//            int x = spase_x;
//            int y = spase_y;
//            switch (a)
//            {
//                case 0: x--; break;
//                case 1: x++; break;
//                case 2: y--; break;
//                case 3: y++; break;
//            }
//            shift(coords_to_position(x, y));
//        }
//        public bool check_numbers()
//        {
//            if (!(spase_x == size - 1 && spase_y == size - 1))
//                return false;
//            for (int x = 0; x < size; x++)
//                for (int y = 0; y < size; y++)
//                    if (!(x == size - 1 && y == size - 1))
//                        if (map[x, y] != coords_to_position(x, y) + 1)
//                            return false;
//            return true;
//        }
//        public int get_number(int position)
//        {
//            int x, y;
//            position_to_coords(position, out x, out y);
//            if (x < 0 || x >= size) return 0;
//            if (y < 0 || y >= size) return 0;
//            return map[x, y];

//        }
//        private int coords_to_position(int x, int y)
//        {
//            if (x < 0) x = 0;
//            if (x > size - 1) x = size - 1;
//            if (y < 0) y = 0;
//            if (y > size - 1) y = size - 1;
//            return y * size + x;
//        }
//        private void position_to_coords(int position, out int x, out int y)
//        {
//            if (position < 0) position = 0;
//            if (position > size * size - 1) position = size * size - 1;
//            x = position % size;
//            y = position / size;
//        }



//    }

//}

