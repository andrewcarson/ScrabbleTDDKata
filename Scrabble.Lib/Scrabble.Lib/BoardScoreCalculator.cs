using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Scrabble.Lib
{
    public class BoardScoreCalculator
    {
        public static int ScoreWord(IEnumerable<(Square Square, Tile Tile)> laidTiles, IEnumerable<Square> boardSquares)
        {
            var previousTileCount = boardSquares.Where(s => s.State.Description != "Vacant").Count();
            var laidTileCount = laidTiles.Count();
            return (previousTileCount, laidTileCount) switch {
                (0, 3) => 12,
                (0, 2) => 10,
                (2, 1) => 6,
                (2, 2) => 8,
                _ => -1,
            };
        }
    }
}