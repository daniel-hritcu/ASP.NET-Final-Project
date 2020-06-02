import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { GameState } from './components/GameState';
import './custom.css'
import './game.scss'


export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={GameState} />
      </Layout>
    );
  }
}
