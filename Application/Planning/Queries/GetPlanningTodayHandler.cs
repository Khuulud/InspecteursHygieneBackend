using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;

namespace Application.Planning.Queries;

public class GetPlanningTodayHandler : IRequestHandler<GetPlanningTodayQuery, List<PlanningDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPlanningTodayHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<PlanningDto>> Handle(GetPlanningTodayQuery request, CancellationToken cancellationToken)
    {
        var today = DateTime.Today;

        var plannings = await _unitOfWork.Plannings.GetAllAsync();

        var result = plannings
            .Where(p => p.InspecteurId == request.InspecteurId
                     && p.DatePrevue.Date == today
                     && p.Statut == "planifiee")
            .ToList();

        if (!string.IsNullOrEmpty(request.TypeEtablissement))
            result = result
                .Where(p => p.Etablissement.TypeEtablissement
                    .ToLower().Contains(request.TypeEtablissement.ToLower()))
                .ToList();

        return result.Select(p => new PlanningDto
        {
            Id = p.Id,
            EtablissementId = p.EtablissementId,
            NomEtablissement = p.Etablissement?.Nom ?? "",
            TypeEtablissement = p.Etablissement?.TypeEtablissement ?? "",
            Adresse = p.Etablissement?.Adresse ?? "",
            Ville = p.Etablissement?.Ville ?? "",
            DatePrevue = p.DatePrevue,
            Statut = p.Statut
        }).ToList();
    }
}