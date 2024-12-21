using AutoMapper;
using E_Association.Core.Features.Consumer.Query.Models;
using E_Association.Core.Features.Consumer.Query.Request;
using E_Association.Service.IAssociationServices.Userservice;
using MediatR;

namespace E_Association.Core.Features.Consumer.Query.Handler
{
    public class UserQueryHandler :
        IRequestHandler<GetAllUserQuery, List<UserModel>>,
        IRequestHandler<PaginateUserQuery, List<UserModel>>,
        IRequestHandler<GetUserByUserNameQuery, UserModel>
    {
        public UserQueryHandler(IConsumerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        private IConsumerService _service;
        private IMapper _mapper;
        public async Task<List<UserModel>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var _users = await _service.GetAllUserAsync();
            var userMapperd = _mapper.Map<List<UserModel>>(_users);
            return userMapperd;
        }

        public async Task<List<UserModel>> Handle(PaginateUserQuery request, CancellationToken cancellationToken)
        {
            var _users = await _service.Paginationsync(request.UserPerPage, request.pageNumber);
            var userMapperd = _mapper.Map<List<UserModel>>(_users);
            return userMapperd;
        }

        public async Task<UserModel> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
        {
            var _users = await _service.GetOneAsync(request.userName);
            var userMapperd = _mapper.Map<UserModel>(_users);
            return userMapperd;
        }
    }
}
