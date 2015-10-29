using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD.Infrastructure.Services.App
{
    public interface IWebMessageHandler
    {
        string UserExists(string userName, string formatType);
    }
}
