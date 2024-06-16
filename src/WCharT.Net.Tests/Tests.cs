using System.Runtime.InteropServices;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WCharT.Tests;

[TestClass]
public class Tests
{
    [TestMethod]
    public void TestEncoding()
    {
        var text = "Test";
        var str = new WCharTString(text);

        str.GetString().Should().Be(text);
    }

    [TestMethod]
    public void BufferSizeIsRetained()
    {
        var bufferSize = 3;
        var str = new WCharTString(bufferSize);

        var result = str.GetString();
        result.Should().Be(new string(new[] { char.MinValue, char.MinValue, char.MinValue }));
        result.Length.Should().Be(bufferSize);
    }

    [TestMethod]
    public void TestUnicode()
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            Assert.Inconclusive("Unicode is only supported on windows based operating systems");

#pragma warning disable CA1861
        var data = new byte[6];
        data[0] = 0;
        data[1] = 1;
        data[2] = 0;
        data[3] = 1;
        data[4] = 0;
        data[5] = 0;

        unsafe
        {
            fixed (byte* p = data)
            {
                var str = new WCharTString(p);
                str.GetString().Should().Be(new string(new[] { '\u0100', '\u0100' }));
            }
        }
#pragma warning restore CA1861
    }

    [TestMethod]
    public void TestUtf32()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            Assert.Inconclusive("Utf32 is only supported on unix based operating systems");

#pragma warning disable CA1861
        var data = new byte[12];
        data[0] = 0;
        data[1] = 1;
        data[2] = 0;
        data[3] = 0;
        data[4] = 0;
        data[5] = 1;
        data[6] = 0;
        data[7] = 0;
        data[8] = 0;
        data[9] = 0;
        data[10] = 0;
        data[11] = 0;

        unsafe
        {
            fixed (byte* p = data)
            {
                var str = new WCharTString(p);
                str.GetString().Should().Be(new string(new[] { '\u0100', '\u0100' }));
            }
        }
#pragma warning restore CA1861
    }
}
