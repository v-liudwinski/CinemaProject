using Cinema.Domain.Models.Enums;

namespace Cinema.Domain.Models.Entities;

public class Phase
{
    public int Id { get; set; }
    public PhaseEnum PhaseName { get; set; }
}