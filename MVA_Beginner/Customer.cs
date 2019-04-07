using System.ComponentModel.DataAnnotations;

namespace MVA_Beginner
{
    public class Customer
    {
        [Required]
        public int ID { get; set; }

        [Required, StringLength(maximumLength: 20)]
        public string Name { get; set; }
    }
}