using System;
using CashFlow.Domain.Commands;
using FluentValidation;

namespace Equinox.Domain.Commands.Validations
{
    public abstract class TransactionValidation<T> : AbstractValidator<T> where T : TransactionCommand
    {

    }
}