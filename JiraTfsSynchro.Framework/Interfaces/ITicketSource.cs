using System;
using System.Collections.Generic;
using System.Text;

namespace JiraTfsSynchro.Framework.Interfaces
{
    public interface ITicketSource
    {
        string Source { get; }
        DetailedProcessing OnDetailedProcessing { get; set; }
        PercentComplete OnPercentComplete { set; get; }
        bool PreferHtml { get; set; }
        IEnumerable<Ticket> Tickets(IAvailableTicketTypes ticketTarget);
        List<string> GetAvailableTicketTypes();
        void DownloadAttachments(Ticket ticket, string toPath);
    }
}
