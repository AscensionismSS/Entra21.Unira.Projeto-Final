
using Cultura.Application.Dtos.Input;
using Cultura.Application.Dtos.Output;
using Cultura.Application.Interfaces.Service;
using Cultura.Domain.Entities;
using Cultura.Infrastructure.Interfaces.Repositorio;

namespace Cultura.Application.Services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task CreateUsuario(UsuarioInputDto usuarioDto)
        {
            // Map UsuarioCreateDto to Usuario entity
            var usuario = new Usuario
            {
                Nome = usuarioDto.Nome,
                Email = usuarioDto.Email,
                Senha = usuarioDto.Senha,
                Telefone = usuarioDto.Telefone,
                DataNascimento = usuarioDto.DataNascimento,
                Endereco = new Endereco
                {
                    Cep = usuarioDto.Endereco.Cep,
                    Estado = usuarioDto.Endereco.Estado,
                    Cidade = usuarioDto.Endereco.Cidade,
                    Bairro = usuarioDto.Endereco.Bairro,
                    Numero = usuarioDto.Endereco.Numero,
                    Rua = usuarioDto.Endereco.Rua
                }
            };

            await _usuarioRepository.CreateUsuario(usuario);
        }


        public async Task<bool> UpdateUsuario(int id, UsuarioInputDto usuarioDto)
        {

            var usuario = await _usuarioRepository.GetUsuarioById(id);
            if (usuario == null)
            {
                return false;
            }

            usuario.Nome = usuarioDto.Nome;
            usuario.Email = usuarioDto.Email;
            usuario.Senha = usuarioDto.Senha;
            usuario.Telefone = usuarioDto.Telefone;
            usuario.DataNascimento = usuarioDto.DataNascimento;


            usuario.Endereco.Cep = usuarioDto.Endereco.Cep;
            usuario.Endereco.Estado = usuarioDto.Endereco.Estado;
            usuario.Endereco.Cidade = usuarioDto.Endereco.Cidade;
            usuario.Endereco.Bairro = usuarioDto.Endereco.Bairro;
            usuario.Endereco.Numero = usuarioDto.Endereco.Numero;
            usuario.Endereco.Rua = usuarioDto.Endereco.Rua;

            return await _usuarioRepository.UpdateUsuario(usuario);

        }

        public async Task<UsuarioOutputDto> LoginValidation(LoginInputDto login)
        {
            var usuario = await _usuarioRepository.LoginValidation(login.Email, login.Senha);
            if (usuario == null)
            {
                return null; 
            }
           
            var usuarioOutput = new UsuarioOutputDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                DataNascimento = usuario.DataNascimento,
                Endereco = new EnderecoOutputDto
                {
                    Cep = usuario.Endereco.Cep,
                    Estado = usuario.Endereco.Estado,
                    Cidade = usuario.Endereco.Cidade,
                    Bairro = usuario.Endereco.Bairro,
                    Numero = usuario.Endereco.Numero,
                    Rua = usuario.Endereco.Rua
                }
            };
            return usuarioOutput;

        }
    }
}
