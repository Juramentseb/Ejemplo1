
var elementos = document.getElementsByClassName("enlace");


for (var i = 0; i < elementos.length; i++) {
    elementos[i].addEventListener("mouseover", porencima);
    elementos[i].addEventListener("mouseout", alquitar);
}


function porencima() {
    this.style.color = "orange";
}

function alquitar() {
    this.style.color = "brown";
}