using FluentValidator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controle.Shared.Core
{
    public class ResponseCommand : Notifiable
    {
        public object Data { get; set; }

        public ResponseCommand() { }

        public void AddValue(object @object)
        {
            Data = @object;
        }
    }
}
