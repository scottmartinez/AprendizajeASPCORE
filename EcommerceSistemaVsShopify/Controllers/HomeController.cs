using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EcommerceSistemaVsShopify.Models;
using System.Data.SqlClient;

namespace EcommerceSistemaVsShopify.Controllers
{
    public class HomeController:Controller
    {
        private string InformacionConection="Data Source=184.168.194.58;Initial Catalog=CursoOnline; User Id=administradorcurso; Password=Administrador@; Integrated Security=False";
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index( )
        {
            return View();
        }

        [HttpPost]//Enviar
        public IActionResult Index(Usuarios_asp_core usuario)
        {
            /*ADO commando*/

            SqlConnection conexion=new SqlConnection(InformacionConection);
            conexion.Open();
            String query=$"INSERT INTO administradorcurso.Usuarios_asp_core(id_usuario,UserName,pass)VALUES('{usuario.id_usuario}','{usuario.UserName}','{usuario.pass}')";
            SqlCommand comando= new SqlCommand(query,conexion);
         int filas=   comando.ExecuteNonQuery();

            string selecttodo="SELECT  uac.id_usuario,uac.UserName, uac.pass FROM administradorcurso.Usuarios_asp_core AS uac;";
            comando = new SqlCommand(selecttodo,conexion);
         SqlDataReader datareader=   comando.ExecuteReader();
            List<Usuarios_asp_core>Usuarios= new List<Usuarios_asp_core>();
            while(datareader.Read())
            {
               Usuarios_asp_core u = new Usuarios_asp_core();
                u.id_usuario =Convert.ToDouble(datareader.GetValue(0));
                u.UserName = datareader.GetValue(1).ToString();
                u.pass = datareader.GetValue(2).ToString();
                Usuarios.Add(u);

            }
            conexion.Close();
            return View(Usuarios);
        }
        public IActionResult Privacy( )
        {
            return View();
        }

        [ResponseCache(Duration = 0,Location = ResponseCacheLocation.None,NoStore = true)]
        public IActionResult Error( )
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
