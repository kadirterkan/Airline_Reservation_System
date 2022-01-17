namespace Control.Enum_Like
{
    public class GenderEnum
    {
        private GenderEnum(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        public static GenderEnum Male
        {
            get { return new GenderEnum("Male"); }
        }

        public static GenderEnum Female
        {
            get { return new GenderEnum("Male"); }
        }
    }
}