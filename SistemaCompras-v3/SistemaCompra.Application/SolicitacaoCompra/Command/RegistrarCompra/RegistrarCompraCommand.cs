using MediatR;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommand : IRequest<bool>
    {
        public string NomeUsuario { get; set; }
        public string NomeFornecedor { get; set; }
        public IList<Item> Itens { get; set; }
        public DateTime CondicaoPagamento { get; set; }
    }
}
