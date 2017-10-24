using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Projeto.Repositorio.Configuracoes;

namespace Projeto.Repositorio.Persistencia
{
    public class GenericRepositorio<T>
        where T : class
    {
        public void Inserir(T obj)
        {
            using (Conexao con = new Conexao())
            {
                con.Entry(obj).State = EntityState.Added;
                con.SaveChanges();
            }
        }

        public void Atualizar(T obj)
        {
            using (Conexao con = new Conexao())
            {
                con.Entry(obj).State = EntityState.Modified;
                con.SaveChanges();
            }
        }

        public void Excluir(T obj)
        {
            using (Conexao con = new Conexao())
            {
                con.Entry(obj).State = EntityState.Deleted;
                con.SaveChanges();
            }
        }

        public List<T> ListarTodos()
        {
            using (Conexao con = new Conexao())
            {
                return con.Set<T>().ToList();
            }
        }

        public T ObterPorId(int id)
        {
            using (Conexao con = new Conexao())
            {
                return con.Set<T>().Find(id);
            }
        }
    }
}
