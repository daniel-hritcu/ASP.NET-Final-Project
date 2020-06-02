import React, { Component } from "react";
import { Suit } from "./Suit";

export class Panel extends Component {
    render() {
        return this.getPanel(this.props.position, this.props.rank, this.props.suit);
    }

    getPanel(position, rank, suit) {
        var color;

        if (suit === "Diamonds" || suit === "Hearts") {
            color = this.getColor("red");
        } else {
            color = this.getColor("black");
        }

        return (
            <div className={position + " panel"} style={{ backgroundColor: color }}>
                <div className="rank">{this.getDisplayRank(rank)}</div>
                <div className="suit">{rank + " of " + suit}</div>
                <div className="icon">
                    <Suit suit={suit} scaled="false" />
                </div>
            </div>
        );
    }

    getColor(color) {
        if (color === "black") {
            return "#363636";
        } else if (color === "red") {
            return "#d64c4c";
        }
    }

    getDisplayRank(rank) {
        switch (rank) {
            case "Two":
                return "2";
            case "Three":
                return "3";
            case "Four":
                return "4";
            case "Five":
                return "5";
            case "Six":
                return "6";
            case "Seven":
                return "7";
            case "Eight":
                return "8";
            case "Nine":
                return "9";
            case "Ten":
                return "10";

            default:
                return rank.charAt(0);
        }
    }
}
