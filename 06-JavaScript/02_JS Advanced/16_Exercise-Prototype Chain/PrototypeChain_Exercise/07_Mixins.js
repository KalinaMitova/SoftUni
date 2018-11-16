function createMixins() {
    
    function getQuality() {
        return (this.processorSpeed + this.ram + this.hardDiskSpace) / 3;
    }

    function isFast() {
        return this.processorSpeed > (this.ram / 4);
    }

    function isRoomy() {
        return this.hardDiskSpace > Math.floor(this.ram * this.processorSpeed)
    }

    function computerQualityMixin(classToExtend) {
        Object.assign(classToExtend.prototype, {
            getQuality,
            isFast,
            isRoomy
        });
    }

    function isFullSet() {
        return this.manufacturer === this.keyboard.manufacturer && this.keyboard.manufacturer === this.monitor.manufacturer;
    }

    function isClassy() {
        return this.battery.expectedLife >= 3 && (this.color === "Silver" || this.color === "Black") && this.weight < 3;
    }

    function styleMixin(classToExtend) {
        Object.assign(classToExtend.prototype, {
            isFullSet,
            isClassy
        });
    }

    return {
        computerQualityMixin,
        styleMixin
    }
}

let createComputerHierarchy = require('./06_Computer');

let computerHierarchy = createComputerHierarchy();
let mixins = createMixins();

mixins.computerQualityMixin(computerHierarchy.Laptop);

let battery = new computerHierarchy.Battery("Dell", 4);
let computer = new computerHierarchy.Laptop("Dell", 3.2, 16, 2, 1000, "Silver", battery);

let getQuality = computer.getQuality();
let isFast = computer.isFast();
let isRoomy = computer.isRoomy();

console.log();
