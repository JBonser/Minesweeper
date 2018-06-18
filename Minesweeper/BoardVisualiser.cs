using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class BoardVisualiser
    {
        Board board;
        public BoardVisualiser(Board board)
        {
            this.board = board;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        }

        void DrawBaseBoard(SpriteBatch spriteBatch)
        {

        }

        void DrawBombs(SpriteBatch spriteBatch)
        {

        }

        void DrawBombProximityNumbers(SpriteBatch spriteBatch)
        {
        }

        public bool GetSquareOrigin(int rowIndex, int columnIndex, int width, int height, out Vector2 origin)
        {
            origin = new Vector2(int.MinValue, int.MinValue);
            if (!board.IndexInBounds(rowIndex, columnIndex))
                return false;
            int rowOrigin = rowIndex * height;
            int columnOrigin = columnIndex * width;
            origin = new Vector2(rowOrigin, columnOrigin);

            return true;
        }
    }
}
