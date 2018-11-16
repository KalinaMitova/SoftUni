function validate() {
    let usernamePatter = /^[A-Za-z0-9]{3,20}$/;
    let emailPatter = /^\w+@\w*(\.\w*)+$/;
    let passwordPatter = /^\w{5,15}$/;

    let username = $('#username');
    let email = $('#email');
    let password = $('#password');
    let confirmPassword = $('#confirm-password');
    let company = $('#company');
    let companyInfo = $('#companyInfo');
    let companyNumber = $('#companyNumber');
    let submit = $('#submit');
    let valid = $('#valid');
    let invalidInputs = false;

    company.on('change', function() {
        if(company.is(":checked")) {
            companyInfo.css('display', 'block');
        } else {
            companyInfo.css('display', 'none');
        }
    });

    submit.on('click', function(ev) {
                
        let usernameMatch = username.val().match(usernamePatter);;
        let emailMatch = email.val().match(emailPatter);
        let passwordMatch = password.val().match(passwordPatter);
        let confirmPasswordMatch = confirmPassword.val().match(passwordPatter);
        
        $('input').css("border", "none");
        
        if(!usernameMatch) {
            username.css("border", "2px solid red");
            invalidInputs = true;
        }
        if(!emailMatch) {
            email.css("border", "2px solid red");
            invalidInputs = true;
        }
        if(!passwordMatch) {
            password.css("border", "2px solid red");
            invalidInputs = true;
        }
        if(confirmPassword.val() !== password.val() || !confirmPasswordMatch) {
            password.css("border", "2px solid red");
            confirmPassword.css("border", "2px solid red");
            invalidInputs = true;
        }
        if(company.is(":checked") && companyNumber.val() < 1000 || companyNumber.val() > 9999) {            
            companyNumber.css("border", "2px solid red");
            invalidInputs = true;
        }

        if(!invalidInputs) {
            valid.css('display', 'block');
        } else {
            valid.css('display', 'none');
        }

        ev.preventDefault();
    });
}
