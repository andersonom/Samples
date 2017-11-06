
namespace DependencyInjectionTest.WithInjection
{
    public class Company : IAddressObjectDI
    {
        private IAddressObject _address;

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

        /*Applying Dependency Injection in 4 ways*/

        //1-Contructor
        public Company(IAddressObject obj) { _address = obj; }

        //2-Getter and Setter         
        public IAddressObject Address { get { return _address; } set { _address = value; } }

        //3-Interface Implementation
        public void setAddress(IAddressObject obj) { _address = obj; }

        //4-Service Locator
        public Company() { this._address = ServiceLocator.getAddress(); }//Static Class Service Locator is used to search for objects

    }


}
