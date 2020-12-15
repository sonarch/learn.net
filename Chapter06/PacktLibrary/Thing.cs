namespace PacktLibrary
{
    public class Thing
    {
        public object Data = default(object);

        public string Process(object input)
        {
            if (Data == input)
            {
                return "same";
            }
            else
            {
                return "not same";
            }
        }
    }
}