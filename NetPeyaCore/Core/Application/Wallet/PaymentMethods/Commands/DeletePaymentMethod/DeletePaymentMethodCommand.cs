using Core.Domain.Wallet.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.PaymentMethods.Commands.DeletePaymentMethod
{
    public class DeletePaymentMethodCommand : IRequest<PaymentMethod>
    {
        int _Id;

        public int ID
        {
            get { return _Id; }
            set { _Id = Int32.Parse(value.ToString()); }
        }
    }
}
