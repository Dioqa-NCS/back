#nullable disable

using DAL.Modules.Transports;

namespace DAL.Modules.Servicesupplementairetransports;

public partial class Servicesupplementairetransport
{
    public int IdTransport { get; set; }
    public int IdSupplement { get; set; }
    public string Nom { get; set; }
    public decimal? Prix { get; set; }

    public virtual Transport IdTransportNavigation { get; set; }
}
