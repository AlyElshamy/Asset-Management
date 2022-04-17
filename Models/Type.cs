namespace AssetProject.Models
{
    public class Type
    {
        public int TypeId { set; get; }
        public string TypeTitle { set; get; }
        public virtual Brand Brand { get; set; }
        public int BrandId { set; get; }
    }
}
