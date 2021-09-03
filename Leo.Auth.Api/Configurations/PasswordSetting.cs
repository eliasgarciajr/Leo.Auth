namespace Leo.Auth.Api.Configurations
{
    public class PasswordSetting
    {
        public PasswordSetting()
        {
            MinLength = 15;
            MaxLength = 100;
            UpperLength = 1;
            SpecialLength = 1;
            SpecialChars = "!@#\\$%*()_+^&amp;}{:;?.";
            MaxConsecutiveRepeatedChars = 2; 
            LowerCase = "abcdefghijklmnopqursuvwxyz";
            UperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Numbers = "123456789";
        }

        public int MinLength { get; set; }

        public int MaxLength { get; set; }

        public int UpperLength { get; set; }

        public int SpecialLength { get; set; }

        public string SpecialChars { get; set; }

        public int MaxConsecutiveRepeatedChars { get; set; }

        public string LowerCase { get; set; }

        public string UperCase { get; set; }

        public string Numbers { get; set; }
    }
}