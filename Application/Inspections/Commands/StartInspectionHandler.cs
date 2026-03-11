using Application.Common.Interfaces;
using Domaine.Entities;
using MediatR;

namespace Application.Inspections.Commands;

public class StartInspectionHandler : IRequestHandler<StartInspectionCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public StartInspectionHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(StartInspectionCommand request, CancellationToken cancellationToken)
    {
        var inspection = new Inspection
        {
            InspecteurId = request.InspecteurId,
            EtablissementId = request.EtablissementId,
            PlanningId = request.PlanningId,
            DateDebut = DateTime.UtcNow,
            Statut = "en_cours"
        };

        var inspectionRepo = _unitOfWork.Repository<Inspection>();

        await inspectionRepo.AddAsync(inspection);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return inspection.Id;
    }
}