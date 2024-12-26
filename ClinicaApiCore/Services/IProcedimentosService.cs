using ClinicaApiCore.DTOs;
using ClinicaApiCore.DTOs.Procedimentos;

namespace ClinicaApiCore.Services
{
    public interface IProcedimentosService
    {
        Result<List<ProcedimentosDTO>> GetAll(int IdEmpresa);
        Result<ProcedimentosDTO> GetById(int IdEmpresa, long Id);
        Result<ProcedimentosDTO> Add(int IdEmpresa, AddEditProcedimentoRequestDTO addProcedimentoRequestDTO);
        Result<string> Edit(int IdEmpresa, long Id, AddEditProcedimentoRequestDTO addProcedimentoRequestDTO);
        Result<string> Delete(int IdEmpresa, long Id);
    }
}
