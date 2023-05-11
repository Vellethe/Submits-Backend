let goalSelect = document.getElementById("goal");
let targetWeightInput = document.getElementById("targetWeight");
let targetWeightLabel = document.getElementById("targetWeightRow");

goalSelect.addEventListener("change", () => {
  if (goalSelect.value === "Lose Weight") {
    targetWeightInput.style.display = "grid";
  } 
  else {
    targetWeightLabel.style.display = "none"
    targetWeightInput.style.display = "none";
  }
});