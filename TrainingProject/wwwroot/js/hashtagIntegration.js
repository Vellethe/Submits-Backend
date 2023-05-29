async function GetPost(mucleGroup) {
var apiUrl = "https://facegram.azurewebsites.net/posts?tag="+mucleGroup;
    const response = await fetch(apiUrl, { method:"GET"});
    const json = await response.json();
    
    return json;
}

let rootDiv = document.getElementById("socialMedia")

let author = document.createElement("p");
let postTime = document.createElement("p");
let image = document.createElement("img");
let description = document.createElement("p");
let link = document.createElement("a");

let topPart = document.createElement("div");

topPart.append(author);
topPart.append(postTime);
rootDiv.append(topPart);

rootDiv.appendChild(image);
rootDiv.appendChild(description);
rootDiv.appendChild(link);



let mostCommonMucleGroup = document.getElementById("mostCommonGroup"); 

//let x = fakeFetch("https://facegram.azurewebsites.net/api/posts?tag="+mostCommonMucleGroup.textContent);
let x = await GetPost(mostCommonMucleGroup.textContent)

let dateTime = new Date(x.datePosted);

let dateText = dateTime.toLocaleDateString();

image.src = x.imageURL;
description.textContent = x.postContent;
link.href = x.postURL;
link.text = "link to facegram";

author.textContent = x.poster;

postTime.textContent = dateText;
