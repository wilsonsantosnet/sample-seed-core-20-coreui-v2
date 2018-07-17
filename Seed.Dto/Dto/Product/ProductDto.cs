using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Seed.Dto
{
	public class ProductDto  : DtoBase
	{
	
        

        public virtual int ProductId {get; set;}

        [Required(ErrorMessage="Product - Campo Name é Obrigatório")]
        [MaxLength(100, ErrorMessage = "Product - Quantidade de caracteres maior que o permitido para o campo Name")]
        public virtual string Name {get; set;}

        [Required(ErrorMessage="Product - Campo Description é Obrigatório")]
        public virtual string Description {get; set;}


		
	}
}