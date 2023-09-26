using Dapper;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET;
using HermesService.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HermesService.Infra.Data.Repositories.Entity.SICLONET
{
    public class Autenticacao_info_seguradoraRepository : RepositoryConnection, IAutenticacao_info_seguradoraRepository
    {
        public Autenticacao_info_seguradora SelectInfoSeguradora(string funcao)
        {
            string query = @"
                            SELECT
                            	AUT.codigo,
                                AUT.observacao,
                                AUT.usuario,
                                AUT.senha,
                                AUT.ws_endereco 
                            FROM
                            	autenticacao_info_seguradora AUT
                            WHERE
                            	AUT.ativo IS TRUE AND
                                AUT.funcao= " + "'" + funcao + "';";
            try
            {
                var objCredenciais = SqlMapper.Query<Autenticacao_info_seguradora>(Connection, query).SingleOrDefault();

                return objCredenciais;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.GetType().FullName.ToString() + " , classe \"Autenticacao_info_seguradoraRepository\", msg:" + ex.Message);
            }
            throw new NotImplementedException();
        }
        public string DeleteInfoSeguradora()
        {
            throw new NotImplementedException();
        }

        public string InsertInfoSeguradora()
        {
            throw new NotImplementedException();
        }



        public string UpdateInfoSeguradora()
        {
            throw new NotImplementedException();
        }
    }
}
