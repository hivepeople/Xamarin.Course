using System;
using NSubstitute;
using NUnit.Framework;

namespace Xamarin.Course.Advanced.CSharp
{
    namespace Mocking
    {
        public interface IServiceClient
        {
            string FetchDocument(Guid id);
        }

        public class ServiceClient : IServiceClient
        {
            public string FetchDocument(Guid id)
            {
                // Download from server...
                return null;
            }
        }

        public class DocumentPrinter
        {
            private readonly IServiceClient serviceClient;

            public DocumentPrinter(IServiceClient serviceClient)
            {
                this.serviceClient = serviceClient;
            }

            public void PrintDocument(Guid id)
            {
                // Wohoo! Now we can easily test this class
                // separately from service client
                var document = serviceClient.FetchDocument(id);
                Console.WriteLine(document);
            }
        }

        [TestFixture]
        public class DocumentPrinterTest
        {
            [Test]
            public void CanPrint()
            {
                // Create a mock for interface
                IServiceClient mock = Substitute
                    .For<IServiceClient>();

                // Specify behavior
                mock.FetchDocument(Arg.Any<Guid>())
                    .Returns("hej");

                // Use as dependency
                var printer = new DocumentPrinter(mock);

                // Test printer here...

                // Can verify received calls on mock after
                mock.Received(1)
                    .FetchDocument(Arg.Any<Guid>());
            }
        }
    }
}
