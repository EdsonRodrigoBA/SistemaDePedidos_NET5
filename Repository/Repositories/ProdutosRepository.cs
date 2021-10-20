using Domain.Dtos;
using Domain.Entities;
using Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ProdutosRepository : BaseRepository, IProdutoRepository
    {

        public void OrdernarPornome(ref IQueryable<Produtos> query, string ordem)
        {
            if (String.IsNullOrEmpty(ordem) || ordem.ToUpper() == "ASC")
            {
                query = query.OrderBy(x => x.nome);
            }
            else
            {
                query = query.OrderByDescending(x => x.nome);

            }
        }


        public ProdutosRepository(MyAppContext context) : base(context)
        {
        }
        public dynamic Get(String ordem)
        {
            var queryProdutos = _context.produtos
                     .Include(x => x.CategoriaProduto)
                    .Where(x => x.active == "S");

            OrdernarPornome(ref queryProdutos, ordem);

            var queryRetorno = queryProdutos.Select(x => new
            {
                x.nome,
                x.preco,
                x.active,
                CategoriaProduto = x.CategoriaProduto.nome,
                Imagens = x.Imagens.Select(img => new
                {
                    img.id,
                    img.principal,
                    img.nome,
                    img.caminhoarquivo
                }),
            });


            return queryRetorno.ToList();
        }

        public dynamic Search(String param, int pagina, string ordem)
        {
            var queryProdutos = _context.produtos
                  .Include(x => x.CategoriaProduto)
                .Where(x => x.active == "S" &&
                 (x.nome.ToUpper().Contains(param.ToUpper()) || x.descricao.ToUpper().Contains(param.ToUpper())))
                .Skip(TamanhoPagina * (pagina - 1))
                .Take(TamanhoPagina);
            OrdernarPornome(ref queryProdutos, ordem);
            var queryRetorno = queryProdutos
                .Select(x => new
                {
                    x.nome,
                    x.preco,
                    x.active,
                    CategoriaProduto = x.CategoriaProduto.nome,
                    Imagens = x.Imagens.Select(img => new
                    {
                        img.id,
                        img.principal,
                        img.nome,
                        img.caminhoarquivo
                    }),
                });



            var produtos = queryRetorno.ToList();


            var quantidadeProdutos = _context.produtos.Where(x => x.active == "S" &&
                (x.nome.ToUpper().Contains(param.ToUpper()) || x.descricao.ToUpper().Contains(param.ToUpper())))
                .Count();

            var quantidadePaginas = (int)Math.Ceiling((decimal)quantidadeProdutos / TamanhoPagina);

            if (quantidadePaginas < 1)
            {
                quantidadePaginas = 1;
            }

            return new { produtos, quantidadePaginas };
        }

        public dynamic Detalhes(int id)
        {
            return _context.produtos.
                   Include(x => x.CategoriaProduto)
                   .Include(x => x.Imagens)
                   .Where(x => x.active == "S" & x.id == id)
                    .Select(x => new
                    {
                        x.id,
                        x.nome,
                        x.descricao,
                        x.preco,
                        x.active,
                        x.created_at,
                        Imagens = x.Imagens.Select(img => new
                        {
                            img.id,
                            img.principal,
                            img.nome,
                            img.caminhoarquivo
                        }),
                        CategoriaProduto = new
                        {
                            x.CategoriaProduto.id,
                            x.nome,
                            x.descricao
                        },

                    })
                   .FirstOrDefault();
        }

        public dynamic Imagens(int id)
        {
            return _context.produtos

                   .Include(x => x.Imagens)
                   .Where(x => x.active == "S" & x.id == id)
                    .SelectMany(x => x.Imagens, (produto, imagem) => new
                    {
                        id_produto = produto.id,
                        imagem.id,
                        imagem.principal,
                        imagem.nome,
                        imagem.caminhoarquivo


                    });

        }

        public dynamic CriarProdutos(ProdutosDTO model)
        {
            try
            {
                if (!_context.categoriaProdutos.Any())
                {
                    CategoriaProduto categoriaProduto = new CategoriaProduto();
                    categoriaProduto.active = "S";
                    categoriaProduto.nome = "CATEGORIA TESTE";
                    categoriaProduto.created_at = DateTime.Now;
                    _context.Add(categoriaProduto);
                    _context.SaveChanges();
                }

                var produtos = new Produtos();
                produtos.nome = model.nome;
                produtos.preco = model.preco;
                produtos.codigo = model.codigo;
                produtos.ean = produtos.ean;
                produtos.id_categoria = 1;

                produtos.active = "S";
                produtos.Imagens = new List<Imagens>();


                return null;


            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
