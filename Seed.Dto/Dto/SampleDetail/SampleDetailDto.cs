using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Seed.Dto
{
	public class SampleDetailDto  : DtoBase
	{
	
        

        public virtual int SampleDetailId {get; set;}

        

        public virtual int SampleId {get; set;}

        [Required(ErrorMessage="SampleDetail - Campo Name é Obrigatório")]
        [MaxLength(50, ErrorMessage = "SampleDetail - Quantidade de caracteres maior que o permitido para o campo Name")]
        public virtual string Name {get; set;}

        [Required(ErrorMessage="SampleDetail - Campo Descricao é Obrigatório")]
        public virtual string Descricao {get; set;}

        

        public virtual DateTime? Data {get; set;}


		
	}
}