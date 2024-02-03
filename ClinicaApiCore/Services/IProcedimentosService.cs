using ClinicaApiCore.DTOs.Procedimentos;

namespace ClinicaApiCore.Services
{
    public interface IProcedimentosService
    {
        List<ProcedimentosDTO> GetAll();
        ProcedimentosDTO GetById(long Id);
        ProcedimentosDTO Add(AddEditProcedimentoRequestDTO addProcedimentoRequestDTO);
        ProcedimentosResponseDTO Edit(long Id, AddEditProcedimentoRequestDTO addProcedimentoRequestDTO);
        ProcedimentosResponseDTO Delete(long Id);
    }
}
