using System;

#if BUILD_FOR_UNIX || BUILD_FOR_WIN
namespace WCharT;

public readonly ref partial struct WCharTString
{
    private readonly ReadOnlySpan<byte> data;

    public unsafe WCharTString(byte* p)
    {
        data = CreateData(p);
    }

    public WCharTString(string str)
    {
        data = CreateData(str);
    }

    public WCharTString(int length)
    {
        data = CreateData(length);
    }

    public string GetString()
    {
        return GetString(data);
    }

    public ref readonly byte GetPinnableReference() => ref data.GetPinnableReference();

    public static implicit operator ReadOnlySpan<byte>(WCharTString obj)
    {
        return obj.data;
    }

    private static unsafe ReadOnlySpan<byte> CreateData(byte* p)
    {
        return (IntPtr)p == IntPtr.Zero
            ? ReadOnlySpan<byte>.Empty
            : new ReadOnlySpan<byte>(p, GetLength(p));
    }
}
#endif
