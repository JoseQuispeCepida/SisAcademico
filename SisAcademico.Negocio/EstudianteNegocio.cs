using SisAcademico.DATOS;
using SisAcademico.Entities;
using SisAcademico.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace SisAcademico.Negocio
{
    public class EstudianteNegocio : IEstudianteRepositorio
    {
        AcademicoContexto db = new AcademicoContexto();

        public void Actualizar(Estudiante estudiante)
        {
            db.Entry(estudiante).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Agregar(Estudiante estudiante)
        {
            db.estudiante.Add(estudiante);
            db.SaveChanges();
        }

        public List<Estudiante> ListarEstudiantes()
        {
            var query = from x in db.estudiante
                        orderby x.Id
                        select x;
            return query.ToList();
            //return db.estudiante.ToList();
        }
        public List<Estudiante> ListarEstudiantesxNombre(string nombre)
        {
            var query = from x in db.estudiante
                        orderby x.Nombres.Contains(nombre)
                        select x;
            return query.ToList();
        }

        public Estudiante Buscar(int id)
        {
            var Busqueda = db.estudiante.Find(id);
            return Busqueda;
        }
    }
}
