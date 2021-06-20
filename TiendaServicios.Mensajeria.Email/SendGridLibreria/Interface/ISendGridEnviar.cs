using System.Threading.Tasks;
using TiendaServicios.Mensajeria.Email.SendGridLibreria.Modelo;

namespace TiendaServicios.Mensajeria.Email.SendGridLibreria.Interface
{
    public interface ISendGridEnviar
    {
        Task<(bool resultado, string errorMessage)> EnviarEmail(SendGridData data);
    }
}
