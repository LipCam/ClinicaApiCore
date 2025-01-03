﻿using ClinicaApiCore.DTOs.Agendas;
using ClinicaApiCore.Entities;

namespace ClinicaApiCore.Repositories
{
    public interface IAgendasRepository
    {
        Agendas GetById(long Id);
        List<AgendasDTO> GetByLivres(int IdEmpresa, DateTime DataInicio, DateTime DataFim, long IdProcedimento, long IdMedico);
        List<AgendasDTO> GetByPaciente(int IdEmpresa, long IdPaciente);
        void Update(Agendas entity);
    }
}
