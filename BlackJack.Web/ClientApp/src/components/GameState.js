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
                stateName: "",
                bet: 0,
                winnings: 0
            },
            loading: true,
            bet: 0,
            clearCards: false,

        };
        this.hit = this.hit.bind(this);
        this.stand = this.stand.bind(this);
        this.bet = this.bet.bind(this);
        this.betUp = this.betUp.bind(this);
        this.betDown = this.betDown.bind(this);
        this.newGame = this.newGame.bind(this);
    }

    newGame() {
        this.getGameState("NewGame");
    }

    hit() {
        this.getGameState("Hit");
    }

    stand() {
        this.getGameState("Stand");
    }

    bet() {
        if (this.state.bet > this.state.gameState.defaultPlayer.balance) {
            this.setBet(this.state.gameState.defaultPlayer.balance);
        }
        this.setClearCards(true);
        this.getGameState("Bet", this.state.bet);
    }

    betUp() {
        if (this.state.bet > this.state.gameState.defaultPlayer.balance) {
            this.setBet(this.state.gameState.defaultPlayer.balance);
        }
        if (this.state.bet < 100) {
            var totalBet = this.state.bet;
            this.setBet(totalBet + 5);
        }
    }

    betDown() {
        if (this.state.bet > this.state.gameState.defaultPlayer.balance) {
            this.setBet(this.state.gameState.defaultPlayer.balance);
        }
        if (this.state.bet > 0) {
            var totalBet = this.state.bet;
            this.setBet(totalBet - 5);
        }
    }

    setBet(bet) {
            var theState = this.state;
            theState.bet = bet;
            this.setState(theState);  
    }

    setClearCards(clear) {
        var theState = this.state;
        theState.clearCards = clear;
        this.setState(theState); 
    }

    componentDidMount() {
        this.getGameState("NewGame");
    }

    render() {
        if (this.state.loading) {
            return <p><em>Loading...</em></p>;
        }

        if (this.state.clearCards) {
            this.setClearCards(false);
            return (
                <div id="gameContainer">
                    <div className="handContainer">
                    </div>
                    <hr />
                    <div id="Controls">
                        <div className="tip left"><h1>{"Balance: " + this.state.gameState.defaultPlayer.balance}</h1></div>
                        {this.getGameControls()}
                    </div>
                    <hr />
                    <div className="handContainer">
                    </div>
                </div>
            );
        }

        if (this.state.gameState.stateName === "NewGame") {
            return (
                <div id="gameContainer">
                    <div className="handContainer">
                        <div className="title">
                            <h1>Black Jack<span>ASP.Net Core React</span></h1>
                        </div>
                    </div>
                    <hr />
                    <div id="Controls">
                        <div className="tip left"><h1>{"Balance: " + this.state.gameState.defaultPlayer.balance}</h1></div>
                        {this.getGameControls()}
                    </div>
                    <hr />
                    <div className="handContainer"></div>
                </div>
            );
        }

        if (this.state.gameState.defaultPlayer.balance < 5 && this.state.gameState.stateName !== "Open") {
            return (
                <div id="gameContainer">
                    <div className="handContainer">
                        <div className="title">
                            <h1>Black Jack<span>ASP.Net Core React</span></h1>
                        </div>
                    </div>
                    <hr />
                    <div id="Controls">
                        <button className="btn" onClick={this.newGame}>New Game!</button>
                    </div>
                    <hr />
                    <div className="handContainer">
                        <div className="title">
                            <h1>Out of funds<span>Better luck next time!</span></h1>
                        </div>
                    </div>
                </div>
            );
        }

        return (
            <div id="gameContainer">
                <div className="handContainer">
                    <Hand cards={this.state.gameState.dealer.hand} ref={this._dealerHand} />

                    {this.state.gameState.dealer.hand[1].name !== "Back" ? (
                        <div className="tip right"><h1>{"Dealer Score: " + this.state.gameState.dealer.score}</h1></div>
                    ) : (
                            ""
                        )}
                </div>
                <hr />
                <div id="Controls">
                    <div className="tip left"><h1>{"Balance: " + this.state.gameState.defaultPlayer.balance}</h1></div>
                    {this.getGameControls()}
                </div>
                <hr />
                <div className="handContainer">
                    <Hand cards={this.state.gameState.defaultPlayer.hand} ref={this._playerHand} />
                    {this.state.gameState.stateName !== "NewGame" ? (
                        <div className="tip right"><h1>{"Player Score: " + this.state.gameState.defaultPlayer.score}</h1></div>
                    ) : (
                            ""
                        )}
                </div>
            </div>
        );
    }


    getGameControls() {
        if (this.state.gameState.stateName === "Open") {
            return (
                <span>
                    <button className="btn" onClick={this.hit}>Hit</button>
                    <button className="btn" onClick={this.stand}>Stand</button>
                </span>
            );
        } else if (this.state.gameState.stateName !== "NewGame") {
            return (
                <span>
                    <button className="btn" {this.state.bet == 0 ? ( disabled ) : ("")} onClick={this.betDown}>-5$</button>
                    <button className="btn" onClick={this.bet}>Bet <strong>{this.state.bet + "$"}</strong></button>
                    <button className="btn" onClick={this.betUp}>+5$</button>
                    <div className="tip right red"><h1><span>Conclusion: </span>{this.state.gameState.stateName}</h1></div>
                </span>
            );
        } else if (this.state.gameState.stateName === "NewGame") {
            return (
                <span>
                    <button className="btn" onClick={this.betDown}>-5$</button>
                    <button className="btn" onClick={this.bet}>Bet <strong>{this.state.bet + "$"}</strong></button>
                    <button className="btn" onClick={this.betUp}>+5$</button>
                </span>
            );

        }
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

