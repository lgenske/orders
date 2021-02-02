using System.ComponentModel.DataAnnotations;

namespace GFTTestBack.Api.Dtos
{
    public class CreateOrderDto
    {
        [Required(ErrorMessage = "Order cannot be null")]
        public string RawOrder { get; set; }
    }
}
