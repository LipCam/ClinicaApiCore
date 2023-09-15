using ClinicaApiCore.DTOs.Procedimentos;

namespace ClinicaApiCore.Services
{
    public interface IProcedimentosService
    {
        List<ProcedimentosDTO> GetAll();
        ProcedimentosDTO GetById(long Id);
        ProcedimentosDTO Add(AddEditProcedimentoRequestDTO addProcedimentoRequestDTO);
        RequestProcedimentoResultDTO Edit(long Id, AddEditProcedimentoRequestDTO addProcedimentoRequestDTO);
        RequestProcedimentoResultDTO Delete(long Id);
    }
}
