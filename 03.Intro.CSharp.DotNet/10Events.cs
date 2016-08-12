using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Course.Intro.CSharp.DotNet
{
    namespace Events
    {
        class ErrorArgs : EventArgs {
            public Exception Error { get; private set; }
            public ErrorArgs(Exception error) {
                this.Error = error;
            }
        }

        class Worker {
            public event EventHandler<ErrorArgs> Error;

            private void RaiseError(Exception error) {
                var handler = Error;
                if (handler != null)
                    handler(this, new ErrorArgs(error));
            }
        }

        class Logger {
            public Logger(Worker publisher) {
                publisher.Error += HandleError;
            }

            private void HandleError(object sender, ErrorArgs args) {
                Console.Write("Error from: " + sender);
                Console.WriteLine(" - " + args.Error);
            }
        }
    }
}
