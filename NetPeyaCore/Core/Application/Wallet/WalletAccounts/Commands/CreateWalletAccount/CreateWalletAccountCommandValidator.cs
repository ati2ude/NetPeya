using FluentValidation;

namespace Core.Application.Wallet.WalletAccounts.Commands.CreateWalletAccount
{
    public class CreateWalletAccountCommandValidator : AbstractValidator<CreateWalletAccountCommand>
    {
        public CreateWalletAccountCommandValidator()
        {
            RuleFor(x => x.Name).MaximumLength(60);
            RuleFor(x => x.WalletAccountCode).MaximumLength(60);

        }
    }
}
