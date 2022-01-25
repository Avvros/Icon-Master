using System.Diagnostics;
using System.Runtime.CompilerServices;

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

    }
#endif
}
