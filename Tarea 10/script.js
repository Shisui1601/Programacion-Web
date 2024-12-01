document.addEventListener("DOMContentLoaded", () => {
    const saveButton = document.getElementById("saveButton");
    const colorInputs = document.querySelectorAll(".colorInput");
    const rojoCount = document.getElementById("rojoCount");
    const verdeCount = document.getElementById("verdeCount");
    const azulCount = document.getElementById("azulCount");

    loadColorData();

    function loadColorData() {
        const data = JSON.parse(localStorage.getItem("colorData")) || { rojo: 0, verde: 0, azul: 0 };
        rojoCount.textContent = data.rojo;
        verdeCount.textContent = data.verde;
        azulCount.textContent = data.azul;

        const savedColors = JSON.parse(localStorage.getItem("cellColors")) || [];
        colorInputs.forEach((input, index) => {
            if (savedColors[index]) {
                input.value = savedColors[index];
                input.style.backgroundColor = savedColors[index];
            }
        });
    }

    function updateCellColors() {
        let rojo = 0;
        let verde = 0;
        let azul = 0;
        const newCellColors = [];

        colorInputs.forEach(input => {
            const color = input.value.toLowerCase();

            if (color === "rojo") {
                input.style.backgroundColor = "red";
                rojo++;
            } else if (color === "verde") {
                input.style.backgroundColor = "green";
                verde++;
            } else if (color === "azul") {
                input.style.backgroundColor = "blue";
                azul++;
            } else {
                input.style.backgroundColor = "#fff";
            }

            newCellColors.push(input.value); 
        });

        rojoCount.textContent = rojo;
        verdeCount.textContent = verde;
        azulCount.textContent = azul;

        localStorage.setItem("colorData", JSON.stringify({ rojo, verde, azul }));
        localStorage.setItem("cellColors", JSON.stringify(newCellColors));
    }

    saveButton.addEventListener("click", updateCellColors);
});
