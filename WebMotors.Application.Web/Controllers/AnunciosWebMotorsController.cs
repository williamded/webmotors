using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Newtonsoft.Json;
using WebMotors.Application.Web.ViewModels;
using WebMotors.Domain.Entities;
using WebMotors.Domain.Enums;
using WebMotors.Infra.Data.Repositories;
using WebMotors.Service;
using WebMotors.Service.RestClient;

namespace WebMotors.Application.Web.Controllers
{
    public class AnunciosWebMotorsController : Controller
    {
        private readonly AnunciosWebMotorsServices db = new AnunciosWebMotorsServices();
        
        // GET: AnunciosWebMotors
        public ActionResult Index()
        {
            var anuncioViewModel = Mapper.Map<IEnumerable<AnunciosWebMotorsViewModel>>(db.GetAll());
            
           


            return View(anuncioViewModel);
        }

        // GET: AnunciosWebMotors/Details/5
        public ActionResult Details(int id)
        {
            var anuncio = Mapper.Map<AnunciosWebMotorsViewModel>(db.GetById(id));
            return View(anuncio);
        }

        // GET: AnunciosWebMotors/Create
        public ActionResult Create()
        {
            var anuncio = new AnunciosWebMotorsViewModel();
            anuncio.Marcas = GetDataDropList(TypeRequestApi.Marca);
            
            return View(anuncio);
        }

        // POST: AnunciosWebMotors/Create
        [HttpPost]
        public ActionResult Create(AnunciosWebMotorsViewModel anuncioVM)
        {
            if (ModelState.IsValid)
            {
                var anuncio = Mapper.Map<AnunciosWebMotors>(anuncioVM);
                try
                {
                    db.Insert(anuncio);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Erro(ex.Message);
                }
            }
            return View(anuncioVM);

        }

        // GET: AnunciosWebMotors/Edit/5
        public ActionResult Edit(int id)
        {
            var anuncio = Mapper.Map<AnunciosWebMotorsViewModel>(db.GetById(id));

            var marcas = GetDataDropList(TypeRequestApi.Marca);
            var marca = marcas.First(x => x.Text == anuncio.Marca);

            var modelos = GetDataDropList(TypeRequestApi.Modelo, marca.Value);
            var modelo = modelos.First(x => x.Text == anuncio.Modelo);

            var versoes = GetDataDropList(TypeRequestApi.Versao, modelo.Value);
            var versao = versoes.First(x => x.Text == anuncio.Versao);

            anuncio.Marcas = new SelectList(marcas, "Value", "Text", marca.Value);
            anuncio.Modelos = new SelectList(modelos, "Value", "Text", modelo.Value);
            anuncio.Versoes = new SelectList(versoes, "Value", "Text", versao.Value);

            return View(anuncio);
        }

        // POST: AnunciosWebMotors/Edit/5
        [HttpPost]
        public ActionResult Edit(AnunciosWebMotorsViewModel anuncioVM)
        {
            if (ModelState.IsValid)
            {
                var anuncio = Mapper.Map<AnunciosWebMotors>(anuncioVM);
                try
                {
                    db.Update(anuncio);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Erro(ex.Message);
                }
               

            }
            return View(anuncioVM);
        }

        // GET: AnunciosWebMotors/Delete/5
        public ActionResult Delete(int id)
        {
            var anuncio = Mapper.Map<AnunciosWebMotorsViewModel>(db.GetById(id));
            return View(anuncio);
        }

        // POST: AnunciosWebMotors/Delete/5
        [HttpPost]
        public ActionResult Delete(AnunciosWebMotorsViewModel anuncioVM)
        {
            try
            {
                db.Delete(db.GetById(anuncioVM.ID));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ViewBag.Erro = ex.Message;
            }

            return View(anuncioVM);
           
        }


        public JsonResult GetDataDropListJson(TypeRequestApi typeRequest, string id = "")
        {
            var result = GetDataDropList(typeRequest, id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        private IEnumerable<SelectListItem> GetDataDropList(TypeRequestApi typeRequest, string id ="")
        {
            var lstItem = new List<SelectListItem>();
            string result = ApiWebMotors.GetData(typeRequest, id);

            dynamic obj = JsonConvert.DeserializeObject(result);
            foreach (var item in obj)
            {
                lstItem.Add(new SelectListItem { Value = item.ID, Text = item.Name });
            }

            return new SelectList(lstItem, "Value", "Text"); ;
        }


        
    }
}
