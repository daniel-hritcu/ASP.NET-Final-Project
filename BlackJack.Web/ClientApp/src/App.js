import React, { Component } from 'react';
import { GameState } from './components/GameState';
import './custom.css'
import './game.scss'


export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <GameState />
    );
  }
}
