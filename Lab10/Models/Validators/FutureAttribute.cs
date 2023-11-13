using System.ComponentModel.DataAnnotations;

namespace Lab10.Models.Validators
{
    public class FutureAttribute :ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if(value is DateTime date)
            {
                return date>DateTime.Now;
            }
            return false;
        }
    }
}
