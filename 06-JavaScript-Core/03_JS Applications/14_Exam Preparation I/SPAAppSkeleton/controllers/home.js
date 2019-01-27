 const home = (function(){
    const index = function(ctx) {
        let isAuth = userModel.isAuthorized();
        
        if(isAuth) {
            ctx.partial('../views/car/list.hbs');  
        } else {
            ctx.partial('../views/main-page.hbs');    
        }
    };

    return {
        index
    };
}());