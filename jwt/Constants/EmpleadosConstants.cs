using jwt.Models;

namespace jwt.Constants
{
    public class EmpleadosConstants
    {
        public static List<EmpleadosModel> Empleados = new List<EmpleadosModel>()
        {
            new EmpleadosModel() {
                FirsName = "walter",
                LastName = "cardona",
                Email = "walter@gmail.com"
            },
             new EmpleadosModel() {
                FirsName = "samuel",
                LastName = "cardona",
                Email = "samuel@gmail.com"
            }
        };
    }
}
