﻿using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContatoMoldel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Digite o nome do contato")]
        
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o email do contato")]
        [EmailAddress(ErrorMessage = "O Email informado não é valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o celular do contato")]
        
        public string Celular { get; set; }


    }
}
