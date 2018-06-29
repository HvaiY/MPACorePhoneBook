using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.AutoMapper;
using MPACore.PhoneBook.PhoneBooks.PhoneNumbers;

namespace MPACore.PhoneBook.PhoneNumber
{
	#region << 版 本 注 释 >>
    /*----------------------------------------------------------------
    // 文件名：PhoneNumberEditDto
    // 文件功能描述：
    // 创建者：名字 (Administrator)
    // 时间：2018/6/29 9:55:26
    // 版本：V1.0.0
    //----------------------------------------------------------------*/
    #endregion
    [AutoMapTo(typeof(PhoneBooks.PhoneNumbers.PhoneNumber))]//编辑返回需要的是一个entity（PhoneNumber） 因此需要标记映射为PhoneNumber
    public class PhoneNumberEditDto
    {
        /// <summary>
        /// 电话号码
        /// </summary>
        [Required]
        [MaxLength(PhoneBookConsts.MaxPhoneNumberLength)]
        public string Number { get; set; }
        /// <summary>
        /// 电话类型
        /// </summary>
        public PhoneNumberType PhoneType { get; set; }
    }
}
