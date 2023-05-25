function fakeFetch(urlString, options) {
    const url = new URL(urlString);

    if (url.hostname == "facegram.azurewebsites.net" && url.pathname == "/api/posts") {
        if (url.searchParams.get('tag') === 'Arms') {
            return {
                postContent : "I have strong arms",
                postImageURL : "data:image/jpeg;base64,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",
                postUrl : "https://example.com",
                author:"testing",
                postTime:"15d"
            }
        }
        else if (url.searchParams.get('tag') === 'Back') {
            return {

                postContent : "get carried",
                postImageURL : "data:image/jpeg;base64,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",
                postUrl : "https://example.com",
                author:"testing",
                postTime:"15d"
            }
        }
        else {
            return {
                
            }
        }
    }
    else {
        throw new Error('This URL has not been implemented in the fake API: ' + urlString);
    }
}


async function GetPost(mucleGroup) {
var apiUrl = "https://facegram.azurewebsites.net/api/posts?tag="+mucleGroup;
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
