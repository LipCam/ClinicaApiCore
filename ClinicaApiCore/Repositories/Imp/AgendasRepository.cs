using ClinicaApiCore.DB;
using ClinicaApiCore.DTOs.Agendas;
using ClinicaApiCore.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ClinicaApiCore.Repositories.Imp
{
    public class AgendasRepository : IAgendasRepository
    {
        private readonly AppDbContext _appDbContext;

        public AgendasRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Agendas GetById(long Id)
        {
            return _appDbContext.Agendas.FirstOrDefault(p => p.ID_AGENDA_LONG == Id);            
        }

        public List<AgendasDTO> GetByLivres(int IdEmpresa, DateTime DataInicio, DateTime DataFim, long IdProcedimento, long IdMedico)
        {
            string SQL = @"SELECT AGD.ID_AGENDA_LONG,
	                            AGD.DATA_AGENDA_INICIO_DTI,
	                            AGD.ID_STATUS_INT,
                                ST.DESCRICAO_STR AS STATUS_STR,
	                            AGD.ID_EXECUTANTE_LONG,
	                            MED.NOME_STR AS MEDICO_STR,
	                            AGD.ID_PROCEDIMENTO_LONG,
	                            PRC.DESCRICAO_STR AS PROCEDIMENTO_STR
                            FROM ATE_AGENDAS_TAB AGD WITH(NOLOCK)
                            INNER JOIN SIS_STATUS_AGENDA_TAB ST WITH(NOLOCK) ON ST.ID_STATUS_INT = AGD.ID_STATUS_INT
                            INNER JOIN CAD_USUARIOS_TAB MED WITH(NOLOCK) ON MED.ID_USUARIO_LONG = AGD.ID_EXECUTANTE_LONG
                            INNER JOIN CAD_PROCEDIMENTOS_TAB PRC WITH(NOLOCK) ON PRC.ID_PROCEDIMENTO_LONG = AGD.ID_PROCEDIMENTO_LONG
                            WHERE AGD.ID_EMPRESA_INT = @ID_EMPRESA_INT AND AGD.ID_STATUS_INT = -1 AND AGD.DATA_AGENDA_INICIO_DTI BETWEEN @DATA_INICIO_DTI AND @DATA_FIM_DTI 
                                AND (@ID_PROCEDIMENTO_LONG = 0 OR AGD.ID_PROCEDIMENTO_LONG = @ID_PROCEDIMENTO_LONG)
                                AND (@ID_MEDICO_LONG = 0 OR AGD.ID_EXECUTANTE_LONG = @ID_MEDICO_LONG)";

            object[] lstParamItems = new object[]
            {
                new SqlParameter { ParameterName = "@ID_EMPRESA_INT", SqlDbType = SqlDbType.Int, Value = IdEmpresa },
                new SqlParameter { ParameterName = "@DATA_INICIO_DTI", SqlDbType = SqlDbType.DateTime, Value = DataInicio },
                new SqlParameter { ParameterName = "@DATA_FIM_DTI", SqlDbType = SqlDbType.DateTime, Value = DataFim },
                new SqlParameter { ParameterName = "@ID_PROCEDIMENTO_LONG", SqlDbType = SqlDbType.Int, Value = IdProcedimento },
                new SqlParameter { ParameterName = "@ID_MEDICO_LONG", SqlDbType = SqlDbType.Int, Value = IdMedico },
            };

            return _appDbContext.AgendasVW.FromSqlRaw(SQL, lstParamItems).Select(p =>
                new AgendasDTO()
                {
                    IdAgenda = p.ID_AGENDA_LONG,
                    Data = p.DATA_AGENDA_INICIO_DTI,
                    IdStatus = p.ID_STATUS_INT,
                    Status = p.STATUS_STR,
                    IdMedico = p.ID_EXECUTANTE_LONG,
                    Medico = p.MEDICO_STR,
                    IdProcedimento = p.ID_PROCEDIMENTO_LONG,
                    Precedimento = p.PROCEDIMENTO_STR
                }).ToList();

            /*return _appDbContext.Agendas.Where(p=> p.DATA_DTI >= DataInicio && p.DATA_DTI <= DataFim && p.ID_PACIENTE_LONG == null && p.ID_STATUS_INT == 0
                                                    && (IdProcedimento == 0 || p.ID_PROCEDIMENTO_LONG == IdProcedimento)
                                                    && (IdMedico == 0 || p.ID_MEDICO_LONG == IdMedico))
                .Select(p =>
                new AgendasDTO()
                {
                    IdAgenda = p.ID_AGENDA_LONG,
                    Data = p.DATA_DTI,
                    IdStatus = p.ID_STATUS_INT,
                    IdMedico = p.ID_MEDICO_LONG,
                    Medico = p.Medicos.NOME_STR,
                    IdProcedimento = p.ID_PROCEDIMENTO_LONG,
                    Precedimento = p.Procedimentos.DESCRICAO_STR
                }).ToList();*/
        }

        public List<AgendasDTO> GetByPaciente(int IdEmpresa, long IdPaciente)
        {
            return _appDbContext.Agendas.Where(p => p.ID_EMPRESA_INT == IdEmpresa && p.ID_PACIENTE_LONG == IdPaciente)
                .Select(p =>
                new AgendasDTO()
                {
                    IdAgenda = p.ID_AGENDA_LONG,
                    Data = p.DATA_AGENDA_INICIO_DTI,
                    IdStatus = p.ID_STATUS_INT,
                    Status = p.StatusAgd.DESCRICAO_STR,
                    IdMedico = p.ID_EXECUTANTE_LONG,
                    Medico = p.Medicos.NOME_STR,
                    IdProcedimento = p.ID_PROCEDIMENTO_LONG,
                    Precedimento = p.Procedimentos.DESCRICAO_STR
                }).ToList();
        }

        public void Update(Agendas entity)
        {
            _appDbContext.Agendas.Update(entity);
            _appDbContext.SaveChanges();
        }
    }
}
