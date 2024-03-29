﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreApiNoticias.Models;

namespace NetCoreApiNoticias.Services
{
    public class NoticiaService
    {
        private readonly NoticiasDBContext _noticiasDBContext;
        public NoticiaService( NoticiasDBContext noticiasDBContext)
        {
            _noticiasDBContext = noticiasDBContext;
        }


        public List<Noticia> Obtener()
        {
            var Resultado = _noticiasDBContext.Noticia.Include(x => x.Autor).ToList();
            return Resultado;
        }

        public Boolean AgregarNoticia(Noticia _noticia)
        {
            try
            {
                _noticiasDBContext.Noticia.Add(_noticia);
                _noticiasDBContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public Boolean EditarNoticia (Noticia _noticia)
        {
            try
            {
                var noticiaBaseDatos = _noticiasDBContext.Noticia.Where(busqueda => busqueda.NoticiaID == _noticia.NoticiaID).FirstOrDefault();
                noticiaBaseDatos.Titulo = _noticia.Titulo;
                noticiaBaseDatos.Descripcion = _noticia.Descripcion;
                noticiaBaseDatos.Contenido = _noticia.Contenido;
                noticiaBaseDatos.Fecha = _noticia.Fecha;
                noticiaBaseDatos.AutorID = _noticia.AutorID;

                _noticiasDBContext.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public Boolean EliminarNoticia (int _NoticiaID)
        {
            try
            {
                var noticiaBaseDatos = _noticiasDBContext.Noticia.Where(busqueda => busqueda.NoticiaID == _NoticiaID).FirstOrDefault();
                _noticiasDBContext.Remove(noticiaBaseDatos);
                _noticiasDBContext.SaveChanges();


                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

    }
}
