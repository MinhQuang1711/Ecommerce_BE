namespace Ecommerce_BE.Data.Domains
{
    public class BaseModel
    {
        public string id { get; set; } 

        public BaseModel() 
        {
                id= Guid.NewGuid().ToString();
        } 
    }
}
