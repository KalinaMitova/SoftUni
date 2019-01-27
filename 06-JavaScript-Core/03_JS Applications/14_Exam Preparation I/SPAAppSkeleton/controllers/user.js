const user = (function(){
    const getLogin = function(ctx){
        ctx.partial('views/user/login.hbs');
    };

    const postLogin = function(ctx){
        var username = ctx.params.username;
        var password = ctx.params.password;
        
        userModel.login(username, password)
            .done(function(data){
                storage.saveUser(data);
                            
                ctx.redirect('#/');
            });
    };

    const logout = function(ctx){
        userModel.logout().done(function(){
            storage.deleteUser();
            
            ctx.redirect('#/');
        });
    }

    const getRegister = function(ctx) {
        ctx.partial('views/user/register.hbs');
    };

    const postRegister = function(ctx) {
        userModel.register(ctx.params).done(function(data){
            storage.saveUser(data);

            ctx.redirect('#/');
        });
    }

    const initializeLogin = function(){
        if(userModel.isAuthorized()){
            $.get("views/common/welcome.hbs")
                .then(function(source) {
                    let template = Handlebars.compile(source);
                    let html = template({"username": storage.getData("userInfo").username});
                    $('#profile').html(html);
                });
        } else {
            $('#profile').html("");
        }        
    };

    return {
        getLogin,
        postLogin,
        logout,
        getRegister,
        postRegister,
        initializeLogin
    };
}());