namespace BananaPay.Models;

public class Cliente
{
    public int ClienteID { get; set; }
    public string NomeDono { get; set; }
    public string CpfDono { get; set; }
    public string Senha { get; set; }

    public Cliente(string nomeDono, string cpfDono, string senha)
    {
        NomeDono = nomeDono;
        CpfDono = cpfDono;
        Senha = senha;
    }

}