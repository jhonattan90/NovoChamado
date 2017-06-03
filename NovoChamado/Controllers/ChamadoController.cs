using ControleChamado.DTO;
using NovoChamado.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace ControleChamado.Controllers
{
    public class ChamadoController : Controller
    {

        string WSPath = WebConfigurationManager.AppSettings["WSPath"] + "/ControleChamado";


        // GET: Chamado
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult List()
        {
            WebClient wc = new WebClient();

            try
            {
                string listaChamado = wc.DownloadString(WSPath + "/Pesquisar");
                if (!listaChamado.Contains("Vazia"))
                {
                    ChamadoDTO pDTO = JsonConvert.DeserializeObject<ChamadoDTO>(listaChamado);
                    return View(pDTO.lista);
                }
                else
                {
                    return View(new List<ChamadoModel>());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View(new List<ChamadoModel>());
            }
        }

        // GET: Chamado/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    WebClient webClient = new WebClient();
                    var json = webClient.DownloadString(WSPath + "/Recuperar/" + id.ToString());
                    ChamadoDTO pDto = JsonConvert.DeserializeObject<ChamadoDTO>(json);
                    return View(pDto.pChamado);
                }
                else
                {
                    return new HttpNotFoundResult();
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return View(new ChamadoModel());
            }

        }

        // GET: Chamado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chamado/Create
        [HttpPost]
        public ActionResult Create(ChamadoModel paChamado)
        {
            WebClient webClient = new WebClient();
            try
            {
                webClient.Headers.Add("Content-Type", "application/json");

                string json = JsonConvert.SerializeObject(paChamado);
                string jsonRecebido = webClient.UploadString(WSPath + "/Cadastrar", json);
                return RedirectToAction("List");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }

        // GET: Chamado/Edit/5
        public ActionResult Edit(int? id)
        {
            WebClient webClient = new WebClient();
            try
            {
                string retorno = webClient.DownloadString(WSPath + "/Recuperar/" + id.ToString());
                ChamadoDTO pDto = JsonConvert.DeserializeObject<ChamadoDTO>(retorno);
                return View(pDto.pChamado);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View(new ChamadoModel());
            }
        }

        // POST: Chamado/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, ChamadoModel paChamado)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers.Add("Content-Type", "application/json");
                string json = JsonConvert.SerializeObject(paChamado);

                string retorno = webClient.UploadString(WSPath + "/Atualizar", "PUT", json);
                return RedirectToAction("List");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View("List", new List<ChamadoModel>());
            }
        }

        // GET: Chamado/Delete/5
        public ActionResult Delete(int id)
        {
            WebClient webClient = new WebClient();
            try
            {
                webClient.Headers.Add("Content_Type", "application/json");
                var json = webClient.UploadString(WSPath + "/Remover/" + id.ToString(), "DELETE", "");
                return RedirectToAction("List");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View("List", new List<ChamadoModel>());
            }
        }

        // POST: Chamado/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
