using BusinessLayer.Models;
using JobManagement.API.Bussines;
using JobManagement.API.Data.Models;
using JobManagement.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;

namespace JobManagement.API.Controllers
{
    public class GenericController : ApiController
    {
        public User_Service user_service = new User_Service();
        public Job_Service job_service = new Job_Service();
        SecurityService service = new SecurityService();


        [Route("api/authenticate/")]
        [HttpGet]
        public IHttpActionResult IniciarSesion(string user, string pass)
        {
            try
            {

                var result = user_service.GetUsuarioByCredenciales(user, pass);

                if (result != null)
                {
                    string d = WebConfigurationManager.AppSettings["tokenExpirationDuration"];
                    string key = WebConfigurationManager.AppSettings["privateKey"];
                    int duracion = 0;
                    int.TryParse(d, out duracion);

                    var AuthTokenWrapper = service.CreateAuthenticationToken(TimeSpan.FromMinutes(duracion), key);
                    string token = AuthTokenWrapper.GetTokenAsString();

                    return Ok(token);

                }
                else
                {
                    return Content(System.Net.HttpStatusCode.Unauthorized, $"Usuario o Contraseña Incorrecta");
                }

            }
            catch (Exception ex)
            {
                return Content(System.Net.HttpStatusCode.InternalServerError, $"Su peticion no ha podido ser procesada: {ex.Message}.");
            }

        }

        [Route("user/getuser/")]
        [RequiresToken]
        [HttpGet]
        public IHttpActionResult GetUser(int id)
        {
            try
            {
                var result = user_service.GetUserById(id);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return Content(System.Net.HttpStatusCode.InternalServerError, $"Su peticion ha sido ejecutada, pero no contiene informacion.");
                }

            }
            catch (Exception ex)
            {
                return Content(System.Net.HttpStatusCode.InternalServerError, $"Su peticion no ha podido ser procesada: {ex.Message}.");
            }

        }

        [Route("job/getjob/")]
        [RequiresToken]
        [HttpGet]
        public IHttpActionResult GetJob(int id)
        {
            try
            {
                var result = job_service.GetJobById(id);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return Content(System.Net.HttpStatusCode.InternalServerError, $"Su peticion ha sido ejecutada, pero no contiene informacion.");
                }

            }
            catch (Exception ex)
            {
                return Content(System.Net.HttpStatusCode.InternalServerError, $"Su peticion no ha podido ser procesada: {ex.Message}.");
            }

        }

        [Route("user/getusers")]
        [RequiresToken]
        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            try
            {
                var result = user_service.GetAllUser();

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return Content(System.Net.HttpStatusCode.InternalServerError, $"Su peticion ha sido ejecutada, pero no contiene informacion.");
                }

            }
            catch (Exception ex)
            {
                return Content(System.Net.HttpStatusCode.InternalServerError, $"Su peticion no ha podido ser procesada: {ex.Message}.");
            }



        }

        [Route("job/getjobs")]
        [RequiresToken]
        [HttpGet]
        public IHttpActionResult Getjobs()
        {
            try
            {
                var result = job_service.GetAllBobs();

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return Content(System.Net.HttpStatusCode.InternalServerError, $"Su peticion ha sido ejecutada, pero no contiene informacion.");
                }

            }
            catch (Exception ex)
            {
                return Content(System.Net.HttpStatusCode.InternalServerError, $"Su peticion no ha podido ser procesada: {ex.Message}.");
            }



        }

        [Route("user/edit")]
        [RequiresToken]
        [HttpPut]
        public IHttpActionResult UpdateUser([FromBody] Users model)
        {
            try
            {
                var result = user_service.UpdateUser(model);

                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return Content(System.Net.HttpStatusCode.InternalServerError, $"Su peticion ha sido ejecutada, pero no contiene informacion.");
                }

            }
            catch (Exception ex)
            {
                return Content(System.Net.HttpStatusCode.InternalServerError, $"Su peticion no ha podido ser procesada: {ex.Message}.");
            }

        }


        [Route("job/edit")]
        [RequiresToken]
        [HttpPut]
        public IHttpActionResult UpdateJob([FromBody] Jobs model)
        {
            try
            {
                var result = job_service.UpdateJob(model);

                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return Content(System.Net.HttpStatusCode.InternalServerError, $"Su peticion ha sido ejecutada, pero no contiene informacion.");
                }

            }
            catch (Exception ex)
            {
                return Content(System.Net.HttpStatusCode.InternalServerError, $"Su peticion no ha podido ser procesada: {ex.Message}.");
            }

        }

        [Route("user/add")]
        [RequiresToken]
        [HttpPut]
        public IHttpActionResult AddUser([FromBody] Users model)
        {
            try
            {
                var result = user_service.AddUser(model);

                if (result!=null)
                {
                    return Ok(result);
                }
                else
                {
                    return Content(System.Net.HttpStatusCode.InternalServerError, $"Su peticion ha sido ejecutada, pero no contiene informacion.");
                }

            }
            catch (Exception ex)
            {
                return Content(System.Net.HttpStatusCode.InternalServerError, $"Su peticion no ha podido ser procesada: {ex.Message}.");
            }

        }

        [Route("job/add")]
        [RequiresToken]
        [HttpPut]
        public IHttpActionResult AddJob([FromBody] Jobs model)
        {
            try
            {
                var result = job_service.AddJob(model);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return Content(System.Net.HttpStatusCode.InternalServerError, $"Su peticion ha sido ejecutada, pero no contiene informacion.");
                }

            }
            catch (Exception ex)
            {
                return Content(System.Net.HttpStatusCode.InternalServerError, $"Su peticion no ha podido ser procesada: {ex.Message}.");
            }

        }

        [Route("user/delete/")]
        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            try
            {
                var result = user_service.DeleteUserById(id);

                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return Content(System.Net.HttpStatusCode.InternalServerError, $"Su peticion ha sido ejecutada, pero no contiene informacion.");
                }

            }
            catch (Exception ex)
            {
                return Content(System.Net.HttpStatusCode.InternalServerError, $"Su peticion no ha podido ser procesada: {ex.Message}.");
            }



        }

        [Route("job/delete/")]
        [HttpDelete]
        public IHttpActionResult DeleteJob(int id)
        {
            try
            {
                var result = job_service.DeleteJobById(id);

                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return Content(System.Net.HttpStatusCode.InternalServerError, $"Su peticion ha sido ejecutada, pero no contiene informacion.");
                }

            }
            catch (Exception ex)
            {
                return Content(System.Net.HttpStatusCode.InternalServerError, $"Su peticion no ha podido ser procesada: {ex.Message}.");
            }



        }
    }
}
