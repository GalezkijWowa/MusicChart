using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityModel.Models
{
    public class Image
    {
        public Image()
        {

        }
        public Image(Uri source)
        {
            if(source != null)
            {
                Source = "https://" + source.DnsSafeHost + source.AbsolutePath;
            }
            else
            {
                Source = "https://blog.sqlauthority.com/i/a/errorstop.png";
            }
        }
        [Key]
        public string ImageId { get; set; }
        public string Source { get; set; }

        public override string ToString()
        {
            return Source;
        }
        
    }
}
