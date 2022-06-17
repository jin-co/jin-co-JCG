const mainImage = document.querySelector('.main-img')
const countEl = document.querySelector('.count')
let count = 0

const loadPage = setInterval(() => {
  count++
  mainImage.style.filter = `blur(${100 - count}px)`
  countEl.textContent = `${count}%`
  countEl.style.opacity = `${1 - (count / 100)}`  
  if (count >= 100) {
    clearInterval(loadPage)
  }
}, 50)
