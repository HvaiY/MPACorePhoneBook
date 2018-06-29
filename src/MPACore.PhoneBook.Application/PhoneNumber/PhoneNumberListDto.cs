using Abp.AutoMapper;
using MPACore.PhoneBook.PhoneBooks.PhoneNumbers;

namespace MPACore.PhoneBook.PhoneNumber
{
    [AutoMapFrom(typeof(PhoneBooks.PhoneNumbers.PhoneNumber))] //用于返回PhoneNumberListDto 因此需要通过entity映射为PhoneNumberListDto
    public class PhoneNumberListDto
    {
        /// <summary>
        /// 电话号码
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 电话类型
        /// </summary>
        public PhoneNumberType PhoneType { get; set; }

    }
}