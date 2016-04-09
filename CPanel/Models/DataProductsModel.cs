using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CPanel.Models
{
    public class ProductsModel
    {
        [Required]
        [Display(Name = "Product Code")]
        public int Product_id { get; set; }

        [Required]
        [Display(Name = "Product English Model *")]
        public string Product_Title_Eng { get; set; }

        [Required]
        [Display(Name = "Product Arabic Model *")]
        public string Product_Title_Ar { get; set; }

        [Required]
        [Display(Name = "Image Arabic Alt  *")]
        public string Image_Alt_Ar { get; set; }

        
        [Required]
        [Display(Name = "Image Alt *")]
        public string Image_Alt { get; set; }

        
        [Required]
        [Display(Name = "Product English Short Description *")]
        public string Product_Short_Eng { get; set; }

        [Required]
        [Display(Name = "Product Arabic Short Description *")]
        public string Product_Short_Ar { get; set; }

        [Required]
        [Display(Name = "Product English Highlight *")]
        public string Product_Highlight_Eng { get; set; }

        [Required]
        [Display(Name = "Product Arabic Highlight *")]
        public string Product_Highlight_Ar { get; set; }


        [Display(Name = "Product English Specification ")]
        public string Product_Spec_Eng { get; set; }


        [Display(Name = "Product Arabic Specification")]
        public string Product_Spec_Ar { get; set; }


        [Display(Name = "Product English Feature ")]
        public string Product_Ftr_Eng { get; set; }


        [Display(Name = "Meta Tag For Title ")]
        public string Meta_Title { get; set; }
        [Display(Name = "Arabic Meta Tag For Title ")]
        public string Meta_Title_Ar { get; set; }
        [Display(Name = "keywords and meta description")]
        public string Meta_SocialTags { get; set; }


        [Display(Name = "Product Arabic Feature ")]
        public string Product_Ftr_Ar { get; set; }


        [Display(Name = "Select Image *")]
        public HttpPostedFileBase Image_Path { get; set; }

        
        [Required]
        [Display(Name = "Brand *")]
        public int Brand_id { get; set; }


        [Required]
        [Display(Name = "Category *")]
        public int Category_id { get; set; }


        [Required]
        [Display(Name = "Department *")]
        public int Department_id { get; set; }


        [Display(Name = "English Meta Tag For Description ")]
        public string Meta_Description_En { get; set; }
        [Display(Name = "Arabic Meta Tag For Description ")]
        public string Meta_Description_Ar { get; set; }

        [Display(Name = "English Meta Tag For Key Words ")]
        public string Meta_KeyWords_En { get; set; }
        [Display(Name = "Arabic Meta Tag For Key Words ")]
        public string Meta_KeyWords_Ar { get; set; }

        [Display(Name = "Add to most visited list ")]
        public bool IsMostVisted { get; set; }


        [Display(Name = "Parent")]
        public int? ParentId { get; set; }

        public string Image_PathStr { get; set; }

    }


    public class ComponentsModel
    {
        [Required]
        [Display(Name = "Product Code")]
        public int Product_id { get; set; }

        [Required]
        [Display(Name = "Product English Model *")]
        public string Product_Title_Eng { get; set; }

        [Required]
        [Display(Name = "Product Arabic Model *")]
        public string Product_Title_Ar { get; set; }

        [Required]
        [Display(Name = "Product English Highlight *")]
        public string Product_Highlight_Eng { get; set; }

        [Required]
        [Display(Name = "Product Arabic Highlight *")]
        public string Product_Highlight_Ar { get; set; }


        [Display(Name = "Select Image *")]
        public HttpPostedFileBase Image_Path { get; set; }


        [Display(Name = "Products Amount *")]
        public long Product_Amount { get; set; }
        
    }


    public class MImageDataContext
    {
        public int id { get; set; }
        public HttpPostedFileBase source1 { get; set; }
        public HttpPostedFileBase source2 { get; set; }
        public HttpPostedFileBase source3 { get; set; }
        public HttpPostedFileBase source4 { get; set; }
        public HttpPostedFileBase source5 { get; set; }
        public int Product_id { get; set; }
    }

    public class WeeklyOfferModel
    {
        [Required]
        [Display(Name = "Product Code")]
        public int id { get; set; }

        [Required]
        [Display(Name = "Product English Model *")]
        public string Product_Title_Eng { get; set; }

        [Required]
        [Display(Name = "Product Arabic Model *")]
        public string Product_Title_Ar { get; set; }

        [Required]
        [Display(Name = "Product English Highlight *")]
        public string Product_Highlight_Eng { get; set; }

        [Required]
        [Display(Name = "Product Arabic Highlight *")]
        public string Product_Highlight_Ar { get; set; }


        [Display(Name = "Select Image *")]
        public HttpPostedFileBase Image_Path { get; set; }

        [Required]
        [Display(Name = "Products Date *")]
        public DateTime Product_Date { get; set; }

        [Required]
        [Display(Name = "Product *")]
        public int Product_id { get; set; }

        public string Image_PathStr { get; set; }
    }

}