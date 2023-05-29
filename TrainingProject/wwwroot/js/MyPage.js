let goalSelect = document.getElementById("goalSelect");
let targetWeightInput = document.getElementById("targetWeight");
let targetWeightLabel = document.getElementById("targetWeightLabel");


function visibilityOfTargetWheight() {

    if (goalSelect.value === "Lose Weight")
    {
        targetWeightLabel.style.display = "grid";
        targetWeightInput.style.display = "grid";
    } 

    else
    {
        targetWeightLabel.style.display = "none";
        targetWeightInput.style.display = "none";
    }
}

visibilityOfTargetWheight();

goalSelect.addEventListener("change", () => {
    visibilityOfTargetWheight();
});