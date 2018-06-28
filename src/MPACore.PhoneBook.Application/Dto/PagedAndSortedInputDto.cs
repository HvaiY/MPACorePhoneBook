using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Application.Services.Dto;

namespace MPACore.PhoneBook.Dto
{
    #region << 版 本 注 释 >>
    /*----------------------------------------------------------------
    // 文件名：PagedAndSortedInputDto
    // 文件功能描述：
    // 创建者：名字 (Administrator)
    // 时间：2018/6/28 11:22:53
    // 版本：V1.0.0
    //----------------------------------------------------------------*/
    #endregion
    /// <summary>
    /// 用于分页和排序
    /// </summary>
    public class PagedAndSortedInputDto : IPagedAndSortedResultRequest, ISortedResultRequest
    {
        public string Sorting { get; set; }
        [Range(0,int.MaxValue)]
        public int SkipCount { get; set; }
        //页显示最大和最小条数
        [Range(1,500)]
        public int MaxResultCount { get; set; }
    }
}
