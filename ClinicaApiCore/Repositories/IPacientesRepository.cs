﻿using ClinicaApiCore.DTOs.Pacientes;
using ClinicaApiCore.Entities;

namespace ClinicaApiCore.Repositories
{
    public interface IPacientesRepository
    {
        List<PacientesDTO> GetAll(int IdEmpresa);
        Pacientes GetById(int IdEmpresa, long Id);
        PacientesDTO Add(Pacientes entity);
        void Edit(Pacientes entity);
        void Delete(Pacientes entity);
    }
}
