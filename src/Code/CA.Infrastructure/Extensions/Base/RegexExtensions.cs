using System.Text.RegularExpressions;

namespace CA.Infrastructure.Extensions.Base
{
  public static class RegexExtensions
  {
    public static bool VerifyValue(object value, string pattern) => Regex.IsMatch(value.ToString(), pattern);
    public static bool VerifyStringIsNullOrEmpty(string value) => 
      (Regex.IsMatch(value, @"^\s*$") | string.IsNullOrEmpty(value) | value.Length == 0 | value == "null" | value == "NULL");
  }
}
