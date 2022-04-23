namespace AssetProject.Models
{
    public class SubCategory
    {
        public int SubCategoryId { set; get; }

        public string SubCategoryTitle { set; get; }
        public string SubCategoryDescription { set; get; }

        public virtual Category Category { set; get; }

        public int CategoryId { set; get; }

    }
}
