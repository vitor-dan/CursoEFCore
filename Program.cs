using System;
using CursoEFCore.Domain;
using CursoEFCore.Data.Configurations;
using CursoEFCore.ValueObjects;
using System.Linq;

namespace CursoEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            // InserirDados();
            // InserirDadosEmMassa();
            //ConsultarDados();
            //AtualizarDados();
            RemoverRegistro();
        }

        private static void InserirDadosEmMassa()
        {
            var produto = new Produto
            {
                Descricao = "Produto Teste",
                CodigoBarras = "1234567891231",
                Valor = 10m,
                TipoProduto = TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };

            var cliente = new Cliente
            {
                Nome = "Vitor Daniel",
                CEP = "99999000",
                Cidade = "São Paulo",
                Estado = "SP",
                Telefone = "990011111"
            };

            using var db = new Data.ApplicationContext();
            db.AddRange(produto, cliente);
            var registros = db.SaveChanges();
            System.Console.WriteLine("Total Registros: " + registros);
        }

        private static void InserirDados()
        {
            var produto = new Produto
            {
                Descricao = "Produto Teste",
                CodigoBarras = "1234567891231",
                Valor = 10m,
                TipoProduto = ValueObjects.TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };

            using var db = new Data.ApplicationContext();
            db.Produtos.Add(produto);
            // db.Set<Produto>().Add(produto);
            // db.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            // db.Add(produto);

            var registros = db.SaveChanges();
            Console.WriteLine(registros);
        }

        private static void ConsultarDados()
        {
            using var db = new Data.ApplicationContext();
            // var consultaPorSintaxe = (from c in db.Clientes where c.Id>0 select c).ToList();
            var consultaPorMetodo = db.Clientes.Where(p => p.Id > 0).ToList();
            foreach (var cliente in consultaPorMetodo)
            {
                db.Clientes.Find(cliente.Id);
            }
        }

        private static void AtualizarDados()
        {
            using var db = new Data.ApplicationContext();
            //var cliente = db.Clientes.Find(3);

            var cliente = new Cliente
            {
                Id = 3
            };

            var clienteDesconectado = new { Nome = "Cliente desconectado passo 3", Telefone = "79444444" };
            
            db.Attach(cliente);

            db.Entry(cliente).CurrentValues.SetValues(clienteDesconectado);
            //db.Clientes.Update(cliente);
            db.SaveChanges();
        }

        private static void RemoverRegistro()
        {
            using var db = new Data.ApplicationContext();

            var cliente = db.Clientes.Find(3);
            db.Clientes.Remove(cliente);

            db.SaveChanges();
        }

    }
}
