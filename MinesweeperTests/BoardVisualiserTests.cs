using NUnit.Framework;
using Minesweeper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Minesweeper.Tests
{
    [TestFixture()]
    public class BoardVisualiserTests
    {

        [Test()]
        public void GetSquareOriginZeroZeroStartTest()
        {
            //Create a 1x1 board and ensure that the origin is at 0,0
            Board testBoard = new Board(1, 1);
            BoardVisualiser visualiser = new BoardVisualiser(testBoard);
            Vector2 origin = new Vector2();
            bool result = visualiser.GetSquareOrigin(0, 0, 200, 200, out origin);

            Assert.True(result);
            Assert.AreEqual(new Vector2(0, 0), origin);
        }

        [Test()]
        public void GetSquareOriginOutOfBoundsTest()
        {
            //Choose a board item that is out of bounds of the board.
            Board testBoard = new Board(1, 1);
            BoardVisualiser visualiser = new BoardVisualiser(testBoard);

            Vector2 origin = new Vector2();
            bool result = visualiser.GetSquareOrigin(3, 3, 200, 200, out origin);

            Assert.False(result);
            Assert.AreEqual(new Vector2(int.MinValue, int.MinValue), origin);
        }

        [Test()]
        public void GetSquareOriginIncrementByWidthTest()
        {
            //Ensure that the board width increments properly
            Board testBoard = new Board(1, 5);
            BoardVisualiser visualiser = new BoardVisualiser(testBoard);

            Vector2 origin = new Vector2();
            bool result = visualiser.GetSquareOrigin(0, 0, 400, 200, out origin);

            Assert.True(result);
            Assert.AreEqual(new Vector2(0, 0), origin);

            result = visualiser.GetSquareOrigin(0, 1, 400, 200, out origin);

            Assert.True(result);
            Assert.AreEqual(new Vector2(0, 400), origin);

            result = visualiser.GetSquareOrigin(0, 2, 400, 200, out origin);

            Assert.True(result);
            Assert.AreEqual(new Vector2(0, 800), origin);
        }

        [Test()]
        public void GetSquareOriginIncrementByHeightTest()
        {
            //Ensure that the board height increments properly
            Board testBoard = new Board(5, 1);
            BoardVisualiser visualiser = new BoardVisualiser(testBoard);

            Vector2 origin = new Vector2();
            bool result = visualiser.GetSquareOrigin(0, 0, 200, 300, out origin);

            Assert.True(result);
            Assert.AreEqual(new Vector2(0, 0), origin);

            result = visualiser.GetSquareOrigin(1, 0, 200, 300, out origin);

            Assert.True(result);
            Assert.AreEqual(new Vector2(300, 0), origin);

            result = visualiser.GetSquareOrigin(2, 0, 200, 300, out origin);

            Assert.True(result);
            Assert.AreEqual(new Vector2(600, 0), origin);
        }

        [Test()]
        public void GetSquareOriginWidthAndHeightTest()
        {
            //Ensure that the board height increments properly
            Board testBoard = new Board(6, 6);
            BoardVisualiser visualiser = new BoardVisualiser(testBoard);

            Vector2 origin = new Vector2();
            bool result = visualiser.GetSquareOrigin(2, 4, 500, 450, out origin);

            Assert.True(result);
            Assert.AreEqual(new Vector2(900, 2000), origin);

            result = visualiser.GetSquareOrigin(1, 1, 500, 450, out origin);

            Assert.True(result);
            Assert.AreEqual(new Vector2(450, 500), origin);

            result = visualiser.GetSquareOrigin(5, 3, 500, 450, out origin);

            Assert.True(result);
            Assert.AreEqual(new Vector2(2250, 1500), origin);
        }
    }
}