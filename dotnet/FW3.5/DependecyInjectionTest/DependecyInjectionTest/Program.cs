
namespace DependencyInjectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //There are 4 Methodologies for Dependency Injection

            //1-Contrutor -This methodology is not recommended for systems where classes can only define empty constructors,
            // that is, where class constructors can not receive parameters.
            var company= new WithInjection.Company(new WithInjection.Address());//No need to change company class

            //2-Getter and Setter    
            company.Address = new WithInjection.Address();

            //3-Interface Implementation
            company.setAddress(new WithInjection.Address());

            //4-Service Locator
            //Logic is inside the class, please check

            //Without Injection there is an Address class within the Company class glued
            var companyNoInjection = new NoInjection.Company(new NoInjection.Address());

        }
    }
}
