using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Fornecedores.Models.Entities;
using Domain.Fornecedores.Models.Request;
using Domain.Fornecedores.Models.Response;


namespace Domain.Fornecedores.Interface.Repository
{
    public interface IUserRepository
    {
        Task<ListResponse<UserName>> GetListUserName(FilterUserRequest request);

        Task<BaseResponse> Create(CreateUserNameRequest request);

        Task<BaseResponse> SaveEditUser(CreateUserNameRequest request);
    }
}
