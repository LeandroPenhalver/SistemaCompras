using MediatR;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Infra.Data.UoW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    internal class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
    {
        private readonly ISolicitacaoCompraRepository solicitacaoCompraRepository;
        public RegistrarCompraCommandHandler(
            ISolicitacaoCompraRepository solicitacaoCompraRepository,
            IUnitOfWork uow,
            IMediator mediator) : base(uow, mediator)
        {
            this.solicitacaoCompraRepository = solicitacaoCompraRepository;
        }

        public Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            var solicitacaoCompra = new SolicitacaoAgg.SolicitacaoCompra(request.NomeUsuario, request.NomeFornecedor, request.CondicaoPagamento);
            this.solicitacaoCompraRepository.RegistrarCompra(solicitacaoCompra);

            Commit();
            PublishEvents(solicitacaoCompra.Events);

            return Task.FromResult(true);
        }
    }
}
