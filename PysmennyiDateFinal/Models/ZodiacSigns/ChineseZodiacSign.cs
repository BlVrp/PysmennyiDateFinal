namespace PysmennyiDateFinal.Models.ZodiacSigns
{
    public class ChineseZodiacSign(string name)
    {
        public string Name { get; } = name;

        override
        public string ToString()
        {
            return Name;
        }
    }
}
