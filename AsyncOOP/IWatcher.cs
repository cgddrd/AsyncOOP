using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncOOP
{
    interface IWatcher
    {
        Task<int> CountBytesAsync(string url);
    }
}
