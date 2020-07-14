using System;
using System.Collections.Generic;
using System.Text;

namespace Controle.Shared.Contracts
{
    public interface ICommand 
    {
        void Validate();
    }
}
