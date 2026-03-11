using Application.Common.Models;
using MediatR;

namespace Application.Planning.Queries;

public class GetPlanningTodayQuery : IRequest<List<PlanningDto>>
{
    public int InspecteurId { get; set; }
    public string? TypeEtablissement { get; set; } // filtre optionnel
}