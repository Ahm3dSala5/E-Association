using Application.Requests.User.Commands.Queries;
using AutoMapper;
using Domain.DTOs.Users;
using E_Association.Service.IAssociationServices.Userservice;
using E_Association.Service.UnitOfWorks;
using MediatR;
namespace E_Association.Core.Application.Requests.User.Commands.Handler
{

    public class UserCommandHandler : 
        IRequestHandler<ChangeUserPasswordCommand, string>,
        IRequestHandler<ConfirmUserCommand,object>,
        IRequestHandler<DeleteUserCommand,string>,
        IRequestHandler<ForgetUserPasswordCommand,object>,
        IRequestHandler<LoginUserCommand,object>,
        IRequestHandler<RegisterUserCommand,object>,
        IRequestHandler<GenerateVerificationCodeUserCommand,string>
        
    {
        private readonly IAuthenticationService _service;
        private readonly IMapper _mapper;
        public UserCommandHandler(IAuthenticationService user,IMapper mapper)
        {
            _mapper = mapper;
            _service = user;
        }
        public async Task<object> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var registerDTO = _mapper.Map<RegistrationDTO>(request);
            return await _service.RegistrantionAsync(registerDTO);
        }

        public async Task<object> Handle(ConfirmUserCommand request, CancellationToken cancellationToken)
        {
            var confirmDTO = _mapper.Map<ConfirmEmailDTO>(request);
            return await _service.ConfirmUserAccountAsync(confirmDTO);
        }

        public async Task<string> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var changePasswordDTO = _mapper.Map<ChangePasswordDTO>(request);
            return await _service.ChangePasswordAsync(changePasswordDTO);
        }

        public async Task<string> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await _service.DeleteUserAsync(request.UserName);
        }

        public async Task<object> Handle(ForgetUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var forgetPasswordDTO = _mapper.Map<ForgetPasswordDTO>(request);
            return await _service.ForgetPassword(forgetPasswordDTO);
        }

        public async Task<object> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var loginDTO = _mapper.Map<LoginDtO>(request);
            return await _service.LoginAsync(loginDTO);
        }

        public async Task<string> Handle(GenerateVerificationCodeUserCommand request, CancellationToken cancellationToken)
        {
            return await _service.GeneratePasswordResetCode(request.Email);
        }
    }
}
