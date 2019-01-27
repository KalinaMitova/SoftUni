const app = Sammy('#main', function(){
    this.use('Handlebars', 'hbs');
    this.before({except: {}}, function() {
        user.initializeLogin();
    });

    this.get('#/', home.index);
    this.get('#/login', user.getLogin);
    this.post('#/login', user.postLogin);
    this.get('#/logout', user.logout);
    this.get('#/register', user.getRegister);
    this.post('#/register', user.postRegister);
    this.post('#/register', user.postRegister);
    this.get('#/list', car.list);
    this.get('#/myList', car.myList);
    this.get('#/car/create', car.getCreate);
    this.post('#/car/create', car.postCreate);
    this.get('#/car/edit', car.getEdit);
    this.post('#/car/edit', car.postEdit);
    this.get('#/car/details', car.details);
});

$(function(){
    app.run('#/');
});