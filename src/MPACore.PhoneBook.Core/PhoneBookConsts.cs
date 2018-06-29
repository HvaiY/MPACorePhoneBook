namespace MPACore.PhoneBook
{
    public class PhoneBookConsts
    {
        public const string LocalizationSourceName = "PhoneBook";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = false;//设置为true表示启用多租户
        public const int MaxNameLength = 50;
        public const int MaxEmailLegth = 80;
        public const int MaxAddressLength = 200;
        public const int MaxPhoneNumberLength = 11;
    }
}
