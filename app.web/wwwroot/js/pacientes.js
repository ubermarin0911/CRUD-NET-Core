const url = "http://localhost:5000/api/clientes";

const insertarFila = (cliente) => {
    const tableClientes = document.querySelector(".clientes");

    const tr = document.createElement("tr");
    const tdId = document.createElement("td");
    tdId.style.display = 'none';
    const tdNombre = document.createElement("td");
    const tdEstado = document.createElement("td");
    const tdOpciones = document.createElement("td");
    const buttonEditar = document.createElement("button");
    buttonEditar.style.marginRight = '5px';
    const buttonEliminar = document.createElement("button");

    const id = document.createTextNode(cliente.Id);
    const nombre = document.createTextNode(cliente.NombreCompleto);
    const estado = document.createTextNode(cliente.Estado);

    const textoEditar = document.createTextNode("Editar");
    const textoEliminar = document.createTextNode("Eliminar");

    tdId.appendChild(id);
    tdNombre.appendChild(nombre);
    tdEstado.appendChild(estado);
    buttonEditar.appendChild(textoEditar);
    buttonEliminar.appendChild(textoEliminar);

    buttonEditar.classList.add("btn", "btn-primary", "editar");
    buttonEliminar.classList.add("btn", "btn-danger", "eliminar");

    tdOpciones.appendChild(buttonEditar);
    tdOpciones.appendChild(buttonEliminar);

    tr.appendChild(tdId);
    tr.appendChild(tdNombre);
    tr.appendChild(tdEstado);
    tr.appendChild(tdOpciones);

    tableClientes.appendChild(tr);
}

const getClientes = () => {

    fetch(url)
        .then(response => response.json())
        .then(json => {
            json.forEach(cliente => {
                insertarFila(cliente);
            });
        }); 
}

const guardarCliente = (cliente) => {
    fetch(url, {
        method: 'POST',
        body: cliente
    })
    .then((response) => response.json())
    .then((json) => {
        if (cliente.id) {
            getClientes();
        } else {
            insertarFila(json);
        }
        limpiarCampos();
    });
}

const editarCliente = (cliente) => {
    fetch(url, {
        method: 'PUT',
        body: cliente
    })
    .then((response) => response.json())
    .then((json) => console.log(json));
}

const eliminarCliente = (clienteId, event) => {
    fetch(`${url}/${clienteId}`, {
        method: 'DELETE',
    }).then(() => {
        const tr = event.target.closest('tr');
        tr.remove();
    });
}

const limpiarCampos = () => {
    document.querySelector("#nombre").value = "";

    var options = document.querySelector("#estado");
    options.selectedIndex = 0;
}

document.querySelector('#formCliente').addEventListener('submit', function (event) {
    event.preventDefault();

    const formData = new FormData(this);

    guardarCliente(formData);
});

document.querySelector('#tablaClientes').addEventListener('click', function (event) {
    const target = event.target;
    const clases = target.classList;
    if (clases.contains('editar')) {
        const tr = event.target.closest('tr');
      
        var elementos = tr.children;
        const id = elementos.item(0).firstChild.data;
        const nombre = elementos.item(1).firstChild.data;
        const estado = elementos.item(2).firstChild.data;

        document.querySelector("#clienteId").value = id;
        document.querySelector("#nombre").value = nombre;
        document.querySelector("#estado").value = estado;
    }
});

document.querySelector('#tablaClientes').addEventListener('click', function (event) {
    const target = event.target;
    const clases = target.classList;
    if (clases.contains('eliminar')) {
        const tr = event.target.closest('tr');
        const tdId = tr.firstChild.firstChild.data;
        eliminarCliente(tdId, event);
    }
});

getClientes();