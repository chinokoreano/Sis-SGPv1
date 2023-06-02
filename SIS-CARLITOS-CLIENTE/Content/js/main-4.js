/**
 * Para cambiar el formato del dinero 
 * @param {any} claseLblContieneDinero
 * @param {any} tamanioDolar
 * @param {any} tamanioCentavos
 */
function formatoDinero(claseLblContieneDinero, tamanioDolar, tamanioCentavos) {

    var arrayLabelsPrecios = document.getElementsByClassName(claseLblContieneDinero);

    for (var i = 0; i < arrayLabelsPrecios.length; i++) {

        $monto = $(arrayLabelsPrecios.item(i)).text();

        $index = $monto.indexOf(".") > -1 ? $monto.indexOf(".") : $monto.indexOf(",") > -1 ? $monto.indexOf(",") : -1;


        if ($index > -1) {

            $centavos = $monto.slice($index + 1);
            $dolares = $monto.slice(0, $index);

        }
        else {
            $centavos = '00';
            $dolares = $monto;
        }
        $centavos = ('.' + $centavos + '00').substring(1, 3);
        $(arrayLabelsPrecios.item(i)).html("<sup class=''>$</sup>" + "<span class='align-top " + tamanioDolar + "'>" + $dolares + "</span>" + "<sup class='" + tamanioCentavos + "'>" + $centavos + "</sup>");
    }

}


// Esta función permite ingresar solo números
function filtarNumeros(evt) {
    var theEvent = evt || window.event;

    // Handle paste
    if (theEvent.type === 'paste') {
        key = event.clipboardData.getData('text/plain');
    } else {
        // Handle key press
        var key = theEvent.keyCode || theEvent.which;
        key = String.fromCharCode(key);
    }
    var regex = /[0-9]|\./;
    if (!regex.test(key)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }
}

function redondear2Decimales(numero) {
    var nuevoNumero = new Number(numero + '').toFixed(parseInt(12));
    return parseFloat(nuevoNumero);
}

function CrearCookieObj(nombre, objeto, tiempoVidaHoras) {
    var fecha = new Date();
    fecha.setTime(fecha.getTime() + (tiempoVidaHoras * 60 * 60 * 1000));
    var cookie = [nombre, '=', JSON.stringify(objeto), '; expires=', fecha.toGMTString(), '; path=/;SameSite=None; Secure'].join('');
    document.cookie = cookie;
}

function CrearCookieStr(nombre, str, tiempoVidaHoras) {
    var fecha = new Date();
    fecha.setTime(fecha.getTime() + (tiempoVidaHoras * 60 * 60 * 1000));
    var cookie = [nombre, '=', str, '; expires=', fecha.toGMTString(), '; path=/;SameSite=None; Secure'].join('');
    document.cookie = cookie;
}

function ObtenerCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function obtenerNombrePagina() {
    var path = window.location.pathname;
    var page = path.split("/").pop();
    return page;
}

/**
 * Detecta el cambio de la tecla capsLock (Bloq Mayus)
 * El text box a detectar debe tener la clase capLock
 * Colocar la imagen <img src="/Recursos/assets/ico/Caps_Lock-512.png" class="d-24x24 ml-1 d-none capLockIndicator" /> junto al control para indicar el estado
 */
function detectarCapsLock() {
    //Cuando el selector detecte cambio de caopsLock muestra a no la imagen capLockIndicator
    $('.capLock').keyup(function (event) {
        if (event.originalEvent.getModifierState("CapsLock")) {
            $('.capLockIndicator').addClass('d-inline').removeClass('d-none');
        } else {
            $('.capLockIndicator').addClass('d-none').removeClass('d-inline');
        }
    });
    //Cuando pierde el foco se desactiva la imagen indicativa
    $('.capLock').blur(function () {
        $('.capLockIndicator').addClass('d-none').removeClass('d-inline');
    });

}


/**
 * Permite el efecto de excroll para ello es necesario el estilo en el tag html html {scroll-behavior: smooth;}
 * @param {entero valor en X} posX
 * @param {entero valor en Y} posY
 * @param {tiempo de retarlos para ejecutar el scrolling} milisegundos
 */
function setScrollTop(posX, posY, milisegundos) {
    window.setTimeout("window.scrollTo(" + 0 + "," + 0 + ")", 600);

}

//Se crea una función base para llamar la animación mediante JS
const animateCSS = (element, animation, prefix = 'animate__') =>
    // We create a Promise and return it
    new Promise((resolve, reject) => {
        const animationName = `${prefix}${animation}`;
        const node = document.querySelector(element);

        node.classList.add(`${prefix}animated`, animationName);

        // When the animation ends, we clean the classes and resolve the Promise
        function handleAnimationEnd() {
            node.classList.remove(`${prefix}animated`, animationName);
            node.removeEventListener('animationend', handleAnimationEnd);

            resolve('Animation ended');
        }

        node.addEventListener('animationend', handleAnimationEnd);
    });


