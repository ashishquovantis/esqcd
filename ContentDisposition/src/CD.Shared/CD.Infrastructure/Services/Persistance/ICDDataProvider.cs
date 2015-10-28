using CD.Infrastructure.Poco;
using ESQ.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD.Infrastructure.Services.Persistance
{
    public interface ICDDataProvider
    {
        UserProfile AuthenticateUser(string userName, IDbContext dbContext);
    }
}
