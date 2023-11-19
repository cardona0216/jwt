using jwt.Models;

namespace jwt.Constants
{
    public class ProductosConstants
    {
        public static List<ProductoModel> Productos = new List<ProductoModel>()
        {
            new ProductoModel(){
                    Name = "Coca cola",
                    Descripcion = "Producto con gas"
                },
            new ProductoModel(){
                Name = "Agua",
                Descripcion = "Agua mineral de dos litros"
            }
        };
    }
}
