﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class LevelGenerator
    {
        public string Level { get; set; }

        public bool ImportLevel(string level)
        {
            int rows = 0;
            int columns = 0;
            List<string> boardList;
            if (!ParseInput(level, out rows, out columns, out boardList))
                return false;

            Board board = new Board(rows, columns);
            if (!board.InitialiseBoard(boardList))
                return false;
            board.GenerateBoardValues();

            Level = board.ToString();
            return true;
        }

        //Take the level data as a string and decompose it into rows, columns and a list of lines for the board.
        bool ParseInput(string level, out int rows, out int columns, out List<string> boardList)
        {
            rows = 0;
            columns = 0;
            boardList = level.Split(new[] { '\r', '\n' }).ToList();
            if (boardList.Count == 0)
                return false;

            if (!ParseFieldNumbers(boardList[0], out rows, out columns))
                return false;

            //Remove the Input Field Row Leaving only the Board Squares.
            boardList.RemoveAt(0);
            return true;
        }

        //Takes the input field line of the level and parses it, whilst ensuring it is valid.
        bool ParseFieldNumbers(string inputFields, out int rows, out int columns)
        {
            rows = 0;
            columns = 0;
            string[] fields = inputFields.Split(new[] { ' ' });
            if (fields.Length != 2)
                return false;

            if (int.TryParse(fields[0], out rows) && int.TryParse(fields[1], out columns))
            {
                return true;
            }
            return false;
        }
    }
}
