
//Para llamar a animaciones durante el hover
function hover_pulse(opcion) {
    $('.hover_pulse').hover(function () { $(this).addClass('animate__animated animate__pulse ' + opcion) })
    $('.hover_pulse').mouseout(function () { $(this).removeClass('animate__animated animate__pulse ' + opcion) })
}

function hover_heartBeat(opcion) {
    $('.hover_heartBeat').hover(function () { $(this).addClass('animate__animated animate__heartBeat ' + opcion) })
    $('.hover_heartBeat').mouseout(function () { $(this).removeClass('animate__animated animate__heartBeat ' + opcion) })
}

function hover_flip(opcion) {

    $('.hover_flip').hover(function () { $(this).addClass('animate__animated animate__flip ' + opcion) })
    $('.hover_flip').mouseout(function () { $(this).removeClass('animate__animated animate__flip ' + opcion) })
}


function hover_primary() {

    $('.hover_primary').hover(function () { $(this).addClass('bg-spe text-white') })
    $('.hover_primary').mouseout(function () { $(this).removeClass('bg-spe text-white') })
}

function hover_envios() {
    $('.hover_primary').hover(function () { $('.hover_flip', this).addClass('animate__animated animate__flip') })
    $('.hover_primary').mouseout(function () { $('.hover_flip', this).removeClass('animate__animated animate__flip') })

    $('.hover_flip').hover(function () { $(this).parent('.hover_primary').addClass('bg-spe text-white') })
    $('.hover_flip').mouseout(function () { $(this).parent('.hover_primary').removeClass('bg-spe text-white') })

}

/* https://animate.style/ */
/*
    animate__slow	2s
    animate__slower	3s
    animate__fast	800ms
    animate__faster	500ms

    Attention seekers
    bounce
    flash
    pulse
    rubberBand
    shakeX
    shakeY
    headShake
    swing
    tada
    wobble
    jello
    heartBeat
    Back entrances
    backInDown
    backInLeft
    backInRight
    backInUp
    Back exits
    backOutDown
    backOutLeft
    backOutRight
    backOutUp
    Bouncing entrances
    bounceIn
    bounceInDown
    bounceInLeft
    bounceInRight
    bounceInUp
    Bouncing exits
    bounceOut
    bounceOutDown
    bounceOutLeft
    bounceOutRight
    bounceOutUp
    Fading entrances
    fadeIn
    fadeInDown
    fadeInDownBig
    fadeInLeft
    fadeInLeftBig
    fadeInRight
    fadeInRightBig
    fadeInUp
    fadeInUpBig
    fadeInTopLeft
    fadeInTopRight
    fadeInBottomLeft
    fadeInBottomRight
    Fading exits
    fadeOut
    fadeOutDown
    fadeOutDownBig
    fadeOutLeft
    fadeOutLeftBig
    fadeOutRight
    fadeOutRightBig
    fadeOutUp
    fadeOutUpBig
    fadeOutTopLeft
    fadeOutTopRight
    fadeOutBottomRight
    fadeOutBottomLeft
    Flippers
    flip
    flipInX
    flipInY
    flipOutX
    flipOutY
    Lightspeed
    lightSpeedInRight
    lightSpeedInLeft
    lightSpeedOutRight
    lightSpeedOutLeft
    Rotating entrances
    rotateIn
    rotateInDownLeft
    rotateInDownRight
    rotateInUpLeft
    rotateInUpRight
    Rotating exits
    rotateOut
    rotateOutDownLeft
    rotateOutDownRight
    rotateOutUpLeft
    rotateOutUpRight
    Specials
    hinge
    jackInTheBox
    rollIn
    rollOut
    Zooming entrances
    zoomIn
    zoomInDown
    zoomInLeft
    zoomInRight
    zoomInUp
    Zooming exits
    zoomOut
    zoomOutDown
    zoomOutLeft
    zoomOutRight
    zoomOutUp
    Sliding entrances
    slideInDown
    slideInLeft
    slideInRight
    slideInUp
    Sliding exits
    slideOutDown
    slideOutLeft
    slideOutRight
    slideOutUp

*/

function hover_animated(animacion, duracion) {

    if (duracion != undefined || duracion != null) {
        if (duracion != "")
            duracion = " " + duracion;
    } else
        duracion = "";


    $('.hover_' + animacion).hover(function () { $(this).addClass('animate__animated animate__' + animacion + duracion) })
    $('.hover_' + animacion).mouseout(function () { $(this).removeClass('animate__animated animate__' + animacion + duracion) })
}