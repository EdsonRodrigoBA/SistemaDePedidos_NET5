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
    public class CidadesRepository : BaseRepository, ICidadesRepository
    {
        public CidadesRepository(MyAppContext context) : base(context)
        {
        }

        public dynamic Get()
        {
            return _context
                     .cidades
                     .Where(x => x.active == "S")
                     .Select(x => new
                     {
                         x.id,
                         x.nome,
                         x.codigo_ibge,
                         x.uf,
                         x.active
                     })
                     .ToList();

        }

        public int Criar(CidadesDTO model)
        {

            var nomeDuplicado = _context.cidades.Any(x => x.active == "S" && x.nome.ToUpper() == model.nome);
            if (nomeDuplicado)
            {
                return 0;
            }


            var cidade = new Cidades()
            {
                nome = model.nome,
                uf = model.uf,
                active = model.active,
                codigo_ibge = model.codigo_ibge,
                created_at = DateTime.Now,

            };
            try
            {


                _context.Add(cidade);
                _context.SaveChanges();

                return cidade.id;
            }
            catch (Exception ex)
            {

            }

            return 0;
        }

        public dynamic Alterar(CidadesDTO model)
        {
            var cidade = _context.cidades.Find(model.id);
            if (cidade == null)
            {
                String mensagem = "Cidade Não Encontrada";
                return new { mensagem };
            }
            cidade.nome = model.nome;
            cidade.active = model.active;
            cidade.codigo_ibge = model.codigo_ibge;
            cidade.uf = model.uf;
            _context.Update(cidade);

            //_context.Entry(cidade).CurrentValues.SetValues(model);
            _context.SaveChanges();

            return cidade;

        }

        public bool Deletar(int id)
        {
            try
            {


                if (id <= 0)
                {
                    return false;
                }
                var entity = _context.cidades.Find(id);
                if (entity == null)
                {
                    return false;
                }
                _context.Remove(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

            }

            return false;
        }
    }
}
