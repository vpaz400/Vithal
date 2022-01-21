using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Vithal.Framework.Core
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Create Date should be date time type!")]
        [Required]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Modified Date should be date time type!")]
        [Required]
        public DateTime ModifiedDate { get; set; }

        [Required]
        public bool IsActive { get; set; }
        public override string ToString()
        {
            var type = this.GetType();

            if (type.GetCustomAttributesData().Count > 0)
            {
                var t = type.GetCustomAttributesData().FirstOrDefault(f => f.AttributeType.Equals(typeof(System.ComponentModel.DataAnnotations.Schema.TableAttribute)));
                if (t != null && t.ConstructorArguments.Count > 0)
                {
                    return t.ConstructorArguments[0].ToString().Replace("\"", "");
                }
                else
                {
                    return type.Name;
                }
            }

            return string.Empty;
        }

    }
}
