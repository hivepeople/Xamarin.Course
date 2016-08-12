namespace Xamarin.Course.Advanced.CSharp
{
    namespace OldFashionedStaticHelpers.Definition
    {
        using System.Text;

        public class HexHelper
        {
            // For alternatives see: https://github.com/patridge/PerformanceStubs
            public static string ToHexString(byte[] input)
            {
                const string hexAlphabet = "0123456789ABCDEF";

                StringBuilder result = new StringBuilder(input.Length * 2);
                foreach (byte b in input)
                {
                    result.Append(hexAlphabet[(int)(b >> 4)]);
                    result.Append(hexAlphabet[(int)(b & 0x0F)]);
                }

                return result.ToString();
            }
        }
    }

    namespace OldFashionedStaticHelpers.Use
    {
        using System.IO;
        using OldFashionedStaticHelpers.Definition;

        public class ClientCode
        {
            public static void DumpFileContentsAsHex(string filePath)
            {
                byte[] contents = File.ReadAllBytes(filePath);
                string hex = HexHelper.ToHexString(contents);  // <-- clumsy
            }
        }
    }

    namespace WithExtensionMethods.Definition
    {
        using System.Text;

        public static class HexExtensions
        {
            public static string ToHexString(this byte[] input)
            {
                const string hexAlphabet = "0123456789ABCDEF";

                StringBuilder result = new StringBuilder(input.Length * 2);
                foreach (byte b in input)
                {
                    result.Append(hexAlphabet[(int)(b >> 4)]);
                    result.Append(hexAlphabet[(int)(b & 0x0F)]);
                }

                return result.ToString();
            }
        }
    }

    namespace WithExtensionMethods.Use
    {
        using System.IO;
        using WithExtensionMethods.Definition;

        public class ClientCode
        {
            public static void DumpFileContentsAsHex(string filePath)
            {
                byte[] contents = File.ReadAllBytes(filePath);
                string hex = contents.ToHexString();  // <-- wow, elegant!
            }
        }
    }

    namespace WithExtensionMethods.UsingStatic
    {
        using System.IO;
        using WithExtensionMethods.Definition;
        //using static WithExtensionMethods.Definition.HexExtensions;
    
        public class ClientCode
        {
            public static void DumpFileContentsAsHex(string filePath)
            {
                byte[] contents = File.ReadAllBytes(filePath);
                string hex = contents.ToHexString();
            }
        }
    }
}
