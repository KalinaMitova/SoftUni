class Entity {
    constructor(name) {
        if(new.target === Entity) {
            throw new Error("Cannot instantiate an abstract class.");
        }

        this.name = name;
    }
}

module.exports = Entity;