using System.ComponentModel.DataAnnotations;

namespace Lab10.Models.Validators
{
    public class WeekendAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
          if(value is DateTime date)
            {
                if(date.DayOfWeek == DayOfWeek.Sunday|| date.DayOfWeek == DayOfWeek.Saturday)
                {
                    return false;
                }
                return true;
            }
          return false;
        }
        public WeekendAttribute() {
            ErrorMessage = "Дата не має попадати на вихідні дні";
        }
    }
}
