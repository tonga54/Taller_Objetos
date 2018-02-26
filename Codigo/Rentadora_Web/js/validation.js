function simulatePostback() {
    var imagen = document.getElementById("<%= fileImagen.ClientID %>").value;
    if (imagen.indexOf(".png") > -1 || imagen.indexOf(".jpg") > -1 || imagen.indexOf(".bmp") > -1) {
        var button = document.getElementById("<%= btnPostBack.ClientID %>").click();
    } else {
        alert("Formato de imagen no soportado");
    }
}

function eventValidation() {
    var bandera = true;
    var mensaje = "ERROR:\n";
    var fechaNacimiento = document.getElementById("<%= TxtFecNacimiento.ClientID %>").value;
    var descripcion = document.getElementById("<%= txtDescripcion.ClientID %>").value;
    var cliente = document.getElementById("<%= txtCliente.ClientID %>").value;
    var cantAsistentes = Number(document.getElementById("<%= txtCantAsistentes.ClientID %>").value);
    var cantAsistentesServicio = Number(document.getElementById("<%= txtCantAsistentesServicio.ClientID %>").value);
    var pnl = document.getElementById("<%= pnlImg.ClientID %>");


    if (fechaNacimiento != "") {
        if (descripcion != "") {
            if (cliente != "") {
                if (cantAsistentes > 0) {
                    if (cantAsistentesServicio > 0) {
                        if (cantAsistentesServicio <= cantAsistentes) {
                            if (document.getElementById("<%= rbnEstandar.ClientID %>").checked) {
                                var duracion = Number(document.getElementById("<%= txtDuracion.ClientID %>").value);
                                if (!(duracion > 0 && duracion <= 4)) {
                                    mensaje += "Duracion menor o igual a 0, o mayor a 4\n";
                                    bandera = false;
                                } else {
                                    if (!(cantAsistentes <= 10)) {
                                        mensaje += "Cantidad de asistentes al evento (Estandar) mayor a 10";
                                        bandera = false;
                                    } else {
                                        if (pnl == null) {
                                            mensaje += "Seleccione una imagen";
                                            bandera = false
                                        }
                                    }
                                }
                            } else if (document.getElementById("<%= rbnPremium.ClientID %>").checked) {
                                if (!(cantAsistentes <= 100)) {
                                    mensaje += "Cantidad de asistentes al evento (Premium) mayor a 100";
                                    bandera = false;
                                } else {
                                    if (pnl == null) {
                                        mensaje += "Seleccione una imagen";
                                        bandera = false
                                    }
                                }

                            } else {
                                mensaje += "Seleccione un tipo de evento \n";
                                bandera = false;
                            }
                        } else {
                            mensaje += "Cantidad de asistentes al servicio no puede ser mayor a la cantidad de asistentes al evento\n";
                            bandera = false;
                        }
                    } else {
                        mensaje += "Cantidad de asistentes para el servicio menor o igual a 0\n";
                        bandera = false;
                    }
                } else {
                    mensaje += "Cantidad de asistentes al evento menor o igual a 0\n";
                    bandera = false;
                }
            } else {
                mensaje += "Nombre del cliente vacio\n";
                bandera = false;
            }
        } else {
            mensaje += "Descripcion vacia\n";
            bandera = false;
        }
    } else {
        mensaje += "Fecha de nacimiento vacia\n";
        bandera = false;
    }

    if (!bandera) {
        alert(mensaje);
    }

    return bandera;
}