//Obtener el ancho del browser
function getWidth() {
    return Math.max(
        document.body.scrollWidth,
        document.documentElement.scrollWidth,
        document.body.offsetWidth,
        document.documentElement.offsetWidth,
        document.documentElement.clientWidth
    );
}

//Obtener el alto del browser
function getHeight() {
    return Math.max(
        document.body.scrollHeight,
        document.documentElement.scrollHeight,
        document.body.offsetHeight,
        document.documentElement.offsetHeight,
        document.documentElement.clientHeight
    );
}

//Redireccionar a una pagina luego del tiempo dado
function RedirectDelay(url, segundos) {
    segundos = segundos * 1000;
    setTimeout(function () {
        window.location.replace(url);
    }, segundos);
}

//Redireccionar a una pagina por JS
//Tiene delay de 2000 ms
function RedirectPorJS(url) {
    setTimeout(function () {
        window.location.replace(url);
    }, 2000);
}

//Redirecciona de inmediato
function InstantRedirectPorJS(url) {
    window.location.replace(url);
}


//Cargar el JS de table responsible
function tablaResponsibeFooTable(tableTarget) {
    /*
        "xs": 480, // extra small
        "sm": 768, // small
        "md": 992, // medium
        "lg": 1200 // large
     */
    $ancho = getWidth();
    if ($ancho < 768)
        $('[id*=' + tableTarget + ']').footable();
}

function DesabilitarPrimerItemDDL() {
    //Para deshabilitar el primer elemento de los combos con la clase disableFirst
    $(".disableFirst option:first-child").attr("disabled", "disabled");
}

