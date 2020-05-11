using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RestFulMoviesAPI.Validations;

namespace RestFulMoviesAPI.Entities
{
    public class Genre : IValidatableObject
    {
        public Genre()
        {
        }
        /*
         * Model Validation
         * Attributes for Validations
         * Required, StringLength, Range, CreditCard, Compare, Phone, RegularExpression, Url, BindRequired
         *
         * Add the attribute above each item in the model class
         */


        public int Id { get; set; }
        [Required(ErrorMessage ="The field with name {0} is required")]
        [StringLength(10)]
        //[FirstLetterUpperCase] //Attribute validations, mostly preferrable as the validation can be used across the project/all models.
        public string Name { get; set; }

        /*
        [Range(18,100)]
        public int Age { get; set; }
        [Url]
        public string Url { get; set; }
        [CreditCard]
        public string CreditCard { get; set; }
        */
        /*
         * model validations : will be executed at runtime only after AttributeValidations
         *
         * Example: [StringLength(10)] will be validated first and then the below function is called.
         *
         * using this method, we cna make severl validations for this model only.
         */
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                var firstLetter = Name[0].ToString();
                if (firstLetter != firstLetter.ToUpper())
                {
                    yield return new ValidationResult("First letter should be Uppercase", new string[] { nameof(Name) });
                }
            }            
        }
    }
}
