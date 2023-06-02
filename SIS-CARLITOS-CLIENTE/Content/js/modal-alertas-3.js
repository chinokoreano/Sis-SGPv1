/// MENSAJE DE POP UP
//https://sweetalert2.github.io/#usage


//Funciones manejar si son valor nulos o no han sido definidos
function set_ico(icono, srcImgen = null) {
    if (srcImgen)
        return null;

    if (String(icono) == 'undefined' || !icono)
        icono = 'warning';

    return icono;
}
function set_pos(posicion) {
    if (String(posicion) == 'undefined' || !posicion)
        posicion = 'top';
    return posicion;
}

function set_img(srcImgen) {
    if (String(srcImgen) == 'undefined' || !srcImgen)
        srcImgen = null;
    return srcImgen;
}

/**
 * Crea modal de información con título, mensaje e ícono
 * @param {string} icono success, error, warning, info, question
 * @param {string} titulo Texto abierto
 * @param {string} mensaje subtitulo
 * @param {string} posicion top, top-start, top-end, center, center-start, center-end, bottom, bottom-start, or bottom-end
 */
function mensaje(icono, titulo, mensaje, posicion) {
    Swal.fire({
        position: set_pos(posicion),
        icon: icono,
        title: titulo,
        text: mensaje,
        confirmButtonColor: '#3085d6'
    })
}

/**
 * Crea modal de información solo mensaje e ícono
 * @param {string} icono success, error ,warning ,info, question
 * @param {string} mensaje subtitulo
 * @param {string} posicion top, top-start, top-end, center, center-start, center-end, bottom, bottom-start, or bottom-end
 */
function notificacion(icono, mensaje, posicion) {
    Swal.fire({
        position: set_pos(posicion),
        icon: icono,
        text: mensaje,
        confirmButtonColor: '#3085d6'
    })
}

/**
 * Muesta un modal de confirmación con titulo, mensaje e imagen que en caso de acepar REDIRECCIONA a url dado
 * @param {string} titulo
 * @param {string} texto
 * @param {url} url  ruta de re dirección en caso de confirmar
 * @param {imageUrl} srcImgen
 * @param {string} txtBtnAceptar
 * @param {string} icono success, error ,warning ,info, question
 */
function confirmacionRedirect(titulo, texto, url, srcImgen = null, txtBtnAceptar = "Confirmar", icono, posicion) {
    Swal.fire({
        position: set_pos(posicion),
        imageUrl: set_img(srcImgen),
        icon: set_ico(icono, set_img(srcImgen)),
        imageWidth: 300,
        imageHeight: 300,
        title: titulo,
        text: texto,
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: txtBtnAceptar,
        cancelButtonText: 'Cancelar',
        allowOutsideClick: false
    }).then((result) => {
        if (result.value) {
            window.location.replace(url);
        }
    })
}


/**
 * Muesta un modal de confirmación con titulo, mensaje e imagen que en caso de acepar EJECUTA la funcion dada
 * @param {string} titulo
 * @param {string} texto
 * @param {string} FunciosJS funcion a ejecutar en caso de confirmación
 * @param {string} srcImgen opcional
 * @param {string} txtBtnAceptar opcional
 * @param {string} icono opcional - success, error ,warning ,info, question
 */
function confirmacionFuncionJS(titulo, texto, FunciosJS, srcImgen, txtBtnAceptar = "Confirmar", icono, posicion) {
    Swal.fire({
        position: set_pos(posicion),
        imageUrl: set_img(srcImgen),
        icon: set_ico(icono, set_img(srcImgen)),
        imageWidth: 300,
        imageHeight: 300,
        title: titulo,
        text: texto,
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: txtBtnAceptar,
        cancelButtonText: 'Cancelar',
        allowOutsideClick: false
    }).then((result) => {
        if (result.value) {
            eval(FunciosJS);
        }
    })
}

/**
 * Muesta un modal con titulo y mensaje notificando al usuario previo a REDIRECCIONAR al url dado
 * @param {string} icono success, error ,warning ,info, question
 * @param {string} titulo
 * @param {string} mensaje
 * @param {url} url  ruta de re dirección en caso de confirmar
 * @param {string} posicion top, top-start, top-end, center, center-start, center-end, bottom, bottom-start, or bottom-end
 */
function notificacionRedirect(icono, titulo, mensaje, url, posicion) {
    Swal.fire({
        position: set_pos(posicion),
        icon: set_ico(icono),
        title: titulo,
        text: mensaje,
        allowOutsideClick: false,
        confirmButtonText: 'Confirmar',
        confirmButtonColor: '#3085d6'
    }).then((result) => {
        if (result.value) {
            window.location.replace(url);
        }
    })
}

//Se crea un elemento 'Toast generico'q hereda de Sweet alert 2 
const ToastGenerico = Swal.mixin({
    toast: true,
    showConfirmButton: false,
    timer: 4000,
    timerProgressBar: true,
    iconColor: 'white',
    customClass: {
        popup: 'colored-toast'
    },
    onOpen: (toast) => {
        toast.addEventListener('mouseenter', Swal.stopTimer)
        toast.addEventListener('mouseleave', Swal.resumeTimer)
    }
});

/**
 * Crea una notificacion toast genérica
 * @param {string} icono success, error ,warning ,info, question
 * @param {string} mensaje
 * @param {string} posicion top, top-start, top-end, center, center-start, center-end, bottom, bottom-start, or bottom-end
 */
function EjecutarToast(ico, mensaje, position = 'top-end') {
    ToastGenerico.fire({
        icon: ico,
        title: mensaje,
        position: position
    });
}

/**
 * Mostrar vista previa de una imagen en un modal
 * @param {string} img
 * @param {string} imgTarget ruta de la imagen a mostrar
 * @param {} modalTarget id del modal a abrir
 */
function vista_previa(img, imgTarget, modalTarget) {
    document.getElementById(imgTarget).src = img.src;
    $("#" + modalTarget).modal();
}

/**
 * Abrir modal por id
 * @param {string} modalTarget id del modal a abrir
 */
function abrir_modal(modalTarget) {
    $("#" + modalTarget).modal('show');
}

function cerrar_modal_bs(modalTarget) {
    var modal_element = document.getElementById(modalTarget)
    var modal_bs = bootstrap.Modal.getInstance(modal_element)
    modal_bs.hide()
}

function MensajeFuncionJS(titulo, texto, FuncionJS, textoBoton = "Aceptar", icono = "info", posicion) {
    Swal.fire({
        position: set_pos(posicion),
        icon: icono,
        title: titulo,
        text: texto,
        showCancelButton: false,
        confirmButtonColor: '#3085d6',
        confirmButtonText: textoBoton,
        allowOutsideClick: false,
        showClass: {
            popup: 'animate__animated animate__fadeInDown'
        },
        hideClass: {
            popup: 'animate__animated animate__fadeOutUp'
        }
    }).then((result) => {
        if (result.value) {
            eval(FuncionJS);
        }
    })
}