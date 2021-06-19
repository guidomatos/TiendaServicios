using AutoMapper;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using TiendaServicios.Api.Libro.Aplicacion;
using TiendaServicios.Api.Libro.Modelo;
using TiendaServicios.Api.Libro.Persistencia;
using Xunit;

namespace TiendaServicios.Api.Libro.Tests
{
    public class LibrosServiceTest
    {

        private IEnumerable<LibreriaMaterial> ObtenerDataPrueba()
        {
            A.Configure<LibreriaMaterial>()
                .Fill( x => x.Titulo ).AsArticleTitle()
                .Fill ( x => x.LibreriaMaterialId, () => { return Guid.NewGuid(); } )
                ;

            var lista = A.ListOf<LibreriaMaterial>(30);
            lista[0].LibreriaMaterialId = Guid.Empty;

            return lista;
        }

        private Mock<ContextoLibreria> CrearContexto()
        {
            var dataPrueba = ObtenerDataPrueba().AsQueryable();

            var dbSet = new Mock<DbSet<LibreriaMaterial>>();
            dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x => x.Provider).Returns(dataPrueba.Provider);
            dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x => x.Expression).Returns(dataPrueba.Expression);
            dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x => x.ElementType).Returns(dataPrueba.ElementType);
            dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x => x.GetEnumerator()).Returns(dataPrueba.GetEnumerator());
        }

        [Fact]
        public void GetLibros()
        {
            // que metodo dentro de mi microservice libro se esta encargando
            // de realizar la consulta de libros de la base de datos ??
            // 1. Emular a la instancia de entity framework core - ContextoLibreria
            // pára emular las acciones y eventos de un objeto en un ambiente de unit test
            // usaremos un objeto de Mock

            var mockContexto = new Mock<ContextoLibreria>();

            // 2. Emular al mapping IMapper

            var mockMapper = new Mock<IMapper>();

            // 3. Instanciar a la clase Manejador y pasarle como parametro los metodos

            Consulta.Manejador manejador = new Consulta.Manejador(mockContexto.Object, mockMapper.Object);


        }
    }
}
