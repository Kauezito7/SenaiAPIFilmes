using System.Linq.Expressions;
using api_filmes_senai.Context;
using api_filmes_senai.Controllers;
using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai.Repositories
{
    /// <summary>
    /// Classe que vai implementar a interface IGeneroRepository
    /// Ou seja, vamos implemntar os metodos, toda a logica dos metodos 
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// Viavel privada e somente leitura que "guarda" od dados do contexto
        /// </summary>
        private readonly Filmes_Context _context;

        /// <summary>
        /// Contrutor do repositorio
        /// Aqui, toda vez que o construtor for chamado, os dados do contexto estara disponiveis
        /// </summary>
        /// <param name="contexto">Dados do contexto</param>
        public GeneroRepository(Filmes_Context contexto)
        {
            _context = contexto;
        }


        public void Atualizar(Guid id, Genero genero)
        {
            try
            {
                Genero generoBuscado = _context.Genero.Find(id)!;
                if (generoBuscado != null)
                {
                    generoBuscado.Nome = genero.Nome;
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Genero BuscarPorId(Guid id)
        {
            try
            {

                Genero generoBusacado = _context.Genero.Find(id)!;
                return generoBusacado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Genero novoGenero)
        {
            try
            {
                //Adciona umnovo genero na tabela Generos (BD)
                _context.Genero.Add(novoGenero);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Genero generobuscado = _context.Genero.Find(id)!;

                if (generobuscado != null)
                {
                    _context.Genero.Remove(generobuscado);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Genero> Listar()
        {
            try
            {
                List<Genero> listaGeneros = _context.Genero.ToList();

                return listaGeneros;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}


