namespace PaySlipGenerator.Helpers
{
    public static class Constants
    {
        public static class ValidationRegex
        {
            public const string Name = @"^[A-Za-z0-9_']+\s?";
            public const string NumberWithTwoDecimal = @"\d+(\.\d{1,2})?";
        }
    }
}