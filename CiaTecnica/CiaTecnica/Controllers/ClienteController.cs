using CiaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CiaTecnica.Controllers
{
    public class ClienteController : Controller
    {
        ClienteDAO OClienteApp = new ClienteDAO();
        TipoPessoaDAO oTipoPessoaApp = new TipoPessoaDAO();
        EstadoDAO oEstadoApp = new EstadoDAO();

        // GET: Cliente
        public ActionResult Index()
        {
            var oClientes = OClienteApp.ListarTodos();

            return View(oClientes);
        }

        // GET: Create
        public ActionResult Create()
        {
            ViewBag.listaTipoPessoa = oTipoPessoaApp.ListarTodos();
            ViewBag.listaEstados = oEstadoApp.ListarTodos();
            Cliente oCliente = new Cliente();
            return View(oCliente);
        }
        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente oCliente)
        {
            ViewBag.listaTipoPessoa = oTipoPessoaApp.ListarTodos();
            ViewBag.listaEstados = oEstadoApp.ListarTodos();

            //oCliente = OClienteApp.salvarDados(oCliente);
            if (ModelState.IsValid)
            {
                OClienteApp.salvarDados(oCliente);
                if (oCliente.oRetorno.Erro == true)
                {
                    return View(oCliente).Mensagem(oCliente.oRetorno.Mensagem);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            return View(oCliente);
        }

        // GET: Edit/
        public ActionResult Edit(int Id)
        {
            var oCliente = OClienteApp.ListarPorId(Id.ToString());
            ViewBag.listaTipoPessoa = oTipoPessoaApp.ListarTodos();
            ViewBag.listaEstados = oEstadoApp.ListarTodos();

            if (oCliente == null)
            {
                return HttpNotFound();
            }

            return View(oCliente);
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente oCliente)
        {
            ViewBag.listaTipoPessoa = oTipoPessoaApp.ListarTodos();
            ViewBag.listaEstados = oEstadoApp.ListarTodos();

            if (ModelState.IsValid)
            {
                OClienteApp.salvarDados(oCliente);
                if (oCliente.oRetorno.Erro == true)
                {
                    return View(oCliente).Mensagem(oCliente.oRetorno.Mensagem);
                }
                else
                {
                    return RedirectToAction("Index");
                }
                
            }

            return View(oCliente);
        }

        // Get: Details
        public ActionResult Details(int Id)
        {
            var oCliente = OClienteApp.ListarPorId(Id.ToString());
            ViewBag.listaTipoPessoa = oTipoPessoaApp.ListarTodos();

            if (oCliente == null)
            {
                return HttpNotFound();
            }

            return View(oCliente);
        }
        public ActionResult Delete(int Id)
        {
            var oCliente = OClienteApp.ListarPorId(Id.ToString());
            ViewBag.listaTipoPessoa = oTipoPessoaApp.ListarTodos();

            if (oCliente == null)
            {
                return HttpNotFound();
            }

            return View(oCliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmado(int Id)
        {
            var oCliente = OClienteApp.ListarPorId(Id.ToString());
            OClienteApp.excluirDados(oCliente);
            return RedirectToAction("Index");
        }

    }
}