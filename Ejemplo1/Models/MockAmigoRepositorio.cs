using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejemplo1.Models
{
    public class MockAmigoRepositorio:IAmigoAlmacen
    {
        private List<Amigo> amigosLista;

        public MockAmigoRepositorio()
        {
            amigosLista = new List<Amigo>();
            amigosLista.Add(new Amigo() { Id = 1, Nombre = "Martin", Ciudad = Provincia.Baleares , Email = "mat345@gmail.com" });
            amigosLista.Add(new Amigo() { Id = 2, Nombre = "Antonio", Ciudad = Provincia.León, Email = "antonil@gmail.com" });
            amigosLista.Add(new Amigo() { Id = 3, Nombre = "Daniel", Ciudad = Provincia.Granada, Email = "Danits@gmail.com" });

        }

        public Amigo dameDatosAmigo(int Id)
        {
            return this.amigosLista.FirstOrDefault(e => e.Id == Id);
        }

        public List<Amigo> DameTodosLosAmigos()
        {
            return amigosLista;
        }

        public Amigo nuevo(Amigo amigo)
        {
            amigo.Id = amigosLista.Max( a =>a.Id ) + 1;
            amigosLista.Add(amigo);
            return amigo;
        }

    }
}
