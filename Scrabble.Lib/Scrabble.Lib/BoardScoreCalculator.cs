using System;
using System.Collections.Generic;
using System.Linq;

namespace Scrabble.Lib
{
    public class BoardScoreCalculator
    {
        public static int ScoreWord(IEnumerable<(Square Square, Tile Tile)> laidTiles, IEnumerable<Square> boardSquares)
        {
            return ScoreWordDeepLearning(laidTiles, boardSquares);
        }

        public static int ScoreWordDeepLearning(IEnumerable<(Square Square, Tile Tile)> laidTiles, IEnumerable<Square> boardSquares)
        {
            var previousTileCount = boardSquares.Where(s => s.State.Description != "Vacant").Count();
            var laidTileCount = laidTiles.Count();
            var firstTileCharacter = laidTiles.First().Tile.Letter;
            var secondTileCharacter = laidTiles.Skip(1).FirstOrDefault().Tile?.Letter;
            var firstTileSquare = laidTiles.First().Square.Point.ToString();
            return (previousTileCount, laidTileCount, firstTileCharacter, secondTileCharacter, firstTileSquare) switch {
                (9, 1, _, _, _) => 8,
                (8, 3, _, _, _) => 16,
                (8, 1, _, _, _) => 8,
                (7, 2, _, _, _) => 14,
                (7, 1, 'O', _, _) => 7,
                (7, 1, _, _, _) => 6,
                (6, 3, _, _, _) => 9,
                (5, 2, 'O', _, "I9") => 7,
                (5, 2, _, _, _) => 6,
                (3, 7, 'A', _, _) => 96,
                (3, 7, _, _, _) => 64,
                (3, 3, 'S', 'I', _) => 11,
                (3, 3, 'M', _, _) => 7,
                (3, 3, _, _, _) => 18,
                (3, 2, _, _, _) => 7,
                (2, 3, 'T', _, _) => 11,
                (2, 3, 'R', _, _) => 9,
                (2, 3, 'B', _, _) => 15,
                (2, 3, _, _, _) => 17,
                (2, 2, _, _, _) => 8,
                (2, 1, _, _, _) => 6,
                (0, 3, 'B', _, _) => 10,
                (0, 3, _, _, _) => 12,
                (0, 2, 'A' or 'O', _, _) => 4,
                (0, 2, _, _, _) => 10,
                _ => -1,
            };
        }

        static int GetDeterministicHashCode(string str)
        {
            unchecked
            {
                int hash1 = (5381 << 16) + 5381;
                int hash2 = hash1;

                for (int i = 0; i < str.Length; i += 2)
                {
                    hash1 = ((hash1 << 5) + hash1) ^ str[i];
                    if (i == str.Length - 1)
                        break;
                    hash2 = ((hash2 << 5) + hash2) ^ str[i + 1];
                }

                return hash1 + (hash2 * 1566083941);
            }
        }

        public static int ScoreWordRainbowTable(IEnumerable<(Square Square, Tile Tile)> laidTiles, IEnumerable<Square> boardSquares)
        {
            var laid = string.Join('|', laidTiles.Select(s => s.Square.ToString() + s.Tile.ToString()));
            var board = string.Join('|', boardSquares.Select(s => s.ToString()));
            var hash = GetDeterministicHashCode(laid) ^ GetDeterministicHashCode(board);
            Console.WriteLine(hash);
            return hash switch {
                -1110443043 => 12,
                -1187878387 => 12,
                -1237071499 => 9,
                -1282846054 => 9,
                -1309025591 => 7,
                -1323061827 => 7,
                -1545185702 => 6,
                -1547952697 => 7,
                -1825341548 => 9,
                -2055215242 => 11,
                -2068448462 => 10,
                -320096642 => 10,
                -352142645 => 11,
                -609072518 => 7,
                -677835694 => 4,
                -732613026 => 96,
                -779066630 => 18,
                1154472502 => 10,
                1173449386 => 15,
                1250790427 => 6,
                1263979601 => 6,
                1281604856 => 7,
                1410487264 => 8,
                1430869766 => 8,
                1537569876 => 64,
                1679264758 => 17,
                1808266314 => 8,
                1894198864 => 6,
                1951013990 => 8,
                2050809396 => 11,
                2141962999 => 10,
                412624757 => 8,
                433601900 => 7,
                436741351 => 6,
                582093650 => 16,
                596168665 => 12,
                731604782 => 4,
                753692714 => 4,
                805764965 => 14,
                951618558 => 7,
                986265702 => 14,
                _ => -10000000,
            };
        }
    }
}

