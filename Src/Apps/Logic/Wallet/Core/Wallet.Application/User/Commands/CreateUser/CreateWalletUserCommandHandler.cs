using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WalletApplication.Interfaces;
using WalletDomain.Entities;

namespace WalletApplication.User.Commands.CreateUser
{
    class CreateWalletUserCommandHandler : IRequestHandler<CreateWalletUserCommand, Unit>
    {
        //private readonly NorthwindDbContext _context;
        private readonly INotificationService _notificationService;

        public CreateWalletUserCommandHandler(
            //NorthwindDbContext context,
            INotificationService notificationService)
        {
            //_context = context;
            _notificationService = notificationService;
        }

        public async Task<Unit> Handle(CreateWalletUserCommand request, CancellationToken cancellationToken)
        {
            var entity = new WalletUser
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                Password = request.Password,
                Country = request.Country,
                DefaultCurrency = request.DefaultCurrency
            };

            //_context.Customers.Add(entity);

            //await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
