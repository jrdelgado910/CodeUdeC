using CodeUdeC.Areas.Identity.Data;
using CodeUdeC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace CodeUdeC.Controllers
{
    public class HomeController : Controller
    {
        static string cadena = "Data Source=JOSE;Initial Catalog=DBCodeUdeC;Integrated security=true";

        static List<ProjectEntity> olista = new List<ProjectEntity>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexChat()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Foro()
        {
            olista = new List<ProjectEntity>();

            using (SqlConnection oconexion = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("select * from Projects", oconexion);
                cmd.CommandType = CommandType.Text;
                oconexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {

                        ProjectEntity archivo_encontrado = new ProjectEntity();
                        archivo_encontrado.ProjectId = Convert.ToInt32(dr["ProjectId"]);
                        archivo_encontrado.ProjectTitle = dr["ProjectTitle"].ToString();
                        archivo_encontrado.ProjectDescription = dr["ProyectDescription"].ToString();
                        archivo_encontrado.ProjectFile = dr["ProjectFile"] as byte[];
                        archivo_encontrado.ProjectExt = dr["ProjectExt"].ToString();

                        olista.Add(archivo_encontrado);
                    }
                }

            }
            return View(olista);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}