document.addEventListener("DOMContentLoaded", function () {
    if (sessionStorage.getItem("SubscriptionSuccessMessage")) {
        // Rensa specifikt mejladressf�ltet
        document.querySelector("input[type='email']").value = "";
        // Rensa meddelandet fr�n sessionen
        sessionStorage.removeItem("SubscriptionSuccessMessage");
    }
});
