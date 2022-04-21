using System;
using System.ComponentModel.DataAnnotations;

namespace OurWayApiRest.Model
{
    public class User
    {
        public int cIdUser { get; set; }
        public string cLogin { get; set; }
        public string sUserName { get; set; }
        public string sEmail { get; set; }
        public bool enabled { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]

        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public string dLastUpdate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]

        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public string dCreated { get; set; }
    }
}
