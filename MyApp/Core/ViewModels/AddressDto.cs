namespace MyApp.Core.ViewModels
{
    public class AddressDto
    {

        public string Address { get; set; }
        

        public override string ToString()
        {
            return $"Set addresses successfully: {this.Address}";
        }
    }
}