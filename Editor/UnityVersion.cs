
using System.Text.RegularExpressions;

namespace LeanCLR
{
    public class UnityVersion
    {
        public readonly int major;
        public readonly int minor1;
        public readonly int minor2;
        public readonly bool isTuanjieEngine;

        public override string ToString()
        {
            return $"{major}.{minor1}.{minor2}";
        }

        private static readonly Regex s_unityVersionPat = new Regex(@"(\d+)\.(\d+)\.(\d+)");

        public UnityVersion(string versionStr)
        {
            var matches = s_unityVersionPat.Matches(versionStr);
            Match match = matches[matches.Count - 1];
            major = int.Parse(match.Groups[1].Value);
            minor1 = int.Parse(match.Groups[2].Value);
            minor2 = int.Parse(match.Groups[3].Value);
            isTuanjieEngine = versionStr.Contains("t");
        }
    }
}
