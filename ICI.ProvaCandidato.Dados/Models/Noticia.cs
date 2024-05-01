﻿namespace ICI.ProvaCandidato.Dados.Models
{
    public class Noticia : Entity
    {
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}