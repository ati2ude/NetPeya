using Core.Domain.Wallet.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.CardTypes.Models
{
    public class BaseCardTypeCommand : IRequest<CardType>
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
