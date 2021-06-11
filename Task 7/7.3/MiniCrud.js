export class Storage {
    data;

    constructor() {
        this.data = [];
    }

    add(object) {
        if (this.getId(object)) {
            object.id = this.data.length;

            this.data.push(object);
        } else
        if (typeof(object) === object) {
            object.id = this.data.length;

            this.data.push(object);
        } else {
            console.log("Неправильный ввод данных!");
        }
    }

    getId(object) {
        for (var key in object) {
            if (key == "id") {
                return object;
            }
        }

        return undefined;
    }

    getById(id) {
        if (typeof(id) == "string") {
            for (var object of this.data) {
                if (object.id == id) {
                    return object;
                }
            }
        }
        return null;
    }

    getAll() {
        return this.data;
    }

    deleteById(id) {
        let objectToDelete = this.getById(id);
        if (objectToDelete != null) {
            this.data.splice(id, 1);

            this.updateArray();

            return objectToDelete;
        }

        return null;
    }

    updateArray() {

        let counter = 1;
        for (let element of this.data) {
            element.id = counter;

            counter++;
        }
    }

    updateById(id, newValue) {
        newValue.id = id;

        let objectToUpdate = this.getById(id);
        if (objectToUpdate != null) {
            for (let prop in newValue) {
                if (objectToUpdate.hasOwnProperty(prop))
                    objectToUpdate[prop] = newValue[prop];
            }

            return undefined;
        }

        return null;
    }

    replaceById(id, newObject) {
        let objectToReplace = this.getById(id);

        if (objectToReplace != null) {
            newObject.id = id;

            this.data.splice(this.data.indexOf(objectToReplace),
                1, newObject);

            return undefined;
        }

        return null;
    }
}

const storage = new Storage();

storage.add({ id: "", name: "Ira" });

storage.add({ id: "", name: "Alex" });

storage.add({ id: "", name: "Peppa" });

for (var elem of storage.getAll()) {
    console.log(elem);
}

console.log(storage.getById(123));

console.log(storage.getById("1"));

console.log(storage.getById("123"));

console.log("Удаление " + storage.deleteById("0").name);

console.log(storage.getById("0"));

for (var elem of storage.getAll()) {
    console.log(elem);
}

storage.updateById("2", { name: "Ira NEW" });

console.log(storage.replaceById("1", { name: "BORYA" }));

for (var elem of storage.getAll()) {
    console.log(elem);
}