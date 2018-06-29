using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using MPACore.PhoneBook.PhoneBooks.Persons;

namespace MPACore.PhoneBook.PhoneBooks.PhoneNumbers
{
    /// <summary>
    /// 电话号码
    /// </summary>
    /// Entity<long>实体Id(表ID)自动增长也可以是Entity<Guid>,IHasCreationTime创建时间
    public class PhoneNumber : Entity<long>, IHasCreationTime
    {
        /// <summary>
        /// 电话号码
        /// </summary>
        [Required]
        [MaxLength(PhoneBookConsts.MaxPhoneNumberLength)]
        public string Number { get; set; }
        /// <summary>
        /// 电话类型
        /// 一个自定义枚举类型 手机：  Mobile=1, 家庭电话： Home=2, 公司：Company=3
        /// </summary>
        public PhoneNumberType PhoneType { get; set; }

        public  int PersonId { get; set; }
        public   Person Person { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
    }
}