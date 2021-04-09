// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const ajaxJson = async (url) => await (await fetch(url)).json();

Productos(0);




function pruebaTexto() {
    console.log("ingresio e");

}
function contadormas(index) {
    console.log(index);
    document.getElementById(`${index}`).value++;

}

function contadormenos(index) {
    document.getElementById(`${index}`).value--;
}
document.getElementById('selectCategorias').addEventListener('change', () => {
    var text = selectCategorias.options[selectCategorias.selectedIndex].value;
    Productos(text)
});


let Categoria = 0;

function Productos(categoriaId) {
  //  Categoria =parseInt( categoriaId);
    //let urlRFID = `http://localhost:5000/api/producto`;
    //let urlRFID = `http://localhost:5000/api/producto/Categoria/${categoriaId}`;

    let url = categoriaId == 0 ? `http://localhost:5000/api/producto` : `http://localhost:5000/api/producto/Categoria/${categoriaId}`;
    ajaxJson(url)
        .then(data => {
            listaProductos.innerHTML = '';
            console.log(data);
            data.data.forEach(element => {
                if (element.stock <= 0) {
                    return;
                } else {
                    listaProductos.innerHTML += `
                        <div class="col-md-4">
                        <div class="card mb-4 shadow-sm">
                            <img src="${element.imagen}" class="img-thumbnail" alt="...">
                            <div class="card-body">
                                <p class="card-text">${element.descripcion}</p>
                                <div class="d-flex justify-content-between align-items-center">
                                    <small class="text-muted">Stock <strong>${element.stock}</strong></small>
                                    <small class="text-muted"> Precio <strong class="text-precio">${element.precio}</strong></small>
                                </div>
                                <hr />
                                 <div class="d-flex justify-content-between align-items-center">
                                <small class="text-muted">Total</small>
                                <input id="${element.productoId}" class="stock" value="25" min="0" max="1" />
                                <div class="btn-group">
                                    <button onclick="contadormenos(${element.productoId});" type="button" class="btn btn-sm btn-outline-secondary">-</button>
                                    <button onclick="contadormas(${element.productoId});" type="button" class="btn btn-sm btn-outline-secondary">+</button>
                                </div>
                            </div>
                                <br />
                                <button id="${element.productoId}" onclick="AgregarCarrito(${element.productoId});" type="button" class="btn btn-primary btn-sm btn-block">Agregar</button>

                            </div>
                        </div>
                    </div>    `;
                }
                });


        }).catch((err) => {
            console.log('Error', err);
        });
}

function ProductosByCategoriaId(categoriaId) {
    console.log(categoriaId);

    let urlRFID = `http://localhost:5000/api/producto/Categoria/${categoriaId}`;
    ajaxJson(urlRFID)
        .then(data => {

            listaProductos.innerHTML = '';
            data.data.forEach(element => {
                console.log(element);
                listaProductos.innerHTML += `
                        <div class="col-md-4">
                        <div class="card mb-4 shadow-sm">
                            <img src="${element.imagen}" class="img-thumbnail" alt="...">
                            <div class="card-body">
                                <p class="card-text">${element.descripcion}</p>
                                <div class="d-flex justify-content-between align-items-center">
                                    <small class="text-muted">Stock <strong>${element.stock}</strong></small>
                                    <small class="text-muted"> Precio <strong class="text-precio">${element.precio}</strong></small>
                                </div>
                                <hr />
                                 <div class="d-flex justify-content-between align-items-center">
                                <small class="text-muted">Total</small>
                                <input id="${element.productoId}" class="stock" value="25" min="0" max="1" />
                                <div class="btn-group">
                                    <button onclick="contadormenos(${element.productoId});" type="button" class="btn btn-sm btn-outline-secondary">-</button>
                                    <button onclick="contadormas(${element.productoId});" type="button" class="btn btn-sm btn-outline-secondary">+</button>
                                </div>
                            </div>
                                <br />
                                <button onclick="AgregarCarrito(${element.productoId});" type="button" class="btn btn-primary btn-sm btn-block">Agregar</button>

                            </div>
                        </div>
                    </div>

                  `;
            });

        }).catch((err) => {
            console.log('Error', err);
        });
}
























CarritoInitial();
function CarritoInitial() {
    let urlRFID = `http://localhost:5000/api/carritoItem`;
    ajaxJson(urlRFID)
        .then(data => {
            console.log('InfoCarrito', data);
            let count = 0;
            let pago = 0;
            data.data.forEach(element => {
                count++;
                pago += element.precioTotal;
                console.log('pagar', pago);

                document.getElementById('TotalPago').innerText = pago;
                
                document.getElementById('counterCarrito').innerText = count;
                ListaCarrito.innerHTML += `
                               <li class="list-group-item d-flex justify-content-between lh-condensed">
                                    <div>
                                       <h6 class="my-0">${element.nombre}</h6>
                                      <small class="text-muted">${element.descripcion}</small>
                                   </div>
                                  <span class="text-muted">S/.${element.precioTotal}</span>
                                </li>
                 `;
            });
        }).catch((err) => {
            console.log('Error', err);
        });

}



function AgregarCarrito(productoid) {

    let counter = parseInt( document.getElementById('counterCarrito').innerText);

    document.getElementById('counterCarrito').innerText = counter + 1;

    let urlRFID = `http://localhost:5000/api/producto/${productoid}`;
    ajaxJson(urlRFID)
        .then(data => {
            console.log(data.data);
            let cantidad = document.getElementById(`${productoid}`).value;
            total = data.data.precio * parseInt(cantidad);


            let totalSoles = parseInt(document.getElementById('TotalPago').innerText);

            document.getElementById('TotalPago').innerText = totalSoles + total;


            ListaCarrito.innerHTML += `
                               <li class="list-group-item d-flex justify-content-between lh-condensed">
                                    <div>
                                       <h6 class="my-0">${data.data.nombre}</h6>
                                      <small class="text-muted">${data.data.descripcion}</small>
                                   </div>
                                  <span class="text-muted">S/.${total}</span>
                                </li>
                 `;


            const CarritoItem = {
                productoId: parseInt(productoid),
                Cantidad: parseInt(cantidad),
                PrecioUnitario: data.data.precio,
                PrecioTotal: total
            }

            console.log(CarritoItem);
            InsertCarritoItem(CarritoItem);


        }).catch((err) => {
            console.log('Error', err);
        });
  
}


const  InsertCarritoItem = (carritoData) => {

    let url = `http://localhost:5000/api/carritoItem`;

    fetch(url, {
        method: 'POST', // or 'PUT'
        body: JSON.stringify(carritoData), // data can be `string` or {object}!
        headers: {
            'Content-Type': 'application/json'
        }
    }).then(res => res.json())
        .catch(error => console.error('Error:', error))
        .then(response => console.log('Success:', response));



}


document.getElementById("btn_ConfirmarPago").addEventListener('click', () => {

        let urlRFID = `http://localhost:5000/api/producto/UpdateStock`;
        ajaxJson(urlRFID)
            .then(data => {
                if (!data.data.error) {
                    $('#exampleModalCenter').modal('show');
                } else {
                    alert('Error al procesar');
                }
                location.reload();

            }).catch((err) => {
                console.log('Error', err);
            });
   
    //Agregar a Tabla de Ventas


});