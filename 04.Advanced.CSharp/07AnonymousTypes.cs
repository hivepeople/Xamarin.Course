using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Course.Advanced.CSharp
{
    namespace Anonymous.Types
    {
        class Example
        {
            public void Use()
            {
                var obj = new { Name = "Hans", Eyes = 2 };

                // Can access just like ordinary props
                bool b = (obj.Name == "Hans");  // true
                int eyes = obj.Eyes;  // 2

                // ... but props have no setter
                //obj.Name = "Bo";  error: read-only prop
                //obj.Eyes += 1;  error: read-only prop

                // We can even create collections of anonymous types
                // by using implicitly typed arrays
                var anonArray = new[]
                {
                    // Must have matching props and proptypes
                    new { Id = Guid.NewGuid(), Day = DayOfWeek.Monday },
                    new { Id = Guid.NewGuid(), Day = DayOfWeek.Friday }
                };

                DayOfWeek first = anonArray[0].Day;
            }
        }
    }
}
