Intrucciones:
1. Antes de ejecutar la aplicación hay que habitar el el servicio de Microsoft Message Queue en el Sistema Operativo Windows que esté utilizando.
2. Aplicación desarrollada con Visual Studio Community 2019, para probar los servicios REST se utilizó PostMan.
3. Para cumplir los requisitos del API REST con .NET se basa principalmente sobre InventarioController.cs
4. Se han añadido como 6 datos predeterminados para realizar las pruebas
5. Para cumplir el requisito de añadir un elemento al inventario utilizar el endpoint: https://localhost:44347/api/Inventario/
y en el body un JSON con la siguiente estructura de ejemplo:
{    
    NombreProducto : "Nuevo Producto",
    CodProducto : "CODPROD", 
    DescripcionProducto : "Colonia marca Bonte",
    TypeProducto : "Vidrio",
    Cantidad : 20,
    PrecioProducto : 12.25, 
    FechaCaducidad : '25/10/2025'
}
Con el método POST.
6. Para cumplir el requisito de sacar un elemento del inventario utilizar la URI: https://localhost:44347/api/Inventario/{IdInventario} 
Donde {IdInventario} es el identificador del inventario y con el método DELETE
7. Para obtener todos los registros del inventario utilizar la URI: https://localhost:44347/api/Inventario/AllInventarios. Con el método GET.
Cada vez que se realiza esta consulta llama al método ExpireElement donde revisa si existe un elemento caducado en el inventario y se almacene en el Message Queue Server.
8. Aparte de ello hay una funcionalidad de obtener la lista de elementos caducados y eliminados:  https://localhost:44347/api/inventario/GetItemsExpired.
9. Hay una funcionalidad para actualizar el registro de un inventario https://localhost:44347/api/Inventario/. Con el método PUT.
10. Existe una parte web en https://localhost:44347/InventarioClient, al pinchar en el boton de: GET ALL ITEMS obtiene los elementos disponibles en el inventario. 
Se utilizo algunas etiquetas de HTML con materializecss para decorar algunas recursos HTML.
11. Ingresar a Administracion de Equipos, Servicios de Aplicaciones, Message Queue Server, Colas privadas y revistar si se ha creado el elemento \inventarioqueue



