using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MPACore.PhoneBook.PhoneBooks.Persons;
using MPACore.PhoneBook.PhoneNumber;

namespace MPACore.PhoneBook.PhoneBooks.Dtos
{
    #region << 版 本 注 释 >>

    /*----------------------------------------------------------------
    // 文件名：PersonEditDto
    // 文件功能描述：
    // 创建者：名字 (Administrator)
    // 时间：2018/6/28 11:34:41
    // 版本：V1.0.0
    //----------------------------------------------------------------*/

    #endregion
    [AutoMapTo(typeof(Person))]
    public class PersonEditDto
    {
        public int? Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 邮箱地址
        /// </summary>
        [EmailAddress]
        [MaxLength(80)] public string EmailAddress { get; set; }

        /// <summary>
        /// 所在地址
        /// </summary>
        [MaxLength(150)]
        public string Address { get; set; }

        public List<PhoneNumberEditDto> PhoneNumbers { get; set; }
    }
}