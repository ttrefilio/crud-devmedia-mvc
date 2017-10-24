using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Web.Models;
using Projeto.Entidades;
using Projeto.Repositorio.Persistencia;

namespace Projeto.Web.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente/Cadastro
        public ActionResult Cadastro()
        {
            return View();
        }

        // POST: Cliente/Cadastro
        [HttpPost]
        public ActionResult Cadastro(ClienteModelCadastro model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Cliente c = new Cliente();
                    c.Nome = model.Nome;
                    c.Email = model.Email;
                    c.DataCadastro = DateTime.Now;

                    ClienteRepositorio rep = new ClienteRepositorio();
                    rep.Inserir(c);

                    ViewBag.Mensagem = "Cliente " + c.Nome + " cadastrado com sucesso.";

                    ModelState.Clear();
                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = "Erro ao cadastrar cliente: " + e.Message;
                }
            }
            return View();
        }

        // GET: Cliente/Consulta
        public ActionResult Consulta()
        {
            try
            {
                List<ClienteModelConsulta> lista = new List<ClienteModelConsulta>();
                ClienteRepositorio rep = new ClienteRepositorio();

                foreach(Cliente c in rep.ListarTodos())
                {
                    ClienteModelConsulta model = new ClienteModelConsulta();

                    model.IdCliente = c.IdCliente;
                    model.Nome = c.Nome;
                    model.Email = c.Email;
                    model.DataCadastro = c.DataCadastro;

                    lista.Add(model);
                }
                ViewBag.Dados = lista;
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }
            return View();
        }

        //GET: Cliente/Edicao
        public ActionResult Edicao()
        {
            ClienteModelEdicao model = new ClienteModelEdicao();
            try
            {
                int idCliente = int.Parse(Request.QueryString["id"]);
                ClienteRepositorio rep = new ClienteRepositorio();
                Cliente c = rep.ObterPorId(idCliente);

                model.IdCliente = c.IdCliente;
                model.Nome = c.Nome;
                model.Email = c.Email;
                model.DataCadastro = c.DataCadastro;
                
            }
            catch (Exception e)
            {

                ViewBag.Mensagem = "Erro: "+e.Message;
            }
            return View(model);
        }

        //POST: Cliente/Edicao
        [HttpPost]
        public ActionResult Edicao(ClienteModelEdicao model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Cliente c = new Cliente();
                    c.IdCliente = model.IdCliente;
                    c.Nome = model.Nome;
                    c.Email = model.Email;
                    c.DataCadastro = model.DataCadastro;

                    ClienteRepositorio rep = new ClienteRepositorio();
                    rep.Atualizar(c);

                    ViewBag.Mensagem = "Cliente " + c.Nome + " atualizado com sucesso.";
                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = "Erro: " + e.Message;
                }
            }
            return View();
        }

        //GET: Cliente/Exclusao
        public ActionResult Exclusao()
        {
            ClienteModelExclusao model = new ClienteModelExclusao();
            try
            {
                int idCliente = int.Parse(Request.QueryString["id"]);
                ClienteRepositorio rep = new ClienteRepositorio();
                Cliente c = rep.ObterPorId(idCliente);

                model.IdCliente = c.IdCliente;
                model.Nome = c.Nome;
                model.Email = c.Email;
                model.DataCadastro = c.DataCadastro;
                
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = "Erro: " + e.Message;
            }
            return View(model);
        }

        //POST: Cliente/Exclusao
        [HttpPost]
        public ActionResult Exclusao(ClienteModelExclusao model)
        {
            try
            {
                ClienteRepositorio rep = new ClienteRepositorio();
                Cliente c = rep.ObterPorId(model.IdCliente);

                rep.Excluir(c);

                TempData["Mensagem"] = "Cliente " + c.Nome + " excluido com sucesso.";
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = "Erro: " + e.Message;
            }
            return RedirectToAction("Consulta");
        }
               
    }
}