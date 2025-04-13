using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PysmennyiDateFinal.Models.ZodiacSigns
{
    public static class ZodiacRepository
    {
        public static readonly IReadOnlyList<WesternZodiacSign> WesternZodiacSigns =
        [
            new WesternZodiacSign("Aries",     new DateTime(1, 3, 21),  new DateTime(1, 4, 20)),
            new WesternZodiacSign("Taurus",    new DateTime(1, 4, 21),  new DateTime(1, 5, 21)),
            new WesternZodiacSign("Gemini",    new DateTime(1, 5, 22),  new DateTime(1, 6, 21)),
            new WesternZodiacSign("Cancer",    new DateTime(1, 6, 22),  new DateTime(1, 7, 23)),
            new WesternZodiacSign("Leo",       new DateTime(1, 7, 24),  new DateTime(1, 8, 23)),
            new WesternZodiacSign("Virgo",     new DateTime(1, 8, 24),  new DateTime(1, 9, 23)),
            new WesternZodiacSign("Libra",     new DateTime(1, 9, 24),  new DateTime(1, 10, 23)),
            new WesternZodiacSign("Scorpio",   new DateTime(1, 10, 24), new DateTime(1, 11, 22)),
            new WesternZodiacSign("Sagittarius", new DateTime(1, 11, 23), new DateTime(1, 12, 21)),
            new WesternZodiacSign("Capricorn", new DateTime(1, 12, 22), new DateTime(1, 1, 20)),
            new WesternZodiacSign("Aquarius",  new DateTime(1, 1, 21),  new DateTime(1, 2, 19)),
            new WesternZodiacSign("Pisces",    new DateTime(1, 2, 20),  new DateTime(1, 3, 20))
        ];

        public static readonly IReadOnlyList<ChineseZodiacSign> ChineseZodiacSigns = [
            new ChineseZodiacSign("Rat"),
            new ChineseZodiacSign("Ox"),
            new ChineseZodiacSign("Tiger"),
            new ChineseZodiacSign("Rabbit"),
            new ChineseZodiacSign("Dragon"),
            new ChineseZodiacSign("Snake"),
            new ChineseZodiacSign("Horse"),
            new ChineseZodiacSign("Goat"),
            new ChineseZodiacSign("Monkey"),
            new ChineseZodiacSign("Rooster"),
            new ChineseZodiacSign("Dog"),
            new ChineseZodiacSign("Pig")
        ];
    }
}
