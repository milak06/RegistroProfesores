using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace T1_POOII.Models
{
    public class Profesor
    {

        [Key]
        [Display(Name = "DNI")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El DNI no puede estar vacío")]
        [RegularExpression("^[0-9]{8}$", ErrorMessage = "El DNI debe tener 8 dígitos numéricos")]
        public string DNI { get; set; }

        [Display(Name = "Nombre")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre no puede estar vacío")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El nombre solo puede contener letras")]
        public string Nombre { get; set; }

        [Display(Name = "Apellidos")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Los apellidos no pueden estar vacíos")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Los apellidos solo pueden contener letras")]
        public string Apellidos { get; set; }

        [Display(Name = "Carrera")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "La carrera no puede estar vacía")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "La carrera solo puede contener letras")]
        [MaxLength(20, ErrorMessage = "La carrera no puede tener más de 20 caracteres")]
        public string Carrera { get; set; }

        [Display(Name = "Correo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El correo no puede estar vacío")]
        [EmailAddress(ErrorMessage = "Ingrese un correo válido")]
        public string Correo { get; set; }

        [Display(Name = "Edad")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "La edad no puede estar vacía")]
        [Range(18, 80, ErrorMessage = "La edad debe ser un número entre 18 y 80")]
        public string Edad { get; set; }

        [Display(Name = "Sueldo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El sueldo no puede estar vacío")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El sueldo debe ser mayor a 0")]
        public double Sueldo { get; set; }
    }
}