//Para activar el filtro en un grid view
//Nota: se debe agregar como clase el id de la tabla
function activarFiltroTabla(idTabla, idCampoFiltro) {
    $("#" + idCampoFiltro).on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("." + idTabla + " tbody tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
}

//Para exportar un documento a Excel directo desde un grid View
function exportTableToExcel(tableID, filename = '') {
    var downloadLink;
    var dataType = 'application/vnd.ms-excel';
    var tableSelect = document.getElementById(tableID);
    var tableHTML = tableSelect.outerHTML.replace(/ /g, '%20');

    //Specify date string
    var f = new Date();
    var str_f = '_' + f.getDate() + '-' + (f.getMonth() + 1) + "-" + f.getFullYear();

    // Specify file name
    filename = filename ? filename + str_f : 'excel_data' + str_f;
    filename = filename + '.xls';

    // Create download link element
    downloadLink = document.createElement("a");

    document.body.appendChild(downloadLink);

    if (navigator.msSaveOrOpenBlob) {
        var blob = new Blob(['\ufeff', tableHTML], {
            type: dataType
        });
        navigator.msSaveOrOpenBlob(blob, filename);
    } else {
        // Create a link to the file
        downloadLink.href = 'data:' + dataType + ', ' + tableHTML;

        // Setting the file name
        downloadLink.download = filename;

        //triggering the function
        downloadLink.click();
    }
}

//Para activar el datepicker en los txt con fecha actualizada (utilizar solo en la carga inicial)
function activarDatePickerUpdateNow() {
    $(".date").datepicker({
        autoclose: true,
        todayHighlight: true
    }).datepicker('update', new Date());
}

//Para activar el datepicker en los txt sin actualización de fecha (utilizar despues del posback para que no cambie la fecha seleccionada por el usuario)
function activarDatePicker() {
    $(".date").datepicker({
        autoclose: true,
        todayHighlight: true
    });
}

/**
* Permite mover una columna desde una ubicación a otra
* @param tabla 
* @param desde indice de la clumna a nover
* @param a lugar al que se movera. 
* Nota: se puede movel cualquier columna hasta la penúltima posición
*/
function moverCoumna(tabla, desde, a) {
    var rows = jQuery('tr', tabla);
    var cols;
    rows.each(function () {
        cols = jQuery(this).children('th, td');
        cols.eq(desde).detach().insertBefore(cols.eq(a));
    });
}

//En ciertas ocaciones el popober da error al momento de hacer click, para cerrarlo se debe colocar 
//data-placement="bottom" data-toggle="popover" data-trigger="hover" data-content="Es el título del enlace que se mostrará al alumno" OnClientClick="cerrarPopover()"
function cerrarPopover() {
    $('[data-toggle="popover"]').popover('hide');
}

function obtenerIdYoutube(url_elemento) {
    var r, rx = /^.*(?:(?:youtu\.be\/|v\/|vi\/|u\/\w\/|embed\/)|(?:(?:watch)?\?v(?:i)?=|\&v(?:i)?=))([^#\&\?]*).*/;
    r = url_elemento.match(rx);
    return r[1];
}

function AsociarEnterBoton(event, NombreCssBoton) {
    //Se valida si esta dando un enter 
    if (event.key === "Enter") {
        var btn = document.getElementsByClassName(NombreCssBoton)[0];

        if (btn === undefined)
            btn = document.getElementById(NombreCssBoton);

        if (btn === undefined || btn === null) {
            EjecutarToast("warning", "Acción no definida");

            return;
        }

        btn.click();
    }

}

//Para formaterar el texto a fecha aa/mm/dd de un input en tiempo real, con sus respectivas validaciones

function FormatarFecha(input) {

    // Guardar la posición del cursor antes de actualizar el valor del campo de entrada
    let posicionCursor = input.selectionStart;

    // Eliminar todos los caracteres que no sean dígitos
    let numeros = input.value.replace(/\D/g, '');


    //  Eliminar dígito o barra diagonal al presionar retroceso
    if (event.inputType == "deleteContentBackward" || event.inputType == "deleteContentForward") {
        if (posicionCursor > 0 && (posicionCursor == 2 || posicionCursor == 5)) {
            input.value = input.value.substring(0, posicionCursor - 1);
        }
    }
    else {
        // Agregar la barra diagonal después del segundo y quinto dígito
        if (numeros.length >= 2 && numeros.length < 4) {
            numeros = numeros.substring(0, 2) + '/' + numeros.substring(2);
        } else if (numeros.length >= 4) {
            numeros = numeros.substring(0, 2) + '/' + numeros.substring(2, 4) + '/' + numeros.substring(4, 8);
        }

        // Actualizar el valor del campo de entrada con los dígitos formateados
        input.value = numeros;

        // Restaurar la posición del cursor después de actualizar el valor del campo de entrada
        if (posicionCursor == 2 || posicionCursor == 5)
            posicionCursor++;

        input.setSelectionRange(posicionCursor, posicionCursor);
    }


    // Validar la fecha
    const parts = input.value.split('/');
    const day = parseInt(parts[0], 10);
    const month = parseInt(parts[1], 10);
    const year = parseInt(parts[2], 10);

    const today = new Date();
    const currentYear = today.getFullYear();

    if (
        day > 31 ||
        month > 12 ||
        year < 1900 ||
        year > currentYear ||
        (month === 2 && (esBisiesto(year) ? day > 29 : day > 28)) ||
        ((month === 4 || month === 6 || month === 9 || month === 11) && day > 30) ||
        (validarFecha_amd(input.value)) > today
    ) {
        input.className = ((input.className.replace("bg-light", "")).replace("bg-success", "")).replace("bg-danger", "") + " bg-danger";
    } else {
        if (posicionCursor >= 10) {
            input.className = ((input.className.replace("bg-light", "")).replace("bg-danger", "")).replace("bg-success", "") + " bg-success";
        } else
            input.className = ((input.className.replace("bg-danger", "")).replace("bg-success", "")).replace("bg-light", "") + " bg-light";
    }
}

/* Para verificar si un año es bisiesto */
function esBisiesto(anio) {
    return (anio % 4 === 0 && anio % 100 !== 0) || anio % 400 === 0;
}

/* Para verificar si un año tiene el formado aa/mm/dd */
function validarFecha_amd(fecha) {
    // Expresión regular que valida el formato de fecha
    var regex = /^\d{2}\/\d{2}\/\d{4}$/;

    if (!regex.test(fecha)) {
        // Si la cadena no cumple con el formato, retorna false
        return false;
    } else {
        // Si la cadena cumple con el formato, valida que sea una fecha válida
        var dia = parseInt(fecha.substring(0, 2));
        var mes = parseInt(fecha.substring(3, 5));
        var anio = parseInt(fecha.substring(6, 10));

        var fechaObj = new Date(anio, mes - 1, dia);

        if (fechaObj.getFullYear() == anio && fechaObj.getMonth() == mes - 1 && fechaObj.getDate() == dia) {
            // Si la fecha es válida, retorna true
            return true;
        } else {
            // Si la fecha no es válida, retorna false
            return false;
        }
    }
}


/* Para setear el foco en un input dado*/
function setFoco(elementoFoco) {
    document.getElementById(elementoFoco).focus();
}


function ContadorBtnDeshabilitado(disabledElem, progressBar, time) {
    if (time == null) {
        time = 5;
    }
    var seconds = Math.ceil(time); // Calculate the number of seconds
    var secondsPB = Math.ceil(time); // Calculate the number of seconds

    disabledElem.setAttribute('disabled', 'disabled');

    var originalText = disabledElem.value; // Remember the original text content

    // append the number of seconds to the text
    disabledElem.value = originalText + ' (' + seconds + ')';

    // do a set interval, using an interval of 1000 milliseconds
    //     and clear it after the number of seconds counts down to 0
    var interval = setInterval(function () {
        seconds = seconds - 1;

        // decrement the seconds and update the text
        disabledElem.value = originalText + ' (' + seconds + ')';
        if (seconds === 0) { // once seconds is 0...
            disabledElem.removeAttribute('disabled');
            clearInterval(interval); // clear interval
            disabledElem.value = originalText;
        }
    }, 1000);

    var intervalPB = setInterval(function () {
        secondsPB = secondsPB - 0.1;

        var progress = ((time - secondsPB) * 100) / time;
        progressBar.style.width = progress + "%";

        if (secondsPB < 0) { // once seconds is 0...
            clearInterval(intervalPB); // clear interval
        }
    }, 100);

};