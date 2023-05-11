//var name = 'Olga';
const name = 'Ivan';

const number = 12.0;
const numberV2 = .5;
const numberV3 = NaN;

const boolV1 = true;
const boolV2 = false;

const user = {};

const funcV1 = function () {

}

function funcV2() {

}

funcV1();
funcV2();

const newFunc = funcV2;
newFunc();


function createUser(age, name, isAdult) {
    const newUser = {
        name,
        age,
        isAdult
    };
    return newUser;
}

const user = createUser(20, 'pol', true);

const arr = [];
arr[0] = 1;
arr.push(123);

for (let i = 0; i < arr.length; i++) {
    let obj = arr[i];
}

const user = {
    name: 'Pol',
    age: 12
};

//BAD
user = {};

//GOOD
user.age = 42;
user.count = 56;

name = 12.1;
name = [true, false];


if (true) {
    let cSharpName = 'Ivan';
}

if (true) {
    let cSharpName = 'Ivan';
}


$(document).ready();