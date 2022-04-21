using System;
using System.Collections.Generic;
using System.Text;

namespace GalleryApp.Models
{
    public class Picture
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string CreationDate { get; set; }

        public Picture(string image, string name, DateTime creationDate)
        {
            Image = image;
            Name = name;
            CreationDate = creationDate.ToString("dd.MM.yyyy hh:mm");
        }
    }
}
