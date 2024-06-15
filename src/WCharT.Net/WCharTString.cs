using System.ComponentModel;

#if TARGET_WINDOWS
using Platform = WCharT.Platforms.Windows;
#else
using Platform = WCharT.Platforms.Unix;
#endif

namespace WCharT;

/// <summary>
/// A readonly data structure to send or receive wchar_t data to / from native code.
/// </summary>
public readonly ref struct WCharTString
{
    private readonly ReadOnlySpan<byte> data;

    /// <summary>
    /// Creates an instance from a given pointer to be able to read the data later.
    /// </summary>
    /// <param name="p">Pointer to a null terminated wchar_t string.</param>
    public unsafe WCharTString(byte* p)
    {
        data = Platform.CreateData(p);
    }

    /// <summary>
    /// Creates an instance from a given string to be able to pass on the data later.
    /// </summary>
    /// <param name="str">A string which should be encoded into a wchar_t string.</param>
    public WCharTString(string str)
    {
        data = Platform.CreateData(str);
    }

    /// <summary>
    /// Creates an instance for a given amount of wchar_t characters.
    /// </summary>
    /// <param name="length">The number of wchar_t characters which should be able to put into the instance.</param>
    public WCharTString(int length)
    {
        data = Platform.CreateData(length);
    }

    /// <summary>
    /// Reads the current data and returns the contained string.
    /// </summary>
    /// <returns>The decoded wchar_t string from the data.</returns>
    public string GetString()
    {
        return Platform.GetString(data);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ref readonly byte GetPinnableReference() => ref data.GetPinnableReference();

    public static implicit operator ReadOnlySpan<byte>(WCharTString obj)
    {
        return obj.data;
    }
}