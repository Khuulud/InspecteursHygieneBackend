using MediatR;

namespace Application.Inspections.Commands;

public class StartInspectionCommand : IRequest<int>
{
    public int InspecteurId { get; set; }
    public int EtablissementId { get; set; }
    public int PlanningId { get; set; }
}