namespace ProtocolParser.Factory
{
    public static class FactoryConstants
    {
        public const string EnumRegexStringPattern = @"(?:enum\s+(?:[ a-zA-Z0-9().:*_-]*){0}\s*\{{\s)([^}};]*.*)\}};";
        public const string StructRegexStringPattern = @"(?:struct\s+(?:[ a-zA-Z0-9().:*_-]*){0}\s*\{{\s)(?:(?!\}};)(.*\s))*\}};";
    }
}
