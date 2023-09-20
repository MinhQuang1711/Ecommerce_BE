namespace Ecommerce_BE.Data.Domains
{
    public class BaseModel
    {
        public string Id { get; set; } 

        public BaseModel() 
        {
                Id= Guid.NewGuid().ToString();
        } 
    }
}
