import './App.css';
import Header from './Header';
import React, { useEffect, useState } from 'react';
import Game from './components/gameComponent/Game';

function App() {
  const [games, setGames] = useState([]);

  useEffect(function () {
    const url = 'https://localhost:7103/api/game/GetGames'
    fetch(url)
      .then(response => response.json())
      .then(data => setGames(data));
  }, [])
  return (
    <div>
      <Header></Header>
      <div>
        Games:
      </div>
      {
        games.map(game => {
          return (<Game model={game}></Game>)
        })
      }
    </div>
  );
}

export default App;
