const asyncStorage = require('./asyncStorage');
const storage = require('./storage');

// Sync tests
try {
    storage.load()
    storage.put('first', 'firstValue')
    storage.put('second', 'secondValue')
    storage.put('third', 'thirdValue')
    storage.put('fouth', 'fourthValue')
    console.log(storage.get('first'))
    console.log(storage.getAll())
    storage.delete('second')
    storage.update('first', 'updatedFirst')
    storage.save()
    storage.clear()
    console.log(storage.getAll())
    storage.load()
    console.log(storage.getAll())
} catch (err) {
    console.log(err.message);
}

// // Async tests
// (async function () {
//     try {
//         await asyncStorage.loadAsync()
//         await asyncStorage.putAsync('first', 'firstValue')
//         await asyncStorage.putAsync('second', 'secondValue')
//         await asyncStorage.putAsync('third', 'thirdValue')
//         await asyncStorage.putAsync('fouth', 'fourthValue')
//         console.log(await asyncStorage.getAsync('first'))
//         console.log(await asyncStorage.getAllAsync())
//         await asyncStorage.deleteAsync('second')
//         await asyncStorage.updateAsync('first', 'updatedFirst')
//         await asyncStorage.saveAsync()
//         await asyncStorage.clearAsync()
//         console.log(await asyncStorage.getAllAsync())
//         await asyncStorage.loadAsync()
//         console.log(await asyncStorage.getAllAsync())
//     } catch (err) {
//         console.log(err.message);
//     }
// })();