function removeRepeatedChars(str) {
    const separators = ["?", "!", ":", ";", ",", "."]

    let chars = [];
    let words = str.split(" ");

    for (var word of words) {
        for (var char of word) {
            if (countChars(word, char) > 1 && chars.indexOf(char) == -1 && !separators.includes(char)) {
                chars.push(char);
            }
        }
    }

    for (var char of chars) {
        while (str.indexOf(char) != -1) {
            str = str.replace(char, "");
        }
    }

    return str;
}

function countChars(str, charToCount) {
    let counter = 0;

    for (var char of str) {
        if (char == charToCount)
            counter++;
    }

    return counter;
}

console.log(removeRepeatedChars("У попа была собака"));