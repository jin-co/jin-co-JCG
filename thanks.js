const joke = document.querySelector('.joke')
const jokeAPI = 'https://icanhazdadjoke.com'

getJoke()

async function getJoke() {
  const res = await fetch(jokeAPI, {
    headers: {
      'Accept': 'application/json'
    }
  })
  const data = await res.json()
  console.log(data)
  console.log(joke)
  joke.textContent = data.joke
}