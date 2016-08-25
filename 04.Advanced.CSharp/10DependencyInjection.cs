using System;
using Autofac;
using NUnit.Framework;

namespace Xamarin.Course.Advanced.CSharp
{
    namespace Dependency.Injection.OldWay
    {
        public class ServiceClient
        {
            public string FetchDocument(Guid id)
            {
                // Download from server...
                return null;
            }
        }

        public class DocumentPrinter
        {
            public void PrintDocument(Guid id)
            {
                // Booh! Cannot easily test without full impl
                // of service client
                var serviceClient = new ServiceClient();
                var document = serviceClient.FetchDocument(id);
                Console.WriteLine(document);
            }
        }
    }

    namespace Dependency.Injection.NewWay
    {
        public interface IServiceClient {
            string FetchDocument(Guid id);
        }

        public class ServiceClient : IServiceClient {
            public string FetchDocument(Guid id)
            {
                // Download from server...
                return null;
            }
        }

        public class DocumentPrinter {
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

        class Example
        {
            [TestFixture]
            public class DocumentPrinterTest {
                [Test]
                public void CanPrint() {
                    // Construct a fake service client
                    IServiceClient client = null;

                    // Use it to construct the printer
                    var printer = new DocumentPrinter(client);

                    // Now we can test printer with respect to
                    // _expected_ behavior of service client
                    // instead of _actual_ (which could be buggy)
                }
            }

            public void Boot() {
                var builder = new ContainerBuilder();

                // Would normally create an Autofac module instead
                builder.RegisterType<ServiceClient>()
                    .As<IServiceClient>()
                    .SingleInstance();
                builder.RegisterType<DocumentPrinter>()
                    .AsSelf();

                var container = builder.Build();
                var printer = container.Resolve<DocumentPrinter>();
            }
        }

    }
}
