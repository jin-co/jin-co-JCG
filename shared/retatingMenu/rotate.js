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