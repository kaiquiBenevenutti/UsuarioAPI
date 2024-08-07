using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Models;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{
    private CadastroService _cadastroService;

    public UsuarioController( CadastroService cadastroService)
    {
        _cadastroService = cadastroService;
    }

    [HttpPost] 
    public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
    {
        await _cadastroService.Cadastra(dto);
        return Ok("Usuário cadastrado!");
    }
}
