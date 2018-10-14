using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Util;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        Autenticacao AutenticacaoServico;
        public ClienteController(IHttpContextAccessor context)
        {
            AutenticacaoServico = new Autenticacao(context);
        }
        
        [HttpGet]
        [Route("listaCliente")]
        public IList<ClienteModel> Listagem()
        {
            return new ClienteModel().Listagem();
        }
        
        [HttpGet]
        [Route("cliente/{id}")]
        public ClienteModel RetornaCliente(int id)
        {
            return new ClienteModel().RetornaClientePorId(id);
        }
        
        [HttpPost]
        [Route("registrarcliente")]
        public ReturnAllServices Registrar([FromBody]ClienteModel dados)
        {
            ReturnAllServices retorno = new ReturnAllServices();
            try
            {
                dados.RegistrarCliente();
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro ao Registrar Cliente:" + ex.Message;
            }
            return retorno;
        }
        
        [HttpPut]
        [Route("atualizar/{id}")]
        public ReturnAllServices Atualizar(int id, [FromBody]ClienteModel dados)
        {
            ReturnAllServices retorno = new ReturnAllServices();

            try
            {
                dados.Id = id;
                dados.AtualizarCliente();
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro ao Atualizar Cliente:" + ex.Message;
            }
            return retorno;
        }
                
        [HttpDelete]
        [Route("excluir/{id}")]
        public ReturnAllServices Excluir(int id)
        {
            ReturnAllServices retorno = new ReturnAllServices();

            try
            {
                retorno.Result = true;
                retorno.ErrorMessage = "Cliente excluído com sucesso!";
                AutenticacaoServico.Autenticar();
                new ClienteModel().Excluir(id);
            }
            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = ex.Message;
            }
            return retorno;
        }
    }
}
