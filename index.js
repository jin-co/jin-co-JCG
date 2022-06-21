/** section 1 image box */
const mainImage = document.querySelector('.main-img')
const countEl = document.querySelector('.count')
const mainText = document.querySelector('.main-text')
let count = 0

const loadPage = setInterval(() => {
  count++
  mainImage.style.filter = `blur(${100 - count}px)`
  countEl.textContent = `${count}%`
  countEl.style.opacity = `${1 - count / 100}`
  if (count >= 100) {
    clearInterval(loadPage)
    mainText.classList.add('show')
  }
}, 25)

/** section 2 games (javascript) selection */
const panelsEl = document.querySelectorAll('.panel')

panelsEl.forEach((e) => {
  e.addEventListener('mouseenter', () => {
    shirinkPanels()
    e.classList.add('expand')
  })
})

function shirinkPanels() {
  panelsEl.forEach((e) => {
    e.classList.remove('expand')
  })
}

/** section 3 games (c# an monogame) selection */
const btnUp = document.querySelector('.btn-panel-up')
const btnDown = document.querySelector('.btn-panel-down')
const gameContents = [
  {
    bgColor: '#2a86ba',
    fontColor: '#fff',
    title: 'mono shooting',
    description:
      `<h4>
        &nbsp;&nbsp;&nbsp;&nbsp;The object of this game is to get to the point without getting hit by enemies
       </h4>
       <ol>
        <p>
          To run:
        </p>
        <li>
         Download the installer by clicking the game image box 
        </li>
        <li>
         Unzip the file 
        </li>
        <li>
         Find the 'MonoShooting.exe' and run it (double click or right click and click 'open')
        </li>
        <li>
         Enjoy the game
        </li>
       </ol>
      `,
  },
  {
    bgColor: '#fd3555',
    fontColor: '#fff',
    title: '',
    description: '',
  },
  {
    bgColor: '#252e33',
    fontColor: '#fff',
    title: '',
    description: '',
  },
  {
    bgColor: '#ffb866',
    fontColor: '#fff',
    title: '',
    description: '',
  },
]

const leftFrames = document.querySelectorAll('.panel-left div')
const rightFrames = document.querySelectorAll('.panel-right div')
let frameIndex = 100

// shuffles the slide upward
btnUp.addEventListener('click', () => {
  frameIndex += 100
  if (frameIndex > 300) {
    frameIndex = 0
  }
  addContents(frameIndex)

  leftFrames.forEach((frame, idx) => {
    console.log(frame)
    frame.style.transform = `translateY(${-frameIndex}%)`
  })

  rightFrames.forEach((frame) => {
    frame.style.transform = `translateY(-${300 - frameIndex}%)`
  })
})

// shuffles the slide downward
btnDown.addEventListener('click', () => {
  frameIndex -= 100
  if (frameIndex < 0) {
    frameIndex = 300
  }
  addContents(frameIndex)

  leftFrames.forEach((frame, idx) => {
    console.log(frame)
    frame.style.transform = `translateY(${-frameIndex}%)`
  })

  rightFrames.forEach((frame) => {
    frame.style.transform = `translateY(-${300 - frameIndex}%)`
  })
})

const info = document.querySelector('.img-guide-btn')
const infoText = document.querySelector('.img-guide-text')
const infoBtn = document.querySelector('.img-guide-btn')
info.addEventListener('mouseover', () => {
  infoText.classList.add('show-info')  
})

infoText.addEventListener('mouseleave', () => {
  infoText.classList.remove('show-info')
})

addContents()

// adds game content to guide box to show related content description
function addContents(frameIdx = 0) {
  console.log('fram index: ', frameIdx)
  const index = frameIdx / 100
  infoText.innerHTML = gameContents[`${index}`].description
  infoText.style.backgroundColor = `${gameContents[index].bgColor}`
  infoText.style.color = `${gameContents[index].fontColor}` 
  infoBtn.style.backgroundColor = `${gameContents[index].bgColor}`
}

/** common */
const arrowBoxes = document.querySelectorAll('.arrow-box')

window.addEventListener('scroll', () => {
  arrowBoxes.forEach((arrow) => {
    if (arrow.getBoundingClientRect().top < 600) {
      arrow.classList.add('show-arrow')
    } else {
      arrow.classList.remove('show-arrow')
    }
  })
})
