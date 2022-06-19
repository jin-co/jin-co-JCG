const nextBtns = document.querySelectorAll('.next')
const goBackBtns = document.querySelectorAll('.go-back')
const pages = document.querySelectorAll('.pages')
const characterBoxContainer = document.querySelector('.character-box-container')

//* page moving
nextBtns.forEach((next, index) => {
  next.addEventListener('click', () => {
    shufflePage(index)
  })
})

let idx = 0
goBackBtns.forEach((pre, index) => {
  pre.addEventListener('click', () => {
    idx = index
    if (idx >= 0) {
      idx--
      shufflePage(idx)
    }
    if (idx < 0) {
      shufflePage(3)
    }
  })
})
//* page moving

//* player choice
const POKEPICAPI =
  'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/shiny/2.png'
const MAX_NUM = 150

async function fetchCharacter() {
  const res = await fetch(POKEPICAPI + '2')
  const data = await res.json()
  console.log(data.sprites.front_shiny)
  return data.sprites.front_shiny
}

// onload generates characters and appends them to the second page
const characterBoxes = []
window.addEventListener('load', () => {
  for (let i = 1; i <= MAX_NUM; i++) {
    const playerEl = document.createElement('div')
    playerEl.className = 'character-box'
    playerEl.innerHTML = `
            <img class="img" src="https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/shiny/${i}.png" alt="">
            <div class="circle"></div>
        `
    characterBoxContainer.appendChild(playerEl)
    characterBoxes.push(playerEl)
  }
  getImageEl()
})

// adds selected player to an array for selection
const playerCount = document.querySelector('.player-count')

let playerChosen = []
const displayBox = document.querySelector('.display-box')

function getImageEl() {
  const imgs = document.querySelectorAll('.img')
  imgs.forEach((img) => {
    img.addEventListener('click', (e) => {
      // capsule
      console.log(e.target.parentNode)

      e.target.parentNode.className = 'character-box pick'

      let copied = e.target.parentNode.cloneNode()

      let picCopied = e.target.cloneNode()
      copied.appendChild(picCopied)

      let circleCopied = document.createElement('div')
      circleCopied.className = 'circle'
      copied.appendChild(circleCopied)

      playerChosen.push(copied)

      displayBox.appendChild(copied)
      console.log(copied, '\narray ', playerChosen)
      playerCount.value = playerChosen.length
    })
  })
}
//* /player choice

//* Selection
const runBtn = document.querySelector('.run')
const sumUpBox = document.querySelector('.sum-up-box')

runBtn.addEventListener('click', () => {
  let random = 0
  let effect = setInterval(() => {
    playerChosen.forEach((pocket) => {
      pocket.classList.remove('select')
    })
    random = Math.floor(Math.random() * playerChosen.length)
    playerChosen[random].classList.add('select')
  }, 100)
  setTimeout(() => {
    clearInterval(effect)
    playerChosen[random].classList.add('select')
    openPocket(playerChosen[random])
  }, 3000)
})
//* /Selection

//* Sum-up page
const startOver = document.querySelector('.start-over')
startOver.addEventListener('click', () => {
  resetGame()
})
//* /Sum-up page

// functions
/// resets game
function resetGame() {
  playerChosen = []
  displayBox.innerHTML = ''
  selectedPlayersBox.innerHTML = ''
  sumUpBox.innerHTML = ''
  removePick()
}

/// removes pick class
function removePick() {
  characterBoxes.forEach((box) => {
    box.classList.remove('pick')
  })
}

/// removes the pocket after it has been chosen
const selectedPlayersBox = document.querySelector('.selected-players-box')
function openPocket(chosenPocket) {
  setTimeout(() => {
    chosenPocket.className = 'character-box'
    selectedPlayersBox.appendChild(chosenPocket)
    let copied = chosenPocket.cloneNode()
    copied.innerHTML = chosenPocket.innerHTML
    sumUpBox.appendChild(copied)
  }, 1000)
  playerChosen.splice(playerChosen.indexOf(chosenPocket), 1)
}

function shufflePage(index) {
  console.log(index)
  console.log(pages)
  updateStatusBar(index)
  switch (index) {
    case 0:
      // two
      pages[0].style.transform = 'translate(0%, 100%)'
      pages[1].style.transform = 'translate(0%, -100%)'
      pages[2].style.transform = 'translate(100%, -100%)'
      pages[3].style.transform = 'translate(100%, 0%)'
      break
    case 1:
      // three
      pages[0].style.transform = 'translate(100%, 100%)'
      pages[1].style.transform = 'translate(0%, 0%)'
      pages[2].style.transform = 'translate(0%, -100%)'
      pages[3].style.transform = 'translate(100%, -100%)'
      break
    case 2:
      // four
      pages[0].style.transform = 'translate(100%, 0%)'
      pages[1].style.transform = 'translate(100%, 0%)'
      pages[2].style.transform = 'translate(0%, 0%)'
      pages[3].style.transform = 'translate(0%, -100%)'
      break
    case 3:
      // one
      pages[0].style.transform = 'translate(0%, 0%)'
      pages[1].style.transform = 'translate(100%, -100%)'
      pages[2].style.transform = 'translate(100%, 0%)'
      pages[3].style.transform = 'translate(0%, 0%)'
      break
    default:
      break
  }
}

const line = document.querySelector('.line')
const nums = document.querySelectorAll('.num')
addCircle(1)
function updateStatusBar(idx) {
  console.log('index: ', idx)
  clearCircles()
  switch (idx) {
    case 3:
      addCircle(1)
      break
    case 0:
      addCircle(2)
      break
    case 1:
      addCircle(3)
      break
    case 2:
      addCircle(4)
      break
  }
}

function clearCircles() {
  nums.forEach((num) => {
    num.classList.remove('fill')
  })
}

function addCircle(limit) {
  for (let i = 0; i < limit; i++) {
    nums[i].classList.add('fill')
  }
  updateProgressLine(limit)
}

function updateProgressLine(limit) {
  let num = calculte(limit)
  console.log('cal: ', num, ', ', limit)
  line.style.width = `${num}%`
}

function calculte(limit) {
  nums[3].classList.remove('final-effect')
  let num = 0
  switch (limit) {
    case 1:
      break
    case 2:
      num = 33
      break
    case 3:
      num = 66
      break
    case 4:
      num = 100
      showFinalEffect()
      break
  }
  return num
}

function showFinalEffect() {
  nums[3].classList.add('final-effect')
}

// rotate menu
const menuBox = document.querySelector('.menu-box')
const btnOpen = document.querySelector('.menu-icon-open')
const btnClose = document.querySelector('.menu-icon-close')

btnOpen.addEventListener('click', () => {
    console.log('rotate: ')
    menuBox.classList.add('rotate')
})

btnClose.addEventListener('click', () => {
    menuBox.classList.remove('rotate')
})
