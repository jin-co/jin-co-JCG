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

const leftFrames = document.querySelectorAll('.panel-left div')
const rightFrames = document.querySelectorAll('.panel-right div')
let frameIndex = 100
btnUp.addEventListener('click', () => {
  frameIndex += 100
  if (frameIndex > 300) {
    frameIndex = 0    
  } 

  leftFrames.forEach((frame, idx) => {
    console.log(frame)
    frame.style.transform = `translateY(${-frameIndex}%)`
  })

  rightFrames.forEach((frame) => {
    frame.style.transform = `translateY(-${300 - frameIndex}%)`
  })  
})

btnDown.addEventListener('click', () => {
  frameIndex -= 100
  if (frameIndex < 0) {
    frameIndex = 300    
  } 

  leftFrames.forEach((frame, idx) => {
    console.log(frame)
    frame.style.transform = `translateY(${-frameIndex}%)`
  })

  rightFrames.forEach((frame) => {
    frame.style.transform = `translateY(-${300 - frameIndex}%)`
  })  
})

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
