using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Telefono
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezCRUDTelefonoEntities context = new DL.AGutierrezCRUDTelefonoEntities())
                {
                    var query = context.TelefonoGetAll().ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            ML.Telefono telefono = new ML.Telefono();
                            telefono.IdTelefono = item.IdTelefono;
                            telefono.Marca = item.Marca;
                            telefono.Modelo = item.Modelo;
                            telefono.NumSerie = item.NumSerie;

                            result.Objects.Add(telefono);
                            result.Correct = true;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
                result.Ex = Ex;
            }
            return result;
        }
        public static ML.Result GetById(int IdTelefono)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezCRUDTelefonoEntities context = new DL.AGutierrezCRUDTelefonoEntities())
                {
                    var query = context.TelefonoGetById(IdTelefono).FirstOrDefault();
                    if (query != null)
                    {
                        ML.Telefono telefono = new ML.Telefono();
                        telefono.IdTelefono = query.IdTelefono;
                        telefono.Marca = query.Marca;
                        telefono.Modelo = query.Modelo;
                        telefono.NumSerie = query.NumSerie;

                        result.Object = telefono;
                        result.Correct = true;

                    }
                }

            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
                result.Ex = Ex;
            }
            return result;
        }
        public static ML.Result Add(ML.Telefono telefono)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezCRUDTelefonoEntities context = new DL.AGutierrezCRUDTelefonoEntities())
                {
                    var query = context.TelefonoAdd(telefono.Marca, telefono.Modelo, telefono.NumSerie);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {

                        result.Correct = false;
                    }
                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
                result.Ex = Ex;
            }
            return result;
        }
        public static ML.Result Update(ML.Telefono telefono)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezCRUDTelefonoEntities context = new DL.AGutierrezCRUDTelefonoEntities())
                {
                    var query = context.TelefonoUpdate(telefono.IdTelefono, telefono.Marca, telefono.Modelo, telefono.NumSerie);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {

                        result.Correct = false;
                    }
                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
                result.Ex = Ex;
            }
            return result;
        }
        public static ML.Result Delete(int IdTelefono)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezCRUDTelefonoEntities context = new DL.AGutierrezCRUDTelefonoEntities())
                {
                    var query = context.TelefonoDelete(IdTelefono);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {

                        result.Correct = false;
                    }
                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
                result.Ex = Ex;
            }
            return result;
        }

    }
}
