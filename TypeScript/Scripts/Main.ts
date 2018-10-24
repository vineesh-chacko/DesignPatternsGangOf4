class Car {
    engine: string;
    constructor(engine: string) {
        this.engine = engine;
    }


    start() {
        alert("Engine started" + this.engine);

    }

    stop() {
        alert("Engine stopped" + this.engine);
    }

    init : (s:string, s1:string, s2:string)=>void
    = function (s, s1, s2)
    {

    }
    

}

window.onload = function () {
    var car = new Car('V8');
    car.start();
    car.stop();
    car.init("", "", "");
};