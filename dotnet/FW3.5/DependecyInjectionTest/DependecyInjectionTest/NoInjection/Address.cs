namespace DependencyInjectionTest.NoInjection
{
    public class Address
    {
        private string _placeType;
        private string _place;
        private int _number;

        public string PlaceType
        {
            get { return _placeType; }
            set { _placeType = value; }
        }
         
        public string Place
        {
            get { return _place; }
            set { _place = value; }
        }
         
        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }
    }
}
