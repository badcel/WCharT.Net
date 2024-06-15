#if TARGET_WINDOWS
using Platform = WCharT.Platforms.Windows;
#else
using Platform = WCharT.Platforms.Unix;
#endif

namespace WCharT;

public readonly ref struct WCharTString
{
    private readonly ReadOnlySpan<byte> data;

    public unsafe WCharTString(byte* p)
    {
        data = Platform.CreateData(p);
    }

    public WCharTString(string str)
    {
        data = Platform.CreateData(str);
    }

    public WCharTString(int length)
    {
        data = Platform.CreateData(length);
    }

    public string GetString()
    {
        return Platform.GetString(data);
    }

    public ref readonly byte GetPinnableReference() => ref data.GetPinnableReference();

    public static implicit operator ReadOnlySpan<byte>(WCharTString obj)
    {
        return obj.data;
    }
}