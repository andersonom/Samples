const fs = require('fs')

console.log(1)

// Callback
// fs.readFile('./in1.txt', (err, contents) => {
//     fs.readFile('./in2.txt', (err2, contents2) => {
//         console.log(err, String(contents))
//         console.log(err2, String(contents2))
//     })
// })

//Promise
const readFile = file => new Promise((resolve, reject) => {
    fs.readFile(file, (err, contents) => {
        if (err) {
            reject(err)
        } else {
            resolve(contents)
        }
    })
})

//Promise call
// readFile('./in1.txt') 
// .then(contents=>{
//     console.log(String(contents))
//     return readFile('./in2.txt')
// })
// .then(contents => {
// console.log(String(contents)) 
// })
 
//Async await - syntax sugar for calling promises
const init = async() => {
const contents = await readFile('./in1.txt')
const contents2 = await readFile('./in2.txt')
console.log(String(contents))
console.log(String(contents2))
} 

init()

console.log(2)

console.log(3)