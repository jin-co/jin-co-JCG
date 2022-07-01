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
    description: `
      <h4>
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
    description: `
      <h4>
        &nbsp;&nbsp;&nbsp;&nbsp;Try to hit as many targets as you can using mouse in a limited time
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
         Find the 'Shooting.exe' and run it (double click or right click and click 'open')
        </li>
        <li>
         Enjoy the game
        </li>
      </ol>
    `,
  },
  {
    bgColor: '#816797',
    fontColor: '#fff',
    title: '',
    description: `
      <h4>
        &nbsp;&nbsp;&nbsp;&nbsp;Fly into the space dodging  asteroids 
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
         Find the 'Spaceship.exe' and run it (double click or right click and click 'open')
        </li>
        <li>
         Enjoy the game
        </li>
      </ol>
    `,
  },
  {
    bgColor: '#ffb866',
    fontColor: '#3f3f3f',
    title: '',
    description: `
      <h4>
        &nbsp;&nbsp;&nbsp;&nbsp;Monsters are coming to get you, defeat them to protect your town  
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
         Find the 'RPG.exe' and run it (double click or right click and click 'open')
        </li>
        <li>
         Enjoy the game
        </li>
      </ol>
    `,
  },
]

const leftFrames = document.querySelectorAll('.panel-left div')
const rightFrames = document.querySelectorAll('.panel-right div')
let frameIndex = 100
let btnActivated = false

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
  btnActivated = true
})

// shuffles the slide downward
btnDown.addEventListener('click', () => {
  frameIndex -= 100

  if (!btnActivated) {
    frameIndex = 300
  } 

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
  btnActivated = true
})

const info = document.querySelector('.img-guide-btn')
const infoText = document.querySelector('.img-guide-text')
const infoBtn = document.querySelector('.img-guide-btn')
info.addEventListener('mouseover', () => {
  infoText.classList.add('show-info')
})

info.addEventListener('click', () => {
  if (infoText.className.includes('show-info')) {
    infoText.classList.remove('show-info')
  } else {
    infoText.classList.add('show-info')
  }
})

infoText.addEventListener('mouseleave', () => {
  infoText.classList.remove('show-info')
})

addContents()

// adds game content to guide box to show related content description
function addContents(frameIdx = 0) {
  console.log('frame index: ', frameIdx)
  const index = frameIdx / 100
  infoText.innerHTML = gameContents[`${index}`].description
  infoText.style.backgroundColor = `${gameContents[index].bgColor}`
  infoText.style.color = `${gameContents[index].fontColor}`
  infoBtn.style.backgroundColor = `${gameContents[index].bgColor}`
}

/** section 4 about */
const aboutBox = document.querySelector('.about-box')
const aboutLeftTop = document.querySelector('.about-left-top-box')
const aboutLeftTBottom = document.querySelector('.about-left-bottom-box')
const aboutRightTop = document.querySelector('.about-right-top-box')
const aboutRightBottom = document.querySelector('.about-right-bottom-box')

aboutLeftTop.addEventListener('mouseover', () => {
  aboutBox.classList.add('hover-left-top')
})

aboutLeftTop.addEventListener('mouseleave', () => {
  aboutBox.classList.remove('hover-left-top')
})

aboutRightTop.addEventListener('mouseover', () => {
  aboutBox.classList.add('hover-right-top')
})

aboutRightTop.addEventListener('mouseleave', () => {
  aboutBox.classList.remove('hover-right-top')
})

aboutLeftTBottom.addEventListener('mouseover', () => {
  aboutBox.classList.add('hover-left-bottom')
})

aboutLeftTBottom.addEventListener('mouseleave', () => {
  aboutBox.classList.remove('hover-left-bottom')
})

aboutRightBottom.addEventListener('mouseover', () => {
  aboutBox.classList.add('hover-right-bottom')
})

aboutRightBottom.addEventListener('mouseleave', () => {
  aboutBox.classList.remove('hover-right-bottom')
})

/** section 5 contact me */
const contactMeTitle = document.querySelector('.contact-me-title')
const contactMeTitleText = 'Contact Me'
let contactMeIndex = 1
writeContactTitle()

function writeContactTitle() {
  contactMeTitle.innerText = contactMeTitleText.slice(0, contactMeIndex)
  contactMeIndex++
  if (contactMeIndex > contactMeTitleText.length) [(contactMeIndex = 1)]
  setTimeout(writeContactTitle, 300)
}

const contactMeFieldLabels = document.querySelectorAll(
  '.contact-me-form .form-control label'
)
contactMeFieldLabels.forEach((label) => {
  console.log(label)
  label.innerHTML = label.innerText
    .split('')
    .map(
      (letter, idx) =>
        `<span style="transition-delay:${idx * 50}ms">${letter}</span>`
    )
    .join('')
})

/** section 6 survey */
const surveyBox = document.querySelector('.survey-box')
const surveyForm = document.querySelector('.survey-choice-form')
const surveyResult = document.querySelector('.survey-result-box')
const surveyStatistics = document.querySelector('.survey-statistics-box')
const btnSurveyBack = document.querySelector('.survey-statistics-box button')
const btnSurveyShowResult = document.querySelector('.survey-result-box button')

surveyForm.addEventListener('submit', (e) => {
  e.preventDefault()
  let selectedValue
  try {
    selectedValue = surveyForm.querySelector(
      'input[name="survey"]:checked'
    ).value
    surveyBox.classList.add('show-survey-result')
  } catch {
    alert('Please select at least one option')
  }
})

btnSurveyShowResult.addEventListener('click', () => {
  surveyBox.classList.remove('show-survey-result')
  surveyBox.classList.add('show-statistics')
})

btnSurveyBack.addEventListener('click', () => {
  surveyBox.classList.remove('show-statistics')
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

//header
const menuIconBtn = document.querySelector('.menu-icon-box')
menuIconBtn.addEventListener('click', () => {
  menuIconBtn.classList.toggle('menu-icon-clicked')
})
