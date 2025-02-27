using api_filmes_senai.Context;
using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace api_filmes_senai.Repositories
{

    public class FilmeRepository : IFilmeRepository
    {
        private readonly Filmes_Context _context;

        public FilmeRepository(Filmes_Context context)
        {
            _context = context;
        }
        public void Atualizar(Guid id, Filme filme)
        {
            Filme filmeBuscado = _context.Filme.Find(id)!;
            if (filmeBuscado != null)
            {
                filmeBuscado.IdGenero = filme.IdGenero;

                filmeBuscado.Titulo = filme.Titulo;
            }
            _context.SaveChanges();
        }

        public Filme BuscarPorId(Guid id)
        {
            try
            {
                Filme filmeBuscado = _context.Filme.Find(id)!;

                return filmeBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Filme novoFilme)
        {
            try
            {
                _context.Filme.Add(novoFilme);

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Genero novoFilme)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            try
            {
                Filme filmeBuscados = _context.Filme.Find(id)!;

                if (filmeBuscados != null)
                {
                    _context.Filme.Remove(filmeBuscados);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Filme> Listar()
        {
            try
            {
                List<Filme> listaDeFilmes = _context.Filme
                .Include(global => global.Genero)

                    .Select(f => new Filme()
                    {
                        IdFilme = f.IdFilme,
                        Titulo = f.Titulo,

                        Genero = new Genero
                        {
                            IdGenero = f.IdGenero,
                            Nome = f.Genero!.Nome
                        }
                    }).ToList();


                return listaDeFilmes;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Filme> ListarPorGenero(Guid idGenero)
        {
            try
            {
            List<Filme> listaDeFilmes = _context.Filme
                .Include(g => g.Genero)
                .Where(f => f.IdGenero == idGenero) .ToList();

            return listaDeFilmes ;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
