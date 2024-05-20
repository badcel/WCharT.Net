#if BUILD_FOR_UNIX

using System;
using System.Text;

namespace WCharT;

public readonly ref partial struct WCharTString
{
    private static ReadOnlySpan<byte> CreateData(int chars)
    {
        var length = chars * sizeof(uint);
        var data = new byte[length + sizeof(uint)]; //Null terminated
        return new ReadOnlySpan<byte>(data, 0, length);
    }

    private static ReadOnlySpan<byte> CreateData(string str)
    {
        var src = Encoding.UTF32.GetBytes(str);
        var dest = new byte[src.Length + sizeof(uint)];
        Array.Copy(src, dest, src.Length);

        //Remove null terminator from span length as the span does
        //contain this information itself. It is only there for
        //null terminated interop scenarios.
        return new ReadOnlySpan<byte>(dest, 0, src.Length);
    }

    private static string GetString(ReadOnlySpan<byte> data)
    {
        return Encoding.UTF32.GetString(data);
    }

    private static unsafe int GetLength(byte* ptr)
    {
        //check code to throw exception in case of arithmethic overflow
        checked
        {
            var current = (uint*)ptr;
            while (*current != 0)
            {
                current += 1; //Jump to next UTF32 char
            }

            return (int)((byte*)current - ptr);
        }
    }
}
#endif