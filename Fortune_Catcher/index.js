const btnPlay = document.querySelector('.btn-play')
const pages = document.querySelectorAll('.pages')
const reset = document.querySelector('.btn-reset')
const minute = document.querySelector('.minute')
const second = document.querySelector('.second')
const scoreEl = document.querySelector('.score')
const gameScreen = document.querySelector('.game-screen')

var timer;
var popup;

let pageIndex = 1
let imageIndex = 0
let score = 0
let secondIndex = 0
let minuteIndex = 0
let multiplyIndex = 1

const images = [
    "http://pngimg.com/uploads/peach/peach_PNG4869.png",
    "https://pngimg.com/uploads/money/money_PNG3523.png",
    "https://pngimg.com/uploads/heart/heart_PNG51192.png",
    "http://pngimg.com/uploads/dreamcatcher/dreamcatcher_PNG8.png",
    "https://pngimg.com/uploads/horseshoe/horseshoe_PNG16.png",
    "https://pngimg.com/uploads/mug_coffee/mug_coffee_PNG16824.png"
]

/// *** first page ***
btnPlay.addEventListener('click', () => {
    showNextPage()  
})

/// *** second page ***
const choices = document.querySelectorAll('.choices')
choices.forEach((choice, idx) => {
    choice.addEventListener('click', () => {
        showNextPage()
        startTimer()
        createImages(idx)
    })
});

// create images
const createImages = function(idx) {
    for (let i = 0; i < multiplyIndex; i++) {
        const img = document.createElement('img')
        img.setAttribute('src', `${images[idx]}`)
        img.style.top = `${getRandomPosition()}%`
        img.style.left = `${getRandomPosition()}%`
        img.style.transform = `rotate(${getRandomPosition()}deg)`
        setTimeout(() => {
            gameScreen.appendChild(img)    
        }, 500);
        multiplyIndex = 2
        img.addEventListener('click', () => {
            img.remove()
            createImages(idx)
            score++
            console.log(score)
            scoreEl.textContent = score
        })
    }
}

// pupulate the item chosen
function populateFortune() {
    console.log('populate')
}

/// *** third page ***
// reset the game and go back to the 
reset.addEventListener('click', () => {
    pageIndex = 0
    score = 0
    secondIndex = 0
    minuteIndex = 0
    second.textContent = 00
    minute.textContent = 00
    gameScreen.innerHTML = ""
    scoreEl.innerHTML = "00"
    showNextPage()
})

/// *** utility functions ***
// shows next page based on the index
function showNextPage() {
    pages.forEach(page => {
        page.style.transform = `translateY(${-100 * pageIndex}%)`
    });
    pageIndex++
}

// starts the time and stops when it hits 30minutes
function startTimer() {
    timer = setInterval(() => {
        secondIndex++
        if (secondIndex > 60) {
            secondIndex = 0
            minuteIndex++
        }

        if (minuteIndex >= 30) clearInterval(timer)
        
        if (secondIndex.toString().length < 2) {
            second.innerHTML = "0" + secondIndex    
        } else {
            second.innerHTML = secondIndex
        }
        
        if (minuteIndex.toString().length < 2) {
            minute.innerHTML = "0" + minuteIndex    
        } else {
            minute.innerHTML = minuteIndex
        }
    }, 100);
}

function stopTimer() {
    clearInterval(timer)
}

// get random position
function getRandomPosition() {
    return Math.floor(Math.random() * 101)
}