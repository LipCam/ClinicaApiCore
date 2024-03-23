using ClinicaApiCore.DTOs.Procedimentos;

namespace ClinicaApiCore.Services
{
    public interface IProcedimentosService
    {
        List<ProcedimentosDTO> GetAll(int IdEmpresa);
        ProcedimentosDTO GetById(int IdEmpresa, long Id);
        ProcedimentosDTO Add(int IdEmpresa, AddEditProcedimentoRequestDTO addProcedimentoRequestDTO);
        ProcedimentosResponseDTO Edit(int IdEmpresa, long Id, AddEditProcedimentoRequestDTO addProcedimentoRequestDTO);
        ProcedimentosResponseDTO Delete(int IdEmpresa, long Id);
    }
}
