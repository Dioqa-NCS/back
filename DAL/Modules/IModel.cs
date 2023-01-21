using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Modules;
public interface IModel<TKey> where TKey : IEquatable<TKey>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public TKey Id { get; set; }
}
