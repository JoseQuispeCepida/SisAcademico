using SisAcademico.DATOS;
using SisAcademico.Entities;
using SisAcademico.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAcademico.Negocio
{
    public class EstudianteNegocio : IEstudianteRepositorio
    {
        AcademicoContexto bd = new AcademicoContexto();

        public List<Estudiante> ListarEstudiantes(){
            return bd.estudiante.ToList();
        }
        public void Actualizar(Estudiante estudiante)
        {
            throw new NotImplementedException();
        }

        public void Agregar(Estudiante estudiante)
        {
            throw new NotImplementedException();
        }

        public Estudiante Buscar()
        {
            throw new NotImplementedException();
        }

        public List<Estudiante> FiltroID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
