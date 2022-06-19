/** section 1 image box */
const mainImage = document.querySelector('.main-img')
const countEl = document.querySelector('.count')
const mainText = document.querySelector('.main-text')
let count = 0

const loadPage = setInterval(() => {
  count++
  mainImage.style.filter = `blur(${100 - count}px)`
  countEl.textContent = `${count}%`
  countEl.style.opacity = `${1 - (count / 100)}`  
  if (count >= 100) {
    clearInterval(loadPage)
    mainText.classList.add('show')
  }
}, 25)

/** section 2 games selection */
const panelsEl = document.querySelectorAll('.panel')

panelsEl.forEach(e => {
  e.addEventListener('mouseenter', () => {
    shirinkPanels()
    e.classList.add('expand')        
  })
});

function shirinkPanels() {
  panelsEl.forEach(e => {
    e.classList.remove('expand')
  });
}

/** common */
const arrowBoxes = document.querySelectorAll('.arrow-box')

window.addEventListener('scroll', () => {
  arrowBoxes.forEach(arrow => {
    if(arrow.getBoundingClientRect().top < 600) {
      arrow.classList.add('show-arrow')
    } else {
      arrow.classList.remove('show-arrow')
    }
  });  
})
