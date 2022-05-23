namespace Domain.Models
{
    //*País, *Estado, Cidade, Bairro, Rua, Número
    public class Endereco
    {
        public int Id { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
    }
}