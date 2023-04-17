﻿using System;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NerdStore.Enterprise.Core.Data;
using NerdStore.Enterprise.Catalogo.API.Models;

namespace NerdStore.Enterprise.Catalogo.API.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        public ProdutoRepository(CatalogoContext context)
        {
            _context = context;
        }

        private readonly CatalogoContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public async Task<PagedResult<Produto>> ObterTodos(int pageSize, int pageIndex, string query = null)
        {
            //return await _context.Produtos.AsNoTracking().ToListAsync();
            //return await _context.Produtos.AsNoTracking().Skip(pageSize * (pageIndex - 1)).Take(pageSize)
            //    .Where(c => c.Nome.Contains(query)).ToListAsync();
            var sql = @$"SELECT * FROM Produtos
                            WHERE (@Nome IS NULL OR Nome LIKE '%' + @Nome + '%')
                            ORDER BY [Nome]
                            OFFSET {pageSize * (pageIndex - 1)} ROWS
                            FETCH NEXT {pageSize} ROWS ONLY
                            SELECT COUNT(Id) FROM Produtos
                            WHERE (@Nome IS NULL OR Nome LIKE '%' + @Nome + '%')";

            var multi = await _context.Database.GetDbConnection()
                .QueryMultipleAsync(sql, new { Nome = query });

            var produtos = multi.Read<Produto>();
            var total = multi.Read<int>().FirstOrDefault();

            return new PagedResult<Produto>
            {
                List = produtos,
                TotalResults = total,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = query
            };
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<List<Produto>> ObterProdutosPorId(string ids)
        {
            var idsGuid = ids.Split(',').Select(id => (Ok: Guid.TryParse(id, out var x), Value: x));

            if (!idsGuid.All(nid => nid.Ok)) return new List<Produto>();

            var idsValue = idsGuid.Select(id => id.Value);

            return await _context.Produtos.AsNoTracking()
                .Where(p => idsValue.Contains(p.Id) && p.Ativo).ToListAsync();
        }

        public void Adicionar(Produto produto)
        {
            _context.Produtos.Add(produto);
        }

        public void Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}