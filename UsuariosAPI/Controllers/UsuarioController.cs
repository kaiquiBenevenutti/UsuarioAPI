using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Models;

namespace UsuariosAPI.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{
    private IMapper _mapper;
    private UserManager<Usuario> _userManager;

    public UsuarioController(UserManager<Usuario> userManager)
    {
        _userManager = userManager;
    }

    public UsuarioController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpPost] 
    public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
    {
        Usuario usuario = _mapper.Map<Usuario>(dto);

        IdentityResult resultado = await _userManager.CreateAsync(usuario,
            dto.Password);

        if (resultado.Succeeded) return Ok("Usuário cadastrado!");

        throw new ApplicationException("Falha ao cadastrar usuário!");
    }
}
