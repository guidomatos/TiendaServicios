using AutoMapper;
using Moq;
using System;
using TiendaServicios.Api.Libro.Aplicacion;
using TiendaServicios.Api.Libro.Persistencia;
using Xunit;

namespace TiendaServicios.Api.Libro.Tests
{
    public class LibrosServiceTest
    {
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
