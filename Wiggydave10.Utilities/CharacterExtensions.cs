namespace Wiggydave10.Utilities
{
    public static class CharacterExtensions
    {
        public static bool IsLetter(this char c)
        {
            return char.IsLetter(c);
        }

        public static bool IsDigit(this char c)
        {
            return char.IsDigit(c);
        }
    }
}