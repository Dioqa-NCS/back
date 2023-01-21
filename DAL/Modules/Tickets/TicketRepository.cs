using DAL.Modules;

namespace DAL.Modules.Tickets;
public class TicketRepository : Repository<Ticket, int>, ITicketRepository
{
    public TicketRepository(NCSContext Context) : base(Context)
    {
    }
}
