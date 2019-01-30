/* 
 * Copyright (c) 2019, Rachid (thisdoesnt@exist.com) and contributors
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/ewoutkramer/fhir-net-api/master/LICENSE
 */

using RAC.Vuur.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RAC.Vuur.Validation
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class CodePatternAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;

            if (value.GetType() != typeof(string))
                throw new ArgumentException("CodePatternAttribute can only be applied to string properties");

            if (Code.IsValidValue(value as string))
                return ValidationResult.Success;
            else
				return DotNetAttributeValidation.BuildResult(validationContext, "{0} is not a correctly formatted Code", value as string);
        }
    }
}