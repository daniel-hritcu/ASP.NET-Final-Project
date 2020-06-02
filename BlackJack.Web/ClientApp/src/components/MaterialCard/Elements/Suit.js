import React, { Component } from "react";

export class Suit extends Component {
    render() {
        return this.getSuit(this.props.suit, this.props.scaled);
    }

    getSuit(suit, scaled) {
        //Spade
        if (suit === "Spades") {
            var width, height;
            //Icon dimensions
            if (scaled === "true") {
                width = "37px";
                height = "39px";
            }
            //Return Spade Svg
            return (
                <svg
                    version="1.1"
                    x="0px"
                    y="0px"
                    width={width}
                    height={height}
                    viewBox="0 0 18.6 19.5"
                    enableBackground="new 0 0 18.6 19.5"
                >
                    <g>
                        <path
                            fill="#363636"
                            d="M17.2,9.5L17.2,9.5L9.3,0l-8,9.5h0c-0.8,0.8-1.3,2-1.3,3.3c0,2.6,2.1,4.6,4.6,4.6
              c2.5,0,4.6-2.1,4.6-4.6h0 c0,2.5,2.1,4.6,4.6,4.6c2.6,0,4.6-2.1,4.6-4.6C18.6,11.4,18,
              10.3,17.2,9.5z"
                        />
                        <polygon fill="#363636" points="6.8,19.5 11.8,19.5 9.3,15.1" />
                    </g>
                </svg>
            );
            //Heart
        } else if (suit === "Hearts") {
            //Icon dimensions
            if (scaled === "true") {
                width = "36px";
                height = "34px";
            }
            //Return Heart Svg
            return (
                <svg
                    version="1.1"
                    x="0px"
                    y="0px"
                    width={width}
                    height={height}
                    viewBox="0 0 18.2 17"
                    enableBackground="new 0 0 18.2 17"
                >
                    <path
                        fill="#d64c4c"
                        d="M18.2,4.5c0-2.5-2-4.5-4.5-4.5c-2.5,0-4.5,2-4.5,4.5h0C9.1,2,7,0,4.5,0C2,0,0,2,0,4.5 
            c0,1.2,0.5,2.4,1.3,3.2h0L9.1,17l7.8-9.3h0C17.7,6.9,18.2,5.8,18.2,4.5z"
                    />
                </svg>
            );
            //Diamond
        } else if (suit === "Diamonds") {
            //Icon dimensions
            if (scaled === "true") {
                width = "37px";
                height = "44px";
            }
            //Return Diamond Svg
            return (
                <svg
                    version="1.1"
                    x="0px"
                    y="0px"
                    width={width}
                    height={height}
                    viewBox="0 0 18.2 21.7"
                    enableBackground="new 0 0 18.2 21.7"
                >
                    <polygon fill="#d64c4c" points="9.1,0 0,10.8 9.1,21.7 18.2,10.8" />
                </svg>
            );
            //Club
        } else if (suit === "Clubs") {
            //Icon dimensions
            if (scaled === "true") {
                width = "36px";
                height = "37px";
            }
            //Return Club Svg
            return (
                <svg
                    version="1.1"
                    x="0px"
                    y="0px"
                    width={width}
                    height={height}
                    viewBox="0 0 18.2 19.1"
                    enableBackground="new 0 0 18.2 19.1"
                >
                    <g>
                        <path
                            fill="#363636"
                            d="M13.6,7.7c-0.6,0-1.2,0.1-1.7,0.3c1.1-0.8,1.7-2.1,1.7-3.6c0-2.5-2-4.5-4.5-4.5S4.5,2,4.5,4.5 
              c0,1.4,0.7,2.7,1.7,3.6C5.7,7.9,5.2,7.7,4.5,7.7C2,7.7,0,9.8,0,12.3s2,4.5,4.5,4.5s4.5-2,4.5-4.5
              c0,0,0,0,0,0l0,0l0,0c0,0,0,0,0,0 c0,2.5,2,4.5,4.5,4.5c2.5,0,4.5-2,4.5-4.5S16.1,7.7,13.6,7.7z"
                        />
                        <polygon fill="#363636" points="6.6,19.1 11.6,19.1 9.1,14.7" />
                    </g>
                </svg>
            );
        }
    }
}
