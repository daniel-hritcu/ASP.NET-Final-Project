import React, { Component } from "react";
import { Card } from "./MaterialCard/Card";

export class Hand extends Component {
    constructor(props) {
        super(props);
        this.state = {
            player: props.player,
            cards: props.cards
        };
    }

    static getDerivedStateFromProps(props, state) {
        if (props.cards !== state.cards) {
            return {
                cards: props.cards
            };
        }
    }

    render() {
        return (
            <div className="hand">
                {this.state.cards.map(function (card, id) {
                    return <Card cardName={card.name} key={id} />
                })}
            </div>
        );
    }

    setCards(newCards) {
        this.setState({
            cards: newCards
        });
    }
}
