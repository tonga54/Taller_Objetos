var reg = document.getElementById("register").addEventListener("click", show);

var bandera = false;
function show() {
    if (bandera == false) {
        document.getElementById("loginTitle").innerHTML = "Registrarse";
        document.getElementById("pnlRegister").style.display = 'block';
        document.getElementById("pnlLogin").style.display = 'none';
        document.getElementById("register").innerHTML = "Ya tienes una cuenta? Ingresa";
        bandera = true;
    } else {
        document.getElementById("loginTitle").innerHTML = "Iniciar Sesion";
        document.getElementById("pnlRegister").style.display = 'none';
        document.getElementById("pnlLogin").style.display = 'block';
        document.getElementById("register").innerHTML = "No tienes una cuenta? Registrate";
        bandera = false;
    }
}