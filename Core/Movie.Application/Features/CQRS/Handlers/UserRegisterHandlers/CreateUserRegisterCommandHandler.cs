using Microsoft.AspNetCore.Identity;
using Movie.Application.Features.CQRS.Commands.UserRegisterCommands;
using Movie.Domain.Entities;

namespace Movie.Application.Features.CQRS.Handlers.UserRegisterHandlers
{
    public class CreateUserRegisterCommandHandler
    {
        private readonly UserManager<AppUser> _userManager;
                
        public CreateUserRegisterCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task Handle(CreateUserRegisterCommand command)
        {
            var user = new AppUser
            {
                UserName = command.Username,
                Email = command.Email,
                Name = command.Name,
                Surname = command.Surname
            };

            var result = await _userManager.CreateAsync(user, command.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Kullanıcı oluşturulamadı: {errors}");
            }
        }
    }
}