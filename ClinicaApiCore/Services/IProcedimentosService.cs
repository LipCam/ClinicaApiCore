using ClinicaApiCore.DTOs.Procedimentos;

namespace ClinicaApiCore.Services
{
    public interface IProcedimentosService
    {
        List<ProcedimentosDTO> GetAll();
        ProcedimentosDTO GetById(long Id);
        ProcedimentosDTO Add(AddProcedimentoRequestDTO addProcedimentoRequestDTO);
        RequestProcedimentoResultDTO Edit(EditProcedimentoRequestDTO editProcedimentoRequestDTO);
        RequestProcedimentoResultDTO Delete(long Id);
    }
}
