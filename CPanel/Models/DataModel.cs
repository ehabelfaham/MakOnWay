using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CPanel.Models
{
    public class EmailCategoryModel
    {
        [Required]
        [Display(Name = "Category Code")]
        public int Category_id { get; set; }
    }

    public class CategoryModel
    {
        [Required]
        [Display(Name = "Category Code")]
        public int Category_id { get; set; }

        [Required]
        [Display(Name = "Category English Name")]
        public string Category_Name_Eng { get; set; }

        [Required]
        [Display(Name = "Category Arabic Name")]
        public string Category_Name_Ar { get; set; }


        [Display(Name = "Category English Note")]
        public string Category_Note_Eng { get; set; }


        [Display(Name = "Category Arabic Note")]
        public string Category_Note_Ar { get; set; }


        [Display(Name = "Parent Category")]
        public string Category_Parent_id { get; set; }

        [Display(Name = "Select Image")]
        public HttpPostedFileBase Image_Path { get; set; }

        public string Image_PathStr { get; set; }

    }
    public class WebSiteDataModel
    {
        [Required]
        [Display(Name = "WebSite Code")]
        public int id { get; set; }

        [Required]
        [Display(Name = "WebSite")]
        public string WebSite_Src { get; set; }

        [Display(Name = "Select Image")]
        public HttpPostedFileBase Image_Path { get; set; }

        public string Image_PathStr { get; set; }

    }
    public class CertificateDataModel
    {
        [Required]
        [Display(Name = "Certificate Code")]
        public int id { get; set; }

        [Required]
        [Display(Name = "Certificate")]
        public string Certificate_Src { get; set; }
        
        [Display(Name = "Select Image")]
        public HttpPostedFileBase Image_Path { get; set; }

        public string Image_PathStr { get; set; }

    }
    public class LinkDataModel
    {
        [Required]
        [Display(Name = "Link Code")]
        public int id { get; set; }

        [Required]
        [Display(Name = "Link")]
        public string Link_Src { get; set; }
        
        [Display(Name = "Select Image")]
        public HttpPostedFileBase Image_Path { get; set; }

        public string Image_PathStr { get; set; }

    }
    public class BrandsModel
    {
        [Required]
        [Display(Name = "Brand Code")]
        public int Brand_id { get; set; }

        [Required]
        [Display(Name = "Brand English Name")]
        public string Brand_Name_Eng { get; set; }

        [Required]
        [Display(Name = "Brand Arabic Name")]
        public string Brand_Name_Ar { get; set; }


        [Display(Name = "Brand English Note")]
        public string Brand_Note_Eng { get; set; }


        [Display(Name = "Brand Arabic Note")]
        public string Brand_Note_Ar { get; set; }


        [Display(Name = "Select Image")]
        public HttpPostedFileBase Image_Path { get; set; }

        public string Image_PathStr { get; set; }

    }
    public class CompanyProfileModel
    {

        [Required]
        [Display(Name = "Company Profile English Name")]
        public string Company_Profile_Eng { get; set; }

        [Required]
        [Display(Name = "Company Profile Arabic Name")]
        public string Company_Profile_Ar { get; set; }
    }
    public class CompanyAboutUsModel
    {
        [Required]
        [Display(Name = "Company Home Aboutus English Name")]
        public string HomeTxt_Eng { get; set; }

        [Required]
        [Display(Name = "Company Home Aboutus Arabic Name")]
        public string HomeTxt_Ar { get; set; }

        [Required]
        [Display(Name = "Company AboutUs English Name")]
        public string AboutUs_txt_Eng { get; set; }

        [Required]
        [Display(Name = "Company AboutUs Arabic Name")]
        public string AboutUs_txt_Ar { get; set; }

        [Display(Name = "Select Image")]
        public HttpPostedFileBase Image_Path { get; set; }

        public string Image_PathStr { get; set; }
    }
    public class CompanyContactUsModel
    {

        [Required]
        [Display(Name = "Company ContactUs English Name")]
        public string ContactUs_Eng { get; set; }

        [Required]
        [Display(Name = "Company ContactUs Arabic Name")]
        public string ContactUs_Ar { get; set; }
    }
    public class DepartmentsModel
    {
        [Required]
        [Display(Name = "Department Code")]
        public int Department_id { get; set; }

        [Required]
        [Display(Name = "Department English Name")]
        public string Department_Name_Eng { get; set; }

        [Required]
        [Display(Name = "Department Arabic Name")]
        public string Department_Name_Ar { get; set; }


        [Display(Name = "Department English Note")]
        public string Department_Note_Eng { get; set; }


        [Display(Name = "Department Arabic Note")]
        public string Department_Note_Ar { get; set; }


        [Display(Name = "Parent Department")]
        public string Department_Parent_id { get; set; }


        [Display(Name = "Select Image")]
        public HttpPostedFileBase Image_Path { get; set; }


        public string Image_PathStr { get; set; }
    }
    public class EventModel
    {
        [Required]
        [Display(Name = "Event Code")]
        public int Event_id { get; set; }

        [Required]
        [Display(Name = "Event English Name")]
        public string Event_Title_Eng { get; set; }

        [Required]
        [Display(Name = "Event Arabic Name")]
        public string Event_Title_Ar { get; set; }


        [Display(Name = "Event English Description")]
        public string Event_Desc_Eng { get; set; }


        [Display(Name = "Event Arabic Description")]
        public string Event_Desc_Ar { get; set; }


        [Display(Name = "Select Image")]
        public HttpPostedFileBase Image_Path { get; set; }


        [Required]
        [Display(Name = "Event From")]
        public DateTime Event_From_Datetime { get; set; }


        [Required]
        [Display(Name = "Event To")]
        public DateTime Event_To_Datetime { get; set; }


        public bool Event_IsActive { get; set; }
    }

    public class MarcomSettingModel
    {
        [Required]
        [Display(Name = "News Code")]
        public int Id { get; set; }

        [Display(Name = "Select Logo Image")]
        public HttpPostedFileBase LogoPath { get; set; }

        public string LogoPathStr { get; set; }


        [Display(Name = "Select Background Image")]
        public HttpPostedFileBase BackgroundPath_Eng { get; set; }

        public string BackgroundPath_EngStr { get; set; }


        [Display(Name = "Select Most Visited")]
        public HttpPostedFileBase BackgroundPath_Ar { get; set; }

        public string BackgroundPath_ArStr { get; set; }


        [Display(Name = "Select Arabic Most Visited")]
        public HttpPostedFileBase DivBackGround_Ar { get; set; }

        public string DivBackGround_ArStr { get; set; }

        [Display(Name = "Select English Promotion")]
        public HttpPostedFileBase DivPormBG_Eng { get; set; }
        public string DivPormBG_EngStr { get; set; }


        [Display(Name = "Select Arabic Promotion")]
        public HttpPostedFileBase DivPormBG_Ar { get; set; }
        public string DivPormBG_ArStr { get; set; }


        [Display(Name = "Show Promotion")]
        public bool IsShowPrm { get; set; }


    }
    public class NewsModel
    {
        [Required]
        [Display(Name = "News Code")]
        public int News_id { get; set; }

        [Required]
        [Display(Name = "News English Name")]
        public string News_Title_Eng { get; set; }

        [Required]
        [Display(Name = "News Arabic Name")]
        public string News_Title_Ar { get; set; }


        [Display(Name = "News English Description")]
        public string News_Desc_Eng { get; set; }


        [Display(Name = "News Arabic Description")]
        public string News_Desc_Ar { get; set; }


        [Display(Name = "Select Image")]
        public HttpPostedFileBase Image_Path { get; set; }


        [Required]
        [Display(Name = "Newss DateTime")]
        public DateTime News_Datetime { get; set; }


        public string Image_PathStr { get; set; }

    }


    public class ServiceModel
    {
        [Required]
        [Display(Name = "Service Code")]
        public int Service_id { get; set; }

        [Required]
        [Display(Name = "Service English Name")]
        public string Service_Title_Eng { get; set; }

        [Required]
        [Display(Name = "Service Arabic Name")]
        public string Service_Title_Ar { get; set; }


        [Display(Name = "Service English Description")]
        public string Service_Desc_Eng { get; set; }


        [Display(Name = "Service Arabic Description")]
        public string Service_Desc_Ar { get; set; }


        [Display(Name = "Select Image")]
        public HttpPostedFileBase Image_Path { get; set; }


        [Required]
        [Display(Name = "Service DateTime")]
        public DateTime Service_Datetime { get; set; }


        public string Image_PathStr { get; set; }

    }
}