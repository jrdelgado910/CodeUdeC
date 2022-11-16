using System;
using System.Data;
using CodeUdeC.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using NuGet.Packaging.Signing;

namespace CodeUdeC.Controllers
{
    public class ProyectController : Controller
    {
        static string cadena = "Data Source=JOSE;Initial Catalog=DBCodeUdeC;Integrated security=true";

        static List<ProjectEntity> olista = new List<ProjectEntity>();

        public ActionResult Subir()
        {
            return View();
        }

        public ActionResult Index()
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


        [HttpPost]
        public ActionResult SubirArchivo(string Titulo, string Descripcion, IFormFile Archivo, string User)
        {

            string Extension = Path.GetExtension(Archivo.FileName);

            MemoryStream ms = new MemoryStream();
            Archivo.CopyTo(ms);
            byte[] data = ms.ToArray();

            using (SqlConnection oconexion = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("insert into Projects(ProjectTitle,ProjectFile,ProyectDescription,ProjectExt,ProjectUser) values(@Titulo,@Archivo,@Descripcion,@extension,@User)", oconexion);
                cmd.Parameters.AddWithValue("@Titulo", Titulo);
                cmd.Parameters.AddWithValue("@Archivo", data);
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                cmd.Parameters.AddWithValue("@extension", Extension);
                cmd.Parameters.AddWithValue("@User", User);
                cmd.CommandType = CommandType.Text;
                oconexion.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index", "Proyect");
        }

        [HttpPost]
        public FileResult DescargarArchivo(int IdArchivo)
        {

            ProjectEntity oArchivo = olista.Where(a => a.ProjectId == IdArchivo).FirstOrDefault();
            string NombreCompleto = oArchivo.ProjectTitle + oArchivo.ProjectExt;

            return File(oArchivo.ProjectFile,"application/" + oArchivo.ProjectExt.Replace(".",""),NombreCompleto);

        }

        [HttpPost]
        public ActionResult EliminarArchivo(int IdArchivo)
        {

            using (SqlConnection oconexion = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Projects WHERE ProjectId = @ProjectID ", oconexion);
                cmd.Parameters.AddWithValue("@ProjectID", IdArchivo);
                cmd.CommandType = CommandType.Text;
                oconexion.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index", "Proyect");

        }
    }
}
