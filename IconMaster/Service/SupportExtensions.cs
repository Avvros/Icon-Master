using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace IconMaster.Service
{

#if DEBUG
    public static class SupportExtensions
    {
        public static T Log<T>(this T obj,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            Trace.WriteLine($"At {memberName} ({sourceFilePath}:{sourceLineNumber}): {obj}");
            return obj;
        }

        private static string Dump<T>(this T obj)
        {
            StringBuilder sb = new();
            sb.Append(typeof(T).Name);
            return "";
        }

    }
#endif
}
