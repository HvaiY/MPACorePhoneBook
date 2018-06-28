using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using MPACore.PhoneBook.PhoneBooks.Dtos;
using MPACore.PhoneBook.PhoneBooks.Persons;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Abp.UI;

namespace MPACore.PhoneBook.PhoneBooks
{
    public class PersonAppService : PhoneBookAppServiceBase, IPersonAppService//该父类继承于ApplicationService 而它实现IApplicationService
    {

        private readonly IRepository<Person> _repository;
        //注入关于Person的仓储
        public PersonAppService(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public async Task<IPagedResult<PersonListDto>> GetPagedPersonAsync(GetPersonInput input)
        {
            var query = _repository.GetAll();
            var personCount = await query.CountAsync();
            var persons = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();
            //自动映射
            var dtos = persons.MapTo<List<PersonListDto>>();
            //封装成IPagedResult<PersonListDto> 返回
            return new PagedResultDto<PersonListDto>(personCount, dtos);
        }

        public async Task DeletePersonAsync(EntityDto input)
        {
            var entity = await _repository.GetAsync(input.Id);
            if (entity == null)
            {
                throw new UserFriendlyException("没有这个人，无法删除了！");
            }

            await _repository.DeleteAsync(input.Id);
        }

        public async Task<PersonListDto> GetPersonByIdAsync(NullableIdDto input)
        {
            if (input.Id.HasValue)
            {
                var entity = await _repository.GetAsync(input.Id.Value);
                return entity.MapTo<PersonListDto>();
            }
            else
            {
                throw new UserFriendlyException("没有这个人，你是不是不记得他的Id了 ");
            }
        }
       
        public async Task<GetPersonForEditOutput> GetPersonForEditAsync(NullableIdDto input)
        {
            var output = new GetPersonForEditOutput();
            PersonEditDto peronEditDto;
            if (input.Id.HasValue)
            {
                var entity = await _repository.GetAsync(input.Id.Value);
                peronEditDto = entity.MapTo<PersonEditDto>();
            }
            else
            {
                peronEditDto = new PersonEditDto();
            }

            output.Person = peronEditDto;
            return output;
        }

        public async Task CreateOrUpdatePersonAsync(CreateOrUpdatePersonInput input)
        {
            if (input.PersonEditDto.Id.HasValue)
            {
                await UpdatePersonAsync(input.PersonEditDto);
            }
            else
            {
                await CreatePersonAsync(input.PersonEditDto);
            }

        }

        protected async Task UpdatePersonAsync(PersonEditDto input)
        {
            var entity = await _repository.GetAsync(input.Id.Value);
            await _repository.UpdateAsync(input.MapTo(entity));
        }

        protected async Task CreatePersonAsync(PersonEditDto input)
        {
            await _repository.InsertAsync(input.MapTo<Person>());
        }
    }
}