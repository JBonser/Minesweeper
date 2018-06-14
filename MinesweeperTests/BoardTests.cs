using NUnit.Framework;
using Minesweeper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Tests
{
    [TestFixture()]
    public class BoardTests
    {
        [Test()]
        public void InitialiseBoardWithInvalidCharacterTest()
        { 
            //Only '*' or '.' Characters are valid.
            List<string> boardList = new List<string> { "^" };
            Board board = new Board(1, 1);

            Assert.False(board.InitialiseBoard(boardList));
        }

        [Test()]
        public void InitialiseBoardWithInvalidMoreValuesThanRowColumValues()
        {
            //Create 2,5 values
            List<string> boardList = new List<string> { "..1..", "....*" };

            //Supply 2,4 to Constructor
            Board board = new Board(2, 4);

            Assert.False(board.InitialiseBoard(boardList));
        }
    }
}