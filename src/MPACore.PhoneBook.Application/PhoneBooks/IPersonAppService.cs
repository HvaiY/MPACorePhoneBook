﻿using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MPACore.PhoneBook.PhoneBooks.Dtos;

namespace MPACore.PhoneBook.PhoneBooks
{
    public interface IPersonAppService : IApplicationService //只有继承这个之后才能生成webapi
    {
        /// <summary>
        /// 获取联系人的相关信息  支持分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<IPagedResult<PersonListDto>> GetPagedPersonAsync(GetPersonInput input);
        /// <summary>
        /// 根据Id获取相关想联系人信息
        /// </summary>
        /// <returns></returns>
        Task<PersonListDto> GetPersonByIdAsync(NullableIdDto input);
        /// <summary>
        /// 新增或者更改联系人信息
        /// </summary>
        /// <returns></returns>
        Task CreateOrUpdatePersonAsync(CreateOrUpdatePersonInput input);
        /// <summary>
        /// 删除联系人信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeletePersonAsync(EntityDto input);
    }
}