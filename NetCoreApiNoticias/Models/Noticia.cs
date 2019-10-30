using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace NetCoreApiNoticias.Models
{
    public class Noticia
    {
        public int NoticiaID { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Contenido { get; set; }
        public DateTime Fecha { get; set; }
        public int AutorID { get; set; }
        public Autor Autor { get; set; }

        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<Noticia> mapeoNoticia)
            {
                mapeoNoticia.HasKey(x => x.NoticiaID);
                mapeoNoticia.Property(x => x.Titulo).HasColumnName("Titulo");
                mapeoNoticia.Property(x => x.Descripcion).HasColumnName("Descripcion");
                mapeoNoticia.Property(x => x.Contenido).HasColumnName("Contenido");
                mapeoNoticia.Property(x => x.Fecha).HasColumnName("Fecha");
                mapeoNoticia.Property(x => x.AutorID).HasColumnName("AutorID");

                mapeoNoticia.ToTable("Noticia");
                mapeoNoticia.HasOne(x => x.Autor);
            }
        }

    }


}
