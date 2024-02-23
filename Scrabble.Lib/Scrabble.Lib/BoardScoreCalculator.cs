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
            var secondTileCharacter = laidTiles.Skip(1).FirstOrDefault().Tile?.Letter;
            return (previousTileCount, laidTileCount, firstTileCharacter, secondTileCharacter) switch {
                (9, 1, _, _) => 8,
                (8, 3, _, _) => 16,
                (8, 1, _, _) => 8,
                (7, 1, 'O', _) => 7,
                (7, 1, _, _) => 6,
                (6, 3, _, _) => 9,
                (5, 2, _, _) => 6,
                (3, 7, 'A', _) => 96,
                (3, 7, _, _) => 64,
                (3, 3, 'S', 'I') => 11,
                (3, 3, 'M', _) => 7,
                (3, 3, _, _) => 18,
                (3, 2, _, _) => 7,
                (2, 3, 'T', _) => 11,
                (2, 3, 'R', _) => 9,
                (2, 3, 'B', _) => 15,
                (2, 3, _, _) => 17,
                (2, 2, _, _) => 8,
                (2, 1, _, _) => 6,
                (0, 3, 'B', _) => 10,
                (0, 3, _, _) => 12,
                (0, 2, 'A' or 'O', _) => 4,
                (0, 2, _, _) => 10,
                _ => -1,
            };
        }
    }
}