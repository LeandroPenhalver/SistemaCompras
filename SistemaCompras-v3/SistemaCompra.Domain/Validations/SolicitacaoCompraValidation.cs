using FluentValidation;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Domain.Validations.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Domain.Validations
{
    public class SolicitacaoCompraValidation : AbstractValidator<SolicitacaoCompra>
    {
        public SolicitacaoCompraValidation()
        {
            RuleFor(item => item.Itens)
                .Null()
                .WithMessage(ValidationMessages.ItemsEmpty);

            RuleFor(x => x)
                .Must(x => (x.CondicaoPagamento - x.Data).Days == 30)
                .When(x => x.TotalGeral.Value > 50000)
                .WithMessage(ValidationMessages.PaymentCondition);
        }
    }
}
