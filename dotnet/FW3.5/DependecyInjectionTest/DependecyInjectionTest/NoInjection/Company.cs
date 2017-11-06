namespace DependencyInjectionTest.NoInjection
{
    /// <summary>
    /// Class with high coupling, high dependence and highly cohesive.
    /// </summary>
    public class Company
    {
        public Company(Address pAddress)
        {
            _address = pAddress; 
        }

        private int _cod;
        public int Cod
        {
            get { return _cod; }
            set { _cod = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private Address _address;

        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }
    }


}
