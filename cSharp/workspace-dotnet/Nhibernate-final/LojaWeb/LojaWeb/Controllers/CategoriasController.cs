using LojaWeb.DAO;
using LojaWeb.Entidades;
using LojaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaWeb.Controllers
{
    public class CategoriasController : Controller
    {
        private CategoriasDAO dao;
        //
        // GET: /Categorias/

        public ActionResult Index()
        {
            IList<Categoria> categorias = new List<Categoria>();
            return View(categorias);
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Adiciona(Categoria categoria)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
     
            return RedirectToAction("Index");
        }

        public ActionResult Visualiza(int id)
        {
            Categoria categoria = new Categoria();
            return View(categoria);
        }

        public ActionResult Atualiza(Categoria categoria)
        {
            return RedirectToAction("Index");
        }

        public ActionResult CategoriasEProdutos()
        {
            IList<Categoria> categorias = new List<Categoria>();
            return View(categorias);
        }

        public ActionResult BuscaPorNome(string nome)
        {
            IList<Categoria> categorias = dao.BuscaPorNome(nome);
            return View(categorias);
        }

        public ActionResult NumeroDeProdutosPorCategoria()
        {
            IList<ProdutosPorCategoria> lista = dao.ListaNumeroDeProdutosPorCategoria();

            return View(lista);
        }
    }
}
