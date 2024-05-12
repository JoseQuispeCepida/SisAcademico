﻿using SisAcademico.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAcademico.Negocio.Interfaces
{
    public interface IEstudianteRepositorio
    {
        void Agregar(Estudiante estudiante);
        void Actualizar(Estudiante estudiante);
        List<Estudiante> ListarEstudiantes();
        List<Estudiante> ListarEstudiantesxNombre(String nombre);
        Estudiante Buscar(int id);
    }
}
