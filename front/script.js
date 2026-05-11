const listaTimes = document.getElementById('times-lista');
const apiUrl = 'http://127.0.0.1:5116/times';

const GET = async () => {
  try {
    const res = await fetch(apiUrl, {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json'
      }
    });

    if (!res.ok) throw new Error('Erro ao buscar os times!');

    const times = await res.json();

    times.forEach(time => {
      const li = document.createElement('li');
      li.innerText = `Nome: ${time.nome}`;
      listaTimes.appendChild(li);
    });

  } catch (error) {
    listaTimes.innerText = `${error.message}`;
  }
}

GET();




