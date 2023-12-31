﻿using healthclinic_webapi.Contexts;
using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;
using healthclinic_webapi.Utils;
using Microsoft.EntityFrameworkCore;

namespace healthclinic_webapi.Repositories
{
    /// <summary>
    /// Classe com os metodos de perfil
    /// </summary>
    public class PerfilRepository : IPerfilRepository
    {
        private readonly ClinicContext ctx;

        /// <summary>
        /// Chama a context
        /// </summary>
        public PerfilRepository()
        {
            ctx = new ClinicContext();
        }

        /// <summary>
        /// Atualiza um perfil
        /// </summary>
        /// <param name="id">Id do perfil que sera atualizado</param>
        /// <param name="perfil">Novos dados de perfil</param>
        public void Atualizar(Guid id, Perfil perfil)
        {
            ctx.Perfil.Where(p => p.IdPerfil == id)
                .ExecuteUpdateAsync(updates =>
                    updates.SetProperty(p => p.Email, perfil.Email)
                           .SetProperty(p => p.Senha, perfil.Senha));
        }

        /// <summary>
        /// Busca um perfil por email e senha
        /// </summary>
        /// <param name="email">email digitado</param>
        /// <param name="senha">senha digitada</param>
        /// <returns>retorna o perfil buscado</returns>
        public Perfil BuscarPorEmailSenha(string email, string senha)
        {
            try
            {
                Perfil perfilBuscado = ctx.Perfil
                    .Select(p => new Perfil
                    {
                        IdPerfil = p.IdPerfil,
                        Email = p.Email,
                        Senha = p.Senha,
                        TiposUsuario = new TiposUsuario
                        {
                            IdTiposUsuario = p.TiposUsuario.IdTiposUsuario,
                            Tipo = p.TiposUsuario.Tipo
                        }
                    }).FirstOrDefault(p => p.Email == email);

                if (perfilBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, perfilBuscado.Senha);

                    if (confere)
                    {
                        return perfilBuscado;
                    }

                    
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Cadastra um novo perfil     
        /// </summary>
        /// <param name="perfil">Novo perfil</param>
        public void Cadastrar(Perfil perfil)
        {
            perfil.Senha = Criptografia.GerarHash(perfil.Senha);

            ctx.Perfil.Add(perfil);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um perfil
        /// </summary>
        /// <param name="id">Id do perfil que sera deletado</param>
        public void Deletar(Guid id)
        {
            ctx.Perfil.Where(p => p.IdPerfil == id)
                .ExecuteDeleteAsync();

        }
    }
}
