using System.ComponentModel.DataAnnotations;

namespace SUSS.DOM.Entities
{
    public class FormO: BaseFormDOM
    {
        [Required]
        public string AnswertoQuestion { get; set; }
    }
}
