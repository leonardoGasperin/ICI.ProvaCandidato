using ICI.ProvaCandidato.Dados.Dto;
using ICI.ProvaCandidato.Dados.Models;
using ICI.ProvaCandidato.Negocio.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Web.Pages.Home
{

    public class HomeModel : PageModel
    {
        [BindProperty]
        public List<TagDto> Tags { get; set; } = new List<TagDto>();

        private readonly NoticiaController _noticiaController;
        private readonly UsuarioController _usuarioController;
        private readonly TagController _tagController;

        public HomeModel(NoticiaController noticiaController, UsuarioController usuarioController, TagController tagController)
        {
            _noticiaController = noticiaController;
            _usuarioController = usuarioController;
            _tagController = tagController;
        }
        public string NomeDoModelo { get; set; }

        public async Task OnGetAsync()
        {
            NomeDoModelo = "Valor inicial";
        }
    }
}
