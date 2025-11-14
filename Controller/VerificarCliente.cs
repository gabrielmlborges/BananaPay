using BananaPay.Data;

namespace BananaPay.Controller;

public class VerificarCliente
{
    public static bool Verifica(string nome, string cpf, string senha)
    {
        if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(cpf) || string.IsNullOrWhiteSpace(senha)) return false;

        return true;
    }
}