const fetchApi = fetch('http://127.0.0.1:5116/times', {
  method: 'GET',
  headers: {
    'Content-Type': 'application/json'
  }
}).then(res => res.json()).then(data => console.log(data));



