# LILAB-MARKET

Pequeño proyecto de minimarket.
> Requerimientos

- El catálogo de productos (frutas y verduras) permite la navegación por categoría del producto
- Cada vez que se realiza una compra el stock se actualiza automáticamente y la tienda no permite comprar productos que están sin stock
- El proceso de compra debe ser simulado (no hay integración con ninguna pasarela de pago)
- La presentación de los productos debe incluir una imagen, el precio, una descripción y la cantidad disponible en tienda.
- No es relevante generar el proceso de registro y autenticación en la tienda para esta solución.

## Base Datos (PostgreSQL)
Verificar el archivo BD.txt , el cual se debe crear la base de datos y ejecutar los script.

## Servicio Web Api (.Net Core)
El servicio Web api se debe ejecutara en el kestrel el cual su ruta por defecto es http://localhost:5000 para poder visualizar el catalogo.

##  Web (.Net Core MVC)
Este modulo se ejecutara con normalidad, no hay nada que modificar para su uso.

