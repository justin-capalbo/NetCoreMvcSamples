var x = 0;
var s = "";

console.log("Hello Pluralsight");

//Hide the form
var theForm = document.getElementById("theForm");

theForm.hidden = true;

//Log that we buy an item
var button = document.getElementById("buyButton");

button.addEventListener("click", function() {
    console.log("Buying Item");
});

//Get list items
var productInfo = document.getElementsByClassName("product-props");
var listItems = productInfo.item[0].children;