using Cultura.Application.Dtos.Input;
using Cultura.Application.Dtos.Output;
using Cultura.Application.Interfaces.Service;
using Cultura.Domain.Entities;
using Cultura.Infrastructure.Interfaces.Repositorio;
using Cultura.Infrastructure.Repositories.Interfaces;


namespace Cultura.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IUnitOfWork _unitOfWork;

        

        public UsuarioService(
            IUsuarioRepository usuarioRepository,
            IEnderecoRepository enderecoRepository,
            IUnitOfWork unitOfWork
           
            )
        {
            _usuarioRepository = usuarioRepository;
            _enderecoRepository = enderecoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateUsuario(UsuarioInputDto usuarioDto)
        {

            var endereco = await _enderecoRepository.BuscarEnderecoUnicoAsync(
                usuarioDto.Endereco.Cep,
                usuarioDto.Endereco.Bairro,
                usuarioDto.Endereco.Rua,
                usuarioDto.Endereco.Numero
            );

            if (endereco == null)
            {
                endereco = new Endereco(
                    usuarioDto.Endereco.Cep,
                    usuarioDto.Endereco.Estado,
                    usuarioDto.Endereco.Cidade,
                    usuarioDto.Endereco.Bairro,
                    usuarioDto.Endereco.Rua,
                    usuarioDto.Endereco.Numero
                );

                _enderecoRepository.CreateEndereco(endereco);
            }

           
            var usuario = new Usuario(
                usuarioDto.Nome,
                usuarioDto.Email,
                usuarioDto.Senha,
                usuarioDto.Telefone,
                usuarioDto.DataNascimento,
                endereco 
            );

            _usuarioRepository.CreateUsuario(usuario);


            int linhasAfetadas = await _unitOfWork.CommitAsync();

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