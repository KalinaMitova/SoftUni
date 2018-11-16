function createComputerHierarchy() {
    class Manufacturer {
        constructor(manufacturer) {
            if(new.target === Manufacturer) {
                throw new Error("Cannot instantiate an abstract class.");
            }
            
            this.manufacturer = manufacturer;
        }
    }

    class Battery extends Manufacturer {
        constructor(manufacturer, expectedLife) {
            super(manufacturer);

            this.expectedLife = +expectedLife;
        }
    }

    class Keyboard extends Manufacturer {
        constructor(manufacturer, responseTime) {
            super(manufacturer);

            this.responseTime = +responseTime;
        }

    }

    class Monitor extends Manufacturer {
        constructor(manufacturer, width, height) {
            super(manufacturer);

            this.width = width;
            this.height = height;
        }

    }

    class Computer extends Manufacturer {
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace) {
            if(new.target === Computer) {
                throw new Error("Cannot instantiate an abstract class.");
            }

            super(manufacturer);

            this.processorSpeed = processorSpeed; // Ghz
            this.ram = ram;                      // Gigabytes
            this.hardDiskSpace = hardDiskSpace; // Terabytes
        }
    }

    class Laptop extends Computer {
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace, weight, color, battery) {
            super(manufacturer, processorSpeed, ram, hardDiskSpace);

            this.weight = weight;
            this.color = color;
            this.battery = battery;
        }

        get battery() {
            return this._battery;
        }

        set battery(val) {
            if(!(val instanceof Battery)) {
                throw new TypeError("Invalid argument. Battery argument is not of type Monitor.");
            }
            
            this._battery = val;
        }

    }
    
    class Desktop extends Computer {
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace, keyboard, monitor) {
            super(manufacturer, processorSpeed, ram, hardDiskSpace);

            this.keyboard = keyboard;
            this.monitor = monitor;
        }

        get keyboard() {
            return this._keyboard;
        }

        set keyboard(val) {
            if(!(val instanceof Keyboard)) {
                throw new TypeError("Invalid argument. Keyboard argument is not of type Monitor.");
            }

            this._keyboard = val;
        }

        get monitor() {
            return this._monitor;
        }

        set monitor(val) {
            if(!(val instanceof Monitor)) {
                throw new TypeError("Invalid argument. Monitor argument is not of type Monitor.");
            }

            this._monitor = val;
        }
    }

    return {
        Battery,
        Keyboard,
        Monitor,
        Computer,
        Laptop,
        Desktop
    }
}

module.exports = createComputerHierarchy;