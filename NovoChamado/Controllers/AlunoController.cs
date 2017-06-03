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
    public class AlunoController : Controller
    {

        string WSPath = WebConfigurationManager.AppSettings["WSPath"] + "/Aluno";
        // GET: Aluno
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            WebClient wc = new WebClient();

            try
            {
                string listaAluno = wc.DownloadString(WSPath + "/Pesquisar");
                if (!listaAluno.Contains("Vazia"))
                {
                    AlunoDTO pDTO = JsonConvert.DeserializeObject<AlunoDTO>(listaAluno);
                    return View(pDTO.lista);
                }
                else
                {
                    return View(new List<AlunoModel>());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View(new List<AlunoModel>());
            }
        }


        // GET: Aluno/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    WebClient webClient = new WebClient();
                    var jsonEnvio = webClient.DownloadString(WSPath + "/Recuperar/" + id.ToString());
                    AlunoDTO pDto = JsonConvert.DeserializeObject<AlunoDTO>(jsonEnvio);
                    return View(pDto.lista);
                }
                else
                {
                    return new HttpNotFoundResult();
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return View(new AlunoModel());
            }

        }

        // GET: Aluno/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aluno/Create
        [HttpPost]
        public ActionResult Create(AlunoModel parametroAluno)
        {
            WebClient webClient = new WebClient();
            try
            {
                webClient.Headers.Add("Content-Type", "application/json");

                string jsonEnvio = JsonConvert.SerializeObject(parametroAluno);
                string jsonRecebido = webClient.UploadString(WSPath + "/Cadastrar", jsonEnvio);
                return RedirectToAction("List");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }

        }

        // GET: Aluno/Edit/5
        public ActionResult Edit(int? id)
        {
            WebClient webClient = new WebClient();
            try
            {
                string retorno = webClient.DownloadString(WSPath + "/Recuperar/" + id.ToString());
                AlunoDTO pDto = JsonConvert.DeserializeObject<AlunoDTO>(retorno);
                return View(pDto.aluno);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View(new AlunoModel());
            }
        }

        // POST: Aluno/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, AlunoModel paAluno)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers.Add("Content-Type", "application/json");
                string jsonEnvio = JsonConvert.SerializeObject(paAluno);

                string retorno = webClient.UploadString(WSPath + "/Atualizar", "PUT", jsonEnvio);
                return RedirectToAction("List");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View("List", new List<AlunoModel>());
            }
        }

        // GET: Aluno/Delete/5
        public ActionResult Delete(int id)
        {
            WebClient webClient = new WebClient();
            try
            {
                webClient.Headers.Add("Content_Type", "application/json");
                var jsonProfessor = webClient.UploadString(WSPath + "/Remover/" + id.ToString(), "DELETE", "");
                return RedirectToAction("List");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View("List", new List<AlunoModel>());
            }
        }

        // POST: Aluno/Delete/5
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
