using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushbulletProxy.Core
{
    public interface ISettings
    {
        List<string> WhitelistedAccessTokens { get; }

        string PushbulletApiUrl { get; }


    }
}
