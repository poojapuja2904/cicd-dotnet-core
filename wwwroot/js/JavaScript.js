var x = 0;
var s = " ";


console.log("pooja");

var theForm = document.getElementById("theForm");
theForm.hidden = true;

var button = document.getElementById("buyItem");
button.addEventListener("click", function () {
    alert("item bought");
});

var productInfo = document.getElementsByClassName("productInfo");
var listItem = productInfo.item[0].children;
