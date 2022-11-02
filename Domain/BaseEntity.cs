using System;
using System.ComponentModel.DataAnnotations;

namespace Keiko.Domain;

public abstract class BaseEntity
{
    [Key]
    public Guid Id { get; init; } = Guid.NewGuid();
    
    public bool IsFavorite { get; set; }
}