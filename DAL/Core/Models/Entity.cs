using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Core.Models;

public abstract class Entity<K> where K : IEquatable<K>
{
    [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
    public K Id { get; set; }

}
