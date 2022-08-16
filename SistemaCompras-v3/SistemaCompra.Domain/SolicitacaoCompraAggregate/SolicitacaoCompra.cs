using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class SolicitacaoCompra : Entity
    {
        public UsuarioSolicitante UsuarioSolicitante { get; private set; }
        public NomeFornecedor NomeFornecedor { get; private set; }
        public IList<Item> Itens { get; private set; }
        public DateTime Data { get; private set; }
        public DateTime CondicaoPagamento { get; private set; }
        public Money TotalGeral { get; private set; }
        public Situacao Situacao { get; private set; }

        private SolicitacaoCompra() 
        {

        }

        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor, DateTime condicaoPagamento)
        {
            Id = Guid.NewGuid();
            UsuarioSolicitante = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedor = new NomeFornecedor(nomeFornecedor);
            Data = DateTime.Now;
            CondicaoPagamento = condicaoPagamento;
            Situacao = Situacao.Solicitado;
        }

        public void AdicionarItem(Produto produto, int qtde)
        {
            var item = new Item(produto, qtde);

            Itens.Add(item);
            TotalGeral.Add(item.Subtotal);
        }

        public void RegistrarCompra(IEnumerable<Item> itens)
        {

        }
    }
}
