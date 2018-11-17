using System;
using System.Collections.Generic;
using System.Text;

namespace App.Shared
{
    public interface INav
    {
        void Push(INext instance);
        void Pop();
    }
}
