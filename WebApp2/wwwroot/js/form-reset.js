document.addEventListener("DOMContentLoaded", function () {
    if (sessionStorage.getItem("SubscriptionSuccessMessage")) {
        // Rensa specifikt mejladressfältet
        document.querySelector("input[type='email']").value = "";
        // Rensa meddelandet från sessionen
        sessionStorage.removeItem("SubscriptionSuccessMessage");
    }
});
