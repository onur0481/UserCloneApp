using System.Text.RegularExpressions;

namespace UserCloneApp.Domain.Constants
{
    public static partial class RegexConstants
    {
        [GeneratedRegex("^\\S+@\\S+\\.\\S+$")]
        public static partial Regex EmailFormatRegex();

        [GeneratedRegex(@"^[\p{L}\p{Zs}]+$")]
        public static partial Regex OnlyLetterRegex();
    }
}
