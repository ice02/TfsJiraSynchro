using System;
using System.Collections.Generic;
using System.Text;

namespace JiraTfsSynchro.Framework.Interfaces
{
    public interface IAvailableTicketTypes
    {
        IEnumerable<string> Types { get; }
        bool Contains(string type);
        string Task { get; }
        string Bug { get; }
        string Decision { get; }
        string Risk { get; }
        string Story { get; }
        string Epic { get; }
        string TestCase { get; }
        string Impediment { get; }
    }
}
