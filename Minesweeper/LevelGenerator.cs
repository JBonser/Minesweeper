using System;
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
            List<string> boardList = level.Split(new[] { '\r', '\n' }).ToList();
            if (boardList.Count == 0)
                return false;

            int rows = 0;
            int columns = 0;
            if (!ParseInputFields(boardList[0], out rows, out columns))
                return false;

            //Remove the Input Field Row.
            boardList.RemoveAt(0);

            Board board = new Board(rows, columns);
            if (!board.InitialiseBoard(boardList))
                return false;
            board.GenerateBoardValues();

            Level = board.ToString();
            return true;
        }

        bool ParseInputFields(string inputFields, out int rows, out int columns)
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
