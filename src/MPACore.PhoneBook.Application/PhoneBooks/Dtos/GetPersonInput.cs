using System;
using System.Collections.Generic;
using System.Text;
using Abp;
using Abp.Runtime.Validation;
using MPACore.PhoneBook.Dto;

namespace MPACore.PhoneBook.PhoneBooks.Dtos
{
    #region << 版 本 注 释 >>
    /*----------------------------------------------------------------
    // 文件名：GetPersonInput
    // 文件功能描述：
    // 创建者：名字 (Administrator)
    // 时间：2018/6/28 11:15:37
    // 版本：V1.0.0
    //----------------------------------------------------------------*/
    #endregion
    public class GetPersonInput : PagedAndSortedInputDto, IShouldNormalize //分页和（这种方法在方法执行之前被调用（如果存在验证的话））
    {
        public string FilterText { get; set; }
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id"; //按照Id来排序 (Id 来自Entity<long/Guid/..>)
            }
        }
    }
}
