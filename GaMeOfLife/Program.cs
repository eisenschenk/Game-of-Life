using System;
using System.Collections.Generic;
using System.Linq;

namespace GaMeOfLife
{
    class Program
    {
        static Random random = new Random();
        public static void CreateBoard(int[] GameBoard, int area)
        {
            for (int index = 0; index < area; index++)
            {
                GameBoard[index] = random.Next(2);
            }
        }
        public static void WriteBoard(int[] GameBoard, int width, int area)
        {
            for (int index = 0; index < area; index++)
            {
                Console.Write(GameBoard[index]);
                if (index % width == width - 1)
                {
                    Console.WriteLine();
                }
            }
        }

        public static int notNull(int i, int width)
        {
            i = (i + width) % width;
            return i;
        }
        public static int CalcNeighbours(int[] GameBoard, int row, int cul, int width)
        {
            int Neighbours = 0;
            if (GameBoard[notNull(row + 1, width) * width + notNull(cul, width)] == 1)
                Neighbours++;
            if (GameBoard[notNull(row + 1, width) * width + notNull(cul + 1, width)] == 1)
                Neighbours++;
            if (GameBoard[notNull(row + 1, width) * width + notNull(cul - 1, width)] == 1)
                Neighbours++;
            if (GameBoard[notNull(row, width) * width + notNull(cul + 1, width)] == 1)
                Neighbours++;
            if (GameBoard[notNull(row, width) * width + notNull(cul - 1, width)] == 1)
                Neighbours++;
            if (GameBoard[notNull(row - 1, width) * width + notNull(cul + 1, width)] == 1)
                Neighbours++;
            if (GameBoard[notNull(row - 1, width) * width + notNull(cul - 1, width)] == 1)
                Neighbours++;
            if (GameBoard[notNull(row - 1, width) * width + notNull(cul, width)] == 1)
                Neighbours++;
            return Neighbours;
        }

        //public static int CheckNeighbours(int[] GameBoard, int index, int Neighbours, int width, int area, int row, int cul)
        //{

        //    int newIndex = 0;
        //    int[] IndexListe = new int[8] { -width - 1, -width, -width + 1, -1, 1, width - 1, width, width + 1 };

        //    Neighbours = 0;

        //    for (int i = 0; i < 8; i++)
        //    {
        //        newIndex = index + IndexListe[i];

        //        if (newIndex > (area - 1))
        //        {
        //            newIndex = newIndex - area;
        //        }
        //        if (newIndex < 0)
        //        {
        //            newIndex = newIndex + area;
        //        }
        //        if (GameBoard[newIndex] == 1)
        //            Neighbours++;
        //    }           
        //    return Neighbours;
        //}


        public static int ChangeState(int[] GameBoard, int[] NewGameBoard, int index, int Neighbours, int State)
        {

            if (State > 0)
            {
                if (Neighbours < 2 || Neighbours > 3)
                {
                    NewGameBoard[index] = 0;
                }
                else
                {
                    NewGameBoard[index] = 1;
                }
            }
            else
            {
                if (Neighbours == 3)
                {
                    NewGameBoard[index] = 1;
                }
            }
            return NewGameBoard[index];
        }
        static void Main(string[] args)
        {
            int width = 70;
            int area = width * width;
            int[] GameBoard = new int[area];
            int[] NewGameBoard = new int[area];
            int Neighbours = 0;

            CreateBoard(GameBoard, area);
            WriteBoard(GameBoard, width, area);
            Console.WriteLine();
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine();
                Console.SetCursorPosition(0, 0);
                for (int index = 0; index < area; index++)
                {
                    int row = index / width;
                    int cul = index % width;
                    int State = GameBoard[index];
                   Neighbours = CalcNeighbours(GameBoard, row, cul, width);
                    //Neighbours = CheckNeighbours(GameBoard, index, Neighbours, width, area, row, cul);
                    ChangeState(GameBoard, NewGameBoard, index, Neighbours, State);
                }
                GameBoard = NewGameBoard.ToArray();
                WriteBoard(GameBoard, width, area);
            }
        }
    }
}
