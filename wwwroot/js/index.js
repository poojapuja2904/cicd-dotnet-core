/// <reference path="../lib/jquery/dist/jquery.min.js" />

$(document).ready(function () {
    var x = 0;
    var s = " ";


    console.log("pooja");

    var theForm = $("#theForm");
    theForm.show();

    var button = $("#buyItem");
    button.on("click", function () {
        console.log("item bought");
    });

    var productInfo = $(".productInfo li");
    productInfo.on("click", function () {
        console.log("you clicked on item" + $(this).innerText);
    });

    var $loginToggle = $("#loginToggle");
    var $form = $(".form");

    $loginToggle.on("click", function () {
        $form.toggle(1000);
    });
});