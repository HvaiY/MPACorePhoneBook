using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using MPACore.PhoneBook.PhoneBooks.Persons;
using MPACore.PhoneBook.PhoneNumber;

namespace MPACore.PhoneBook.PhoneBooks.Dtos
{
    #region << 版 本 注 释 >>
    /*----------------------------------------------------------------
    // 文件名：PersonListDto
    // 文件功能描述：
    // 创建者：名字 (Administrator)
    // 时间：2018/6/28 11:34:25
    // 版本：V1.0.0
    //----------------------------------------------------------------*/
    #endregion
    /// <summary>
    /// Person映射的Dto
    /// </summary>
    [AutoMapFrom(typeof(Person))]
    public class PersonListDto : FullAuditedEntityDto //Dto的属性继承
    {
        /// <summary>
        /// 姓名
        /// </summary>

        public string Name { get; set; }
        /// <summary>
        /// 邮箱地址
        /// </summary>

        public string EmailAddress { get; set; }
        /// <summary>
        /// 所在地址
        /// </summary>

        public string Address { get; set; }
        public List<PhoneNumberListDto> PhoneNumbers { get; set; }
    }
}
