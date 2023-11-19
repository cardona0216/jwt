using jwt.Models;

namespace jwt.Constants
{
    public class UserContants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            //aqui estamos simulado una base de datos
            new UserModel() {
                Username = "wcardona",
                Password = "adminpro",
                Rol = "administrador",
                EmailAdress = "wal@gmail.com" ,
                FirstName = "walter",
                LastName = "cardona"
            },

              new UserModel() {
                Username = "Scardona",
                Password = "adminpro",
                Rol = "Vendedor",
                EmailAdress = "samuel@gmail.com" ,
                FirstName = "samuel",
                LastName = "cardona p"
            }

        };


    }
}
