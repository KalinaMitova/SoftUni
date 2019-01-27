function solve(worker) {
    if(!worker.handsShaking) {
        return worker;
    }

    worker.bloodAlcoholLevel += worker.experience * worker.weight * 0.1;
    worker.handsShaking = false;

    return worker;
}

let worker = { 
    weight: Number,
    experience: Number,
    bloodAlcoholLevel: Number,
    handsShaking: Boolean 
};  