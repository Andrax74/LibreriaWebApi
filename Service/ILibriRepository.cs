using System.Collections.Generic;
using System.Threading.Tasks;
using LibreriaWebApi.Models;

namespace LibreriaWebApi.Service
{
    public interface ILibriRepository
    {
        ICollection<Libri> SelAll();
        Libri SelLibroById(string ISBN);
    }
}