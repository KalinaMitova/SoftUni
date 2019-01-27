function addItem() {
    let newItemText = document.getElementById("newItemText");
    let newItemValue = document.getElementById("newItemValue");

    let select = document.getElementById("menu");

    let option = document.createElement("option");
    option.value = newItemValue.value;
    option.textContent = newItemText.value;

    select.appendChild(option);

    newItemText.value = "";
    newItemValue.value = "";
}