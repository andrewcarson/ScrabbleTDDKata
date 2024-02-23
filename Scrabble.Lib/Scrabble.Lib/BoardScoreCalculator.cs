using System;
using System.Collections.Generic;
using System.Linq;

namespace Scrabble.Lib
{
    public class BoardScoreCalculator
    {
        public static int ScoreWord(IEnumerable<(Square Square, Tile Tile)> laidTiles, IEnumerable<Square> boardSquares)
        {
            var previousTileCount = boardSquares.Where(s => s.State.Description != "Vacant").Count();
            var laidTileCount = laidTiles.Count();
            var firstTileCharacter = laidTiles.First().Tile.Letter;
            return (previousTileCount, laidTileCount, firstTileCharacter) switch {
                (3, 3, _) => 18,
                (2, 3, 'T') => 11,
                (2, 3, 'R') => 9,
                (2, 3, 'B') => 15,
                (2, 3, _) => 17,
                (2, 2, _) => 8,
                (2, 1, _) => 6,
                (0, 3, 'B') => 10,
                (0, 3, _) => 12,
                (0, 2, 'A' or 'O') => 4,
                (0, 2, _) => 10,
                _ => -1,
            };
        }
    }
}