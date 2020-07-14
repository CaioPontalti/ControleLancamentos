using Controle.Shared.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Shared.Contracts
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task<ResponseCommand> Handle(T command);
    }
}
