var x = 0;
var s = "";

console.log("Hello Pluralsight");

//Hide the form
var theForm = $("#theForm"); //Returns a collection that we can execute over
theForm.hide();

//Log that we clicked the buy button
var button = $("#buyButton");
button.on("click", function() {
    console.log("Buying Item");
});

//Get list items
var listItems = $(".product-props li");
listItems.on("click", function() {
    console.log("You clicked on " + $(this).text());
})