import React, { Component } from 'react';
import { Hand } from './Hand'
export class GameState extends Component {

    constructor(props) {
        super(props);
        this._playerHand = React.createRef();
        this._dealerHand = React.createRef();
        this.state =
        {
            //Expected gameState model
            gameState:
            {
                defaultPlayer: {
                    hand: [{ "name": "Blank", "rank": 0, "suit": 0 }],
                    balance: 0,
                    score: 0
                },
                dealer: {
                    hand: [{ "name": "Blank", "rank": 0, "suit": 0 }],
                    balance: 0,
                    score: 0
                },
                currentState: 0,
                bet: 0,
                winnings: 0
            },
            loading: true,
            bet: 0,
            currentCount: 0
        };
        this.hit = this.hit.bind(this);
        this.stand = this.stand.bind(this);
    }

    hit() {
        this.getGameState("Hit");
    }

    stand() {
        alert('stan');
        this.getGameState("Hit");
    }

    componentDidMount() {
        this.getGameState("NewGame");
    }

    render() {
        if (this.state.loading) {
            return <p><em>Loading...</em></p>;
        }
        return (
            <div id="gameContainer">
                <div id="dealerHand">
                    <Hand cards={this.state.gameState.dealer.hand} ref={this._dealerHand} />
                </div>
                <hr />
                <button className="btn" onClick={this.hit}>Hit</button>
                <button className="btn" onClick={this.stand}>Stand</button>
                <hr />
                <div id="playerHand">
                    <Hand cards={this.state.gameState.defaultPlayer.hand} ref={this._playerHand} />
                </div>
            </div>
        );
    }

    async getGameState(action, bet = "") {
        var response = null;

        switch (action) {
            case "Bet":
                response = await fetch('game?action=Deal&bet=' + this.state.bet);
                break;
            case "Hit":
                response = await fetch('game?action=Hit');
                break;
            case "Stand":
                response = await fetch('game?action=Stand');
                break;
            case "NewGame":
            default:
                response = await fetch('game?action=NewGame');
                break;
        }
        var data = await response.json();
        this.setState({ gameState: data, loading: false });
    }
}

