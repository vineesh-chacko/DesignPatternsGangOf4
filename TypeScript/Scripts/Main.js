var Car = /** @class */ (function () {
    function Car(engine) {
        this.init = function (s, s1, s2) {
        };
        this.engine = engine;
    }
    Car.prototype.start = function () {
        alert("Engine started" + this.engine);
    };
    Car.prototype.stop = function () {
        alert("Engine stopped" + this.engine);
    };
    return Car;
}());
window.onload = function () {
    var car = new Car('V8');
    car.start();
    car.stop();
    car.init("", "", "");
};
//# sourceMappingURL=Main.js.map