namespace Control.Enum_Like
{
    public class AgeEnum
    {
        private AgeEnum(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        public static AgeEnum Adult
        {
            get { return new AgeEnum("Adult (+18)"); }
        }

        public static AgeEnum Children
        {
            get { return new AgeEnum("Children (0-17)"); }
        }
    }
}