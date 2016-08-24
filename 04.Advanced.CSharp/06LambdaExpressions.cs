namespace Xamarin.Course.Advanced.CSharp
{
    namespace Lambdas.Use
    {
        using System;
        using System.Collections.Generic;

        public class UriStore
        {
            private readonly List<Uri> uris;

            public UriStore(params Uri[] urisToStore) { this.uris = new List<Uri>(urisToStore); }

            public IEnumerable<Uri> FindByHost(string hostName)
            {
                return uris.FindAll(u => u.Host.Equals(hostName));
            }
        }
    }

    namespace Lambdas.UseWithoutArguments
    {
        using System;
        using FluentAssertions;
        using Lambdas.Use;
        using NUnit.Framework;

        [TestFixture]
        public class UriStoreTest
        {
            [Test]
            public static void FindByHost_ThrowsIfHostNameIsNull()
            {
                var store = new UriStore(new Uri("http://www.google.com/"), new Uri("http://www.microsoft.com/"));
                Action callingFindByHost = () => store.FindByHost(hostName: null);

                callingFindByHost.ShouldThrow<NullReferenceException>();
            }
        }
    }

    namespace Lambdas.UseAsEventHandler
    {
        using System;
        using System.Windows.Controls;
        // also need to add PresentationFramework (+ a bunch of other stuff) under References

        public class WpfButtonSnooper
        {
            public void RegisterFor(Button button)
            {
                button.Click += (s, e) => Console.WriteLine("Button {0} clicked", ((Button)s).Name);
            }
        }
    }
}
