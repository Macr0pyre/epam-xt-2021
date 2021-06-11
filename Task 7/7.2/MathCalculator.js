function calculate(expression) {

    let fullExpression = expression;

    while (expression.indexOf(" ") !== -1) {
        expression = expression.replace(" ", "");
    }

    expression = expression.split("=")[0];

    if (!expression.match(/\D{2,}|\.\d{1,}\./g)) {
        const operators = expression.match(/[\/+*-]/g).reverse();
        const operands = expression.match(/\d+\.\d+|\d+/g);
        const calculationResult = calculateData(operators, operands, expression[0]);

        return fullExpression + " " + calculationResult.toPrecision(calculationResult.toString().split(/\./)[0].length + 2);
    } else {
        console.log("Неправильный формат математического выражения!");
    }
}

function calculateData(operators, operands, firstChar) {
    let calculationResult;

    if (firstChar === "-") {
        calculationResult = -parseFloat(operands[0]);
    } else {
        calculationResult = parseFloat(operands[0]);
    }

    operands.shift();

    for (var operand of operands) {
        switch (operators.pop()) {
            case "+":
                calculationResult += parseFloat(operand);
                break;
            case "-":
                calculationResult -= parseFloat(operand);
                break;
            case "/":
                calculationResult /= parseFloat(operand);
                break;
            case "*":
                calculationResult *= parseFloat(operand);
                break;
        }
    }

    return calculationResult;
}

console.log(calculate("3.5 +4*10-5.3 /5 ="));