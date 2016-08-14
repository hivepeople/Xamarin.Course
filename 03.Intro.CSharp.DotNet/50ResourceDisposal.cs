using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Course.Intro.CSharp.DotNet
{
    namespace Resource.Disposal
    {
        class Example
        {
            public int ReadFirstLine(string path)
            {
                Stream file = null;
                TextReader reader = null;
                try
                {
                    file = new FileStream(path, FileMode.Open);
                    reader = new StreamReader(file, Encoding.ASCII);
                    return file.ReadByte(); 
                }
                finally
                {
                    if (reader != null)
                        reader.Dispose();
                    if (file != null)
                        file.Dispose();
                }
            }

            public string ReadTextFile(string path)
            {
                using (var file = new FileStream(path, FileMode.Open))
                using (var reader = new StreamReader(file, Encoding.ASCII))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
