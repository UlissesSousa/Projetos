using ServiceNamespace.Domain.Core.ValueObjects;
using Flunt.Validations;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace ServiceNamespace.Domain.ValueObjects
{
    public class Senha : ValueObject
    {
        public Senha(string valor)
        {
            Valor = valor;
            AddNotifications(new Contract()
              .IsNotNullOrWhiteSpace(Valor, nameof(Valor), "Senha não pode ser nulo ou vazio")
              .IsGreaterThan(Valor != null ? Valor.Length : 0, 8, nameof(Valor), "Senha deve ser maior que 8 caracteres")
              .IsTrue(ObterForcaDaSenha(Valor) == ForcaDaSenha.Aceitavel, nameof(Valor), "Senha não atende ao requisitos mínimos")
            );
        }
        public string Valor { get; private set; }
        public override string ToString()
        {
            return Valor;
        }

        internal int ObterPontosSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha)) return 0;
            senha = senha.Replace(" ", "");
            int pontosPorTamanho = ObterPontoPorTamanho(senha, 9);
            int pontosPorMinusculas = ObterPontoPorMinusculas(senha);
            int pontosPorMaiusculas = ObterPontoPorMaiusculas(senha);
            int pontosPorDigitos = ObterPontoPorDigitos(senha);
            int pontosPorSimbolos = ObterPontoPorSimbolos(senha);
            int pontosPorNaoRepeticao = ObterPontoPorDigitosNaoRepetidos(senha);
            return pontosPorTamanho + pontosPorMinusculas + pontosPorMaiusculas + pontosPorDigitos + pontosPorSimbolos+ pontosPorNaoRepeticao;
        }

        internal int ObterPontoPorTamanho(string senha, int tamanhoMinimo)
        {
            return tamanhoMinimo <= senha.Length ? 10 : 0;
        }

        internal int ObterPontoPorMinusculas(string senha)
        {
            int total = senha.Length - Regex.Replace(senha, "[a-z]", "").Length;
            return total > 0 ? 10 : 0;
        }

        internal int ObterPontoPorMaiusculas(string senha)
        {
            int total = senha.Length - Regex.Replace(senha, "[A-Z]", "").Length;
            return total > 0 ? 10 : 0;
        }

        internal int ObterPontoPorDigitos(string senha)
        {
            int total = senha.Length - Regex.Replace(senha, "[0-9]", "").Length;
            return total > 0 ? 10 : 0;
        }

        internal int ObterPontoPorDigitosNaoRepetidos(string senha)
        {
            int total = 0;
            var validacao = new Regex(@"(\w)*.*\1");
            if (!validacao.IsMatch(senha))
                total = 10;
            return total ;
        }
        internal int ObterPontoPorSimbolos(string senha)
        {
            int total = Regex.Replace(senha, "[a-zA-Z0-9]", "").Length;
            return total > 0 ? 10 : 0;
        }

        internal ForcaDaSenha ObterForcaDaSenha(string senha)
        {
            int placar = ObterPontosSenha(senha);

            if (placar < 60)
                return ForcaDaSenha.Inaceitavel;
            else
                return ForcaDaSenha.Aceitavel;
        }
    }

    internal enum ForcaDaSenha
    {
        Inaceitavel,
        Aceitavel
    }
}

