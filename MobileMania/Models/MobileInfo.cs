using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MobileMania.Models
{
    public class MobileInfo
    {


        public int ID { get; set; }
        [Display(Name = "Manufacturer")]
        public string BrandName { get; set; }
        [Display(Name = "Mobile Name")]
        public string MobileName { get; set; }
        [Display(Name = "Processor")]
        public string ProcessorName { get; set; }
        [Display(Name = "OS Name")]
        public string AndroidOsName { get; set; }
        [Display(Name = "OS Version")]
        public float AndroidOsVersion { get; set; }
        [Display(Name = "Rear Camera")]
        public string RearCameraPrimary { get; set; }
        [Display(Name = "2nd Rear Camera")]
        public string RearCameraSecondary { get; set; }
        [Display(Name = "3rd Rear Camera")]
        public string RearCameraTertiary { get; set; }
        [Display(Name = "Front Camera")]
        public string FrontCameraPrimary { get; set; }
        [Display(Name = "2nd Front Camera")]
        public string FrontCameraSecondary { get; set; }
        public int RAM { get; set; }

        //storage to be added
        [Display(Name = "Battery Capacity")]
        public int BatterySize { get; set; }
        [Display(Name = "Display Size")]
        public float ScreenSize { get; set; }
        [DisplayFormat(DataFormatString = "{0:Y}")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        public int Price { get; set; }
        [Display(Name = "Screen Resolution")]
        public string ScreenResolution { get; set; }
        public string ImageURL { get; set; }
    }
}