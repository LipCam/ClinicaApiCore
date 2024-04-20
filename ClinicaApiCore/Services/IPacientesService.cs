using ClinicaApiCore.DTOs;
using ClinicaApiCore.DTOs.Pacientes;

namespace ClinicaApiCore.Services
{
    public interface IPacientesService
    {
        List<PacientesDTO> GetAll();
        PacientesDTO GetById(long Id);
        PacientesDTO Add(AddEditPacienteRequestDTO addPacienteRequestDTO);
        ResponseDTO Edit(long Id, AddEditPacienteRequestDTO addEditPacienteRequestDTO);
        ResponseDTO Delete(long Id);
    }
}
