using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using AutenticacionBasicaApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;

namespace AutenticacionBasicaApi.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class BasicAuthenticationMiddleware
    {
        
        GestionContext DBGestion = new GestionContext();
        Usuario usuario = new Usuario();
        private readonly RequestDelegate _next;

        public BasicAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {   
            //Autenticacion
            string authHeader = httpContext.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Basic"))
            {
                string ecodeUsernameAndPassword = authHeader.Substring("Basic".Length).Trim();
                Encoding encoding = Encoding.GetEncoding("UTF-8");
                string usernameAndPasswor = encoding.GetString(Convert.FromBase64String(ecodeUsernameAndPassword));
                int Index = usernameAndPasswor.IndexOf(":");
                var username = usernameAndPasswor.Substring(0, Index);
                var password = usernameAndPasswor.Substring(Index + 1);
                //Formato Inicial del ejercicio
                //if (username.Equals("abc") && password.Equals("12345"))
                //{
                //    await _next.Invoke(httpContext);
                //}
                //else
                //{
                //    httpContext.Response.StatusCode = 401;
                //    return;

                //}
                //Linq
                var Datos = (from C in DBGestion.Usuario
                             where C.Correo == username && C.Contraseña == password
                             select C).FirstOrDefault();
                if (Datos != null)
                {
                    await _next.Invoke(httpContext);
                }
                else {
                    httpContext.Response.StatusCode = 401;
                    return;
                }

                
            }
            else {
                 httpContext.Response.StatusCode = 401;
                 return;
             

            }
           
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class BasicAuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseBasicAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BasicAuthenticationMiddleware>();
        }
    }
}
