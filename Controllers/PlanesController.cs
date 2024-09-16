using ProyectoAerofeliz.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoAerofeliz.Controllers

    //Paso:2) Se crea el controlador de Planes.cs y llamamos al controlador PlanesController, y se van a editar los metodos
{
    public class PlanesController : Controller
    {


        // GET: Planes
        public ActionResult Index() // A) Propósito: Muestra una lista de todos los planes.
        {
            using (DbModels context = new DbModels()) // Se crea una instancia de DbModels llamada context
            {
                return View(context.Planes.ToList()); 
            }
            /*Detalle: Usa un contexto de base de datos (DbModels)
            para obtener todos los registros de la tabla Planes y
            enviarlos a la vista.*/


        }

        // GET: Planes/Details/5

        public ActionResult Details(int id) // B) Se muestra detalladamente cada solicitud echa por el cliente
        {
            using (DbModels context = new DbModels()) // Se crea una instancia de DbModels llamada context
            {
                var plan = context.Planes.SingleOrDefault(x => x.Id == id); // Obtiene un único objeto Plan o null
                return View(plan); // Pasa el único objeto Plan a la vista
            }

            /*Solicita que nos retorne una vista en el contexto de planes donde x representa una coleccion en la tabla planes
            x.Id accede a la propiedad Id del objeto Plan,
            Id es el parametro del motodo Details que contiene el valor del identificador del plan que se busca*/

        }



        // GET: Planes/Create, El metodo Get envia una solicitud para obtener datos
        public ActionResult Create() // C) En este caso no lo editaremos ya que no vamos a traer datos, solo a enviarlos en el post
        {
             return View();
        }


        // POST: Planes/Create, el metodo post envia los datos y modifica los recursos
        [HttpPost] // atributo que indica que el metodo create maneja solicitudes http
        public ActionResult Create(Planes planes) //La coleccion va a ser Planes y su identificador planes.
        {
            try
            {
                using (DbModels context = new DbModels()) //Se crea la Instancia
                {
                    context.Planes.Add(planes); // en el contexto de la base de datos nos va a traer los planes y usaremos el metodo
                                                // add para agregar lo que venga del metodo Create - planes.
                    context.SaveChanges(); // en el contexto de la base de datos usamos el metodo savechanges para guardar cambios
                }
                return RedirectToAction("Index"); //Después de guardar los cambios, redirige al usuario a la acción Index
                                                  //del mismo controlador. Esta redirección es común después de la creación
                                                  //de un nuevo registro para mostrar la lista actualizada de registros o una
                                                  //vista de confirmación.
            }
            catch
            {
                return View(); // En caso de error, se muestra la vista actual.
            }
        }

        // GET: Planes/Edit/5
        public ActionResult Edit(int id) // D) Para el editar podemos traer los datos y enviarlos 
        {
            using (DbModels context = new DbModels()) // se crea la instancia
            {
                return View(context.Planes.Where(x => x.Id == id).FirstOrDefault()); //en este metodo estamos haciendo lo mismo que
                                                                                      //en los detalles o details, ya que estamos 
                                                                                      //llamando el id de la tabla planes del contexto
                                                                                      //de la base de datos, pero con la diferencia que con
                                                                                      //el FirstOrDefault estamos indicando que nos traiga 
                                                                                      //el primero por defecto, es decir que nos traiga
                                                                                      //el id 5 en etse caso por ejemplo.
            }
        }

        // POST: Planes/Edit/5       En esta parte vamos a enviar el edit.
        [HttpPost]
        public ActionResult Edit(int id, Planes planes)  //En esta parte lo que se hizo dentro de los parametros es incluir la coleccion
                                                        //Planes y su identificador planes que es la clase que va a traer
        {
            try
            {
                using (DbModels context = new DbModels()) //Se crea la instancia para traer desde el contexto la DbModel los planes
                {
                    context.Entry(planes).State = EntityState.Modified; //Obtiene la entrada de seguimiento del objeto planes en el
                                                                        //contexto. Entry es un método que proporciona acceso a la
                                                                        //información de seguimiento de una entidad específica en
                                                                        //el contexto de la base de datos.

                                                                        //State = EntityState.Modified: Marca el objeto planes como
                                                                        //modificado. Esto le dice a Entity Framework que el objeto
                                                                        //ha sido modificado y que debe actualizar el registro
                                                                        //correspondiente en la base de datos cuando se llame a
                                                                        //SaveChanges().

                    context.SaveChanges(); // se guardan los cambios
                }

                    return RedirectToAction("Index"); //Después de guardar los cambios en la base de datos, redirige al usuario
                                                      //a la acción Index del mismo controlador
            }
            catch
            {
                return View(); //En caso de que ocurra una excepción durante el proceso de actualización, el método vuelve a
                               //mostrar la vista actual. Este enfoque no proporciona detalles específicos sobre el error,
                               //pero permite al usuario intentar de nuevo o verificar el estado actual.
            }
        }

        // GET: Planes/Delete/5
        public ActionResult Delete(int id) // E) El metodo delete obtiene los parametros de tipo entero en el Id
        {
            using (DbModels context = new DbModels()) // Se crea la instancia de nuestro contexto a la base de datos Dbmodels,
            {
                return View(context.Planes.Where(x => x.Id == id).FirstOrDefault()); //Solicitamos que nos retorne una vista del
                                                                                     //contexto en nuestra base de datos DbModel,
                                                                                     //dentro de la tabla planes donde x es igual
                                                                                     //a el Id y que este valor sea igual al Id
                                                                                     //del parametro delete en la parte de arriba.
                                                                                     // y que por defecto nos traiga el primer Id
            }
        }

        // POST: Planes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) //int id: El identificador del objeto Planes que se va a
                                                                      //eliminar. Este parámetro se utiliza para localizar el
                                                                      //registro específico en la base de datos.

                                                                      //FormCollection collection: Un objeto que contiene los
                                                                      //datos del formulario enviado con la solicitud. En este
                                                                      //caso, no se utiliza directamente en el método, pero es
                                                                      //parte del patrón de acción en MVC para manejar datos de
                                                                      //formularios. Puede ser útil si se necesitan datos
                                                                      //adicionales del formulario.
        {
            try
            {
                using (DbModels context = new DbModels()) // se crea la instancia
                {
                    Planes planes = context.Planes.Where(x => x.Id == id).FirstOrDefault(); //.Where(x => x.Id == id): Filtra el
                                                                                            //conjunto para encontrar el registro
                                                                                            //que tiene el identificador igual al
                                                                                            //parámetro id.

                                                                                            //Planes planes: Declara una variable
                                                                                            //para almacenar el objeto Planes
                                                                                            //recuperado de la base de datos.


                    context.Planes.Remove(planes); //context.Planes.Remove(planes): Marca el objeto planes como eliminado en el
                                                   //contexto, Entity Framework realiza el seguimiento de los cambios y prepara
                                                   //el objeto para ser eliminado de la base de datos cuando se llama a
                                                   //SaveChanges().

                    context.SaveChanges(); //guarda los cambios
                }

                return RedirectToAction("Index"); //Después de eliminar el objeto de la base de datos, redirige al usuario a
                                                  //la acción Index del mismo controlador. Esto generalmente muestra una
                                                  //lista actualizada de registros o una vista de confirmación.
            }
            catch
            {
                return View(); // En caso de que ocurra una excepción durante el proceso de eliminación, el método vuelve a
                               // mostrar la vista actual.
            }
        }

        // GET: TipoDestino
        public ActionResult TipoDestino()
        {
            using (DbModels context = new DbModels())
            {
                var viewModel = new TipoDestinoViewModel
                {
                    TipoDestinos = context.Tipo_Destino.ToList()
                };
                return View(viewModel);
            }
        }

    }
}


