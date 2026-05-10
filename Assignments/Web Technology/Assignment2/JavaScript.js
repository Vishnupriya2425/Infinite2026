// 1. Area of Triangle
let a = 5;
let b = 6;
let c = 7;

let s = (a + b + c) / 2;

let area = Math.sqrt(s * (s - a) * (s - b) * (s - c));

console.log("1. Area of Triangle =", area);


// 2. Pattern using Nested For Loop
console.log("2. Pattern:");

for (let i = 1; i <= 5; i++) {

    let pattern = "";

    for (let j = 1; j <= i; j++) {
        pattern += "* ";
    }

    console.log(pattern);
}


// 3. Leap Year Program
let year = 2024;

if ((year % 4 === 0 && year % 100 !== 0) || (year % 400 === 0)) {

    console.log("3. " + year + " is a Leap Year");

} else {

    console.log("3. " + year + " is not a Leap Year");
}


// 4. Days Left Until Independence Day
let today = new Date();

let currentYear = today.getFullYear();

let independenceDay = new Date(currentYear, 7, 15);

if (today > independenceDay) {

    independenceDay = new Date(currentYear + 1, 7, 15);
}

let diffTime = independenceDay - today;

let diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));

console.log("4. Days left until Independence Day =", diffDays);