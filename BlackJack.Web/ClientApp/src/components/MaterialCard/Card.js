import React, { Component } from "react";

import { Royal } from "./Elements/Royal";
import { Panel } from "./Elements/Panel";
import { Suit } from "./Elements/Suit";
import { Back } from "./Elements/Back";

export class Card extends Component {
    static rank;
    static suit;
    static className;
    static color;

    render() {
        return this.getCard(this.props.cardName);
    }

    getCard(cardName) {
        this.setCardStats(cardName);
        this.getContent();

        if (cardName !== "Back") {
            return (
                <div className="card">
                    <div className="ripple" />
                    <Panel position="top" rank={this.rank} suit={this.suit} />
                    <div className={"content " + this.className}>{this.getContent()}</div>
                    <Panel position="bottom" rank={this.rank} suit={this.suit} />
                </div>
            );
        } else if (cardName === "Back") {
            return (
                <div className="card">
                    <div className="ripple" />
                    <div className="top back panel" style={{ backgroundColor: "#363636" }} />
                    <div className={"content " + this.className}>
                        <Back />
                    </div>
                    <div
                        className="bottom back panel"
                        style={{ backgroundColor: "#d64c4c" }}
                    />
                </div>
            );
        }
    }

    isRoyal() {
        return (
            this.rank === "Jack" || this.rank === "Queen" || this.rank === "King"
        );
    }

    generateRoyal() {
        return (
            <div className="frontFace">
                <Royal rank={this.rank} color={this.color} />
                <span className={this.color} />
                <Royal rank={this.rank} color={this.color} />
            </div>
        );
    }

    generatePips() {
        var pips = [];
        for (var i = 0; i < this.getRankNumber(); i++) {
            pips[i] = <Suit suit={this.suit} scaled="true" key={i} />;
        }

        return <div className="frontFace">{pips}</div>;
    }

    setCardStats(cardName) {
        let rankSuit = cardName.split("Of");
        this.rank = rankSuit[0];
        this.suit = rankSuit[1];
        this.className = rankSuit[0].toLowerCase();

        if (rankSuit[1] === "Diamonds" || rankSuit[1] === "Hearts") {
            this.color = "red";
        } else {
            this.color = "black";
        }
    }

    getContent() {
        if (this.isRoyal()) {
            return this.generateRoyal();
        } else {
            return this.generatePips();
        }
    }

    getRankNumber() {
        switch (this.rank) {
            case "Ace":
                return "1";
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
                return 0;
        }
    }
}
