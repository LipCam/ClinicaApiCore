using ClinicaApiCore.DTOs;
using ClinicaApiCore.DTOs.Procedimentos;

namespace ClinicaApiCore.Services
{
    public interface IProcedimentosService
    {
        List<ProcedimentosDTO> GetAll();
        ProcedimentosDTO GetById(long Id);
        ProcedimentosDTO Add(AddEditProcedimentoRequestDTO addProcedimentoRequestDTO);
        ResponseDTO Edit(long Id, AddEditProcedimentoRequestDTO addProcedimentoRequestDTO);
        ResponseDTO Delete(long Id);
    }
}
