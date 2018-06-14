using NUnit.Framework;
using System;


namespace Minesweeper.Tests
{
    [TestFixture()]
    public class LevelGeneratorTests
    {
        [Test()]
        public void ImportGameInvalidNumberOfFieldInputs()
        {
            String level =
            @"2\n
              ..";
            LevelGenerator levelGenerator = new LevelGenerator();
            bool result = levelGenerator.ImportLevel(level);
            Assert.False(result);

            string mineMap = levelGenerator.Level;
            Assert.Null(mineMap);
        }

        [Test()]
        public void ImportGameSimple()
        {
            String level = "1 3\n"
                         + ".*.\n";
            LevelGenerator levelGenerator = new LevelGenerator(); ;
            bool result = levelGenerator.ImportLevel(level);

            Assert.True(result);
            string mineMap = levelGenerator.Level;
            string expectedMap = "1*1";
            Assert.AreEqual(expectedMap, mineMap);
        }

        [Test()]
        public void ImportGameKataExample1()
        {
            String level = "4 4\n"
                         + "*...\n"
                         + "....\n"
                         + ".*..\n"
                         + "....\n";
            LevelGenerator levelGenerator = new LevelGenerator(); ;
            bool result = levelGenerator.ImportLevel(level);

            Assert.True(result);
            string mineMap = levelGenerator.Level;
            string expectedMap = "*100"
                               + "2210"
                               + "1*10"
                               + "1110";
            Assert.AreEqual(expectedMap, mineMap);
        }

        [Test()]
        public void ImportGameKataExample2()
        {
            String level = "3 5\n"
                         + "**...\n"
                         + ".....\n"
                         + ".*...\n";
            LevelGenerator levelGenerator = new LevelGenerator(); ;
            bool result = levelGenerator.ImportLevel(level);

            Assert.True(result);
            string mineMap = levelGenerator.Level;
            string expectedMap = "**100"
                               + "33200"
                               + "1*100";

            Assert.AreEqual(expectedMap, mineMap);
        }

        [Test()]
        public void ImportGameKataExample3()
        {
            String level = "0 0\n";
            LevelGenerator levelGenerator = new LevelGenerator(); ;
            bool result = levelGenerator.ImportLevel(level);

            Assert.True(result);
            string mineMap = levelGenerator.Level;
            string expectedMap = "";
            Assert.AreEqual(mineMap, expectedMap);
        }
    }
}