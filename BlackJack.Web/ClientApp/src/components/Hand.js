import React, { Component } from "react";
import { Card } from "./MaterialCard/Card";

export class Hand extends Component {
    constructor(props) {
        super(props);
        this.state = {
            cards: props.cards
        };
    }

    render() {
        return (
            <div>
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
