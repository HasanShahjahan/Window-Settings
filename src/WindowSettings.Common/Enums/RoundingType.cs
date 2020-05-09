namespace WindowSettings.Common.Enums
{
    public sealed class RoundingType : StringEnum
    {
        public RoundingType(string value) : base(value)
        {
        }
        public const string Integer = "Z";
        public const string Double = "Q";
    }
}
