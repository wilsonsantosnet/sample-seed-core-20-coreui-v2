using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Seed.Dto
{
	public class SampleStandartDto  : DtoBase
	{
	
        

        public virtual int SampleStandartId {get; set;}

        [Required(ErrorMessage="SampleStandart - Campo Name é Obrigatório")]
        [MaxLength(200, ErrorMessage = "SampleStandart - Quantidade de caracteres maior que o permitido para o campo Name")]
        public virtual string Name {get; set;}


		
	}
}