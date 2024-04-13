document.addEventListener("DOMContentLoaded", function () {

    function validateEmailInput(emailInput, emailError) {
        const emailRegex = /^(([^<>()[\]\\.,;:\s@\""]+(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        if (!emailRegex.test(emailInput.value)) {
            emailError.textContent = "Enter a valid email address";
        } else {
            emailError.textContent = "";
        }
    }


    const signInForm = document.querySelector('.signin');
    const signUpForm = document.querySelector('.signup');

    // Validering för SignUp-sidan
    if (signUpForm) {
        const firstNameInput = document.querySelector('#form-firstname input');
        const firstNameError = document.querySelector('#form-firstname span');
        const lastNameInput = document.querySelector('#form-lastname input');
        const lastNameError = document.querySelector('#form-lastname span');
        const passwordInput = document.querySelector('#form-password input');
        const passwordError = document.querySelector('#form-password span');
        const confirmPasswordInput = document.querySelector('#form-confirm input');
        const confirmPasswordError = document.querySelector('#form-confirm span');
        const termsCheckbox = document.querySelector('#form-terms input[type="checkbox"]');
        const termsError = document.querySelector('#form-terms span');

        firstNameInput.addEventListener('input', function () {
            firstNameError.textContent = this.value.trim().length >= 2 ? "" : "Enter a valid firstname.";
        });

        lastNameInput.addEventListener('input', function () {
            lastNameError.textContent = this.value.trim().length >= 2 ? "" : "Enter a valid lastname.";
        });

        passwordInput.addEventListener('input', function () {
            const passwordRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*]).{8,}$/;
            passwordError.textContent = passwordRegex.test(this.value) ? "" : "Enter a valid password";
        });

        confirmPasswordInput.addEventListener('input', function () {
            confirmPasswordError.textContent = this.value === passwordInput.value ? "" : "Passwords do not match";
        });

        termsCheckbox.addEventListener('change', function () {
            termsError.textContent = this.checked ? "" : "You must agree to the terms & conditions";
        });
    }

    // Validering endast för e-post på SignIn-sidan. Struntade i Password, såg ingen mening med det.
    if (signInForm) {
        const emailInput = document.querySelector('.signin #form-email input');
        const emailError = document.querySelector('.signin #form-email span');
        if (emailInput && emailError) {
            emailInput.addEventListener('input', function () {
                validateEmailInput(emailInput, emailError);
            });
        }
    }

    if (signUpForm) {
        const emailInputSignUp = document.querySelector('.signup #form-email input');
        const emailErrorSignUp = document.querySelector('.signup #form-email span');
        if (emailInputSignUp && emailErrorSignUp) {
            emailInputSignUp.addEventListener('input', function () {
                validateEmailInput(emailInputSignUp, emailErrorSignUp);
            });
        }
    }
});
