using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MVC5Course.Models.Validations
{
    public class TawianCSN : ValidationAttribute
    {
        public TawianCSN()
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var sn = value.ToString();
            Regex snReg = new Regex("^\\d{8}$");
            bool rs = false;

            if (snReg.IsMatch(sn))
            {
                int[] muti = new int[] { 1, 2, 1, 2, 1, 2, 4, 1 };
                decimal checkSum = 0;

                for (int i = 0; i < sn.Length; i++)
                {
                    checkSum += Math.Floor((decimal)(int.Parse(sn.Substring(i, 1)) * muti[i]) / 10) + int.Parse(sn.Substring(i, 1)) * muti[i] % 10;
                }

                if (checkSum % 10 == 0 || (checkSum % 10 == 9 && sn.Substring(6, 1) == "7"))
                {
                    rs = true;
                }
            }

            if (!rs)
            {
                return new ValidationResult("統編格式有誤！");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}