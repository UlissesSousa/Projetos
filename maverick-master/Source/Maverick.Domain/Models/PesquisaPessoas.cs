using Otc.ComponentModel.DataAnnotations;

namespace Maverick.Domain.Models
{
    public class PesquisaPessoas
    {
        /// <summary>
        /// Termo a ser pesquisado.
        /// </summary>
        [Required(ErrorKey = "TermoPesquisaObrigatorio")]
        public string TermoPesquisa { get; set; }
    }
}
