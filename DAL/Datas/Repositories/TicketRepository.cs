namespace DAL.Datas.Repositories;
public class TicketRepository : Repository<Ticket, int>, ITicketRepository
{
    public TicketRepository( NCSContext Context ) : base( Context )
    {
    }
}
