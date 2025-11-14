using BananaPay.Models;

namespace BananaPay.Controller;

public class VerificarConta
{
    public static bool Verifica(Cliente cliente, int clienteId)
    {
        if (cliente == null || clienteId <= 0) return false;
        return true;
    }
}