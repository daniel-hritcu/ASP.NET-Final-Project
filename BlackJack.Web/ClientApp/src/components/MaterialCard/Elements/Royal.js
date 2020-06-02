import React, { Component } from "react";

export class Royal extends Component {
    render() {
        return this.getRoyal(this.props.rank, this.props.suit);
    }

    getRoyal(rank, color) {
        if (rank === "Jack") {
            return this.getJack(color);
        } else if (rank === "Queen") {
            return this.getQueen(color);
        } else if (rank === "King") {
            return this.getKing(color);
        }
    }

    getJack(color) {
        var colorOne, colorTwo;

        if (color === "red") {
            colorOne = "#d74b4c";
            colorTwo = "#c84145";
        } else if (color === "black") {
            colorOne = "#0c79bc";
            colorTwo = "#025490";
        }

        return (
            <svg
                version="1.1"
                x="0px"
                y="0px"
                width="96px"
                height="48px"
                viewBox="0 0 56.5 27.7"
                enableBackground="new 0 0 56.5 27.7"
            >
                <g>
                    <rect
                        id="XMLID_5_"
                        x="34.7"
                        y="9.7"
                        fill="#E55125"
                        width="9.1"
                        height="4"
                    />
                    <rect
                        id="XMLID_4_"
                        x="12.9"
                        y="9.7"
                        fill="#F57E20"
                        width="9.1"
                        height="4"
                    />
                    <polygon
                        id="XMLID_3_"
                        fill="#FEBB18"
                        points="28.2,27.7 28.2,0 21.3,2 21.3,13.4 15,13.2 12.9,5.7 0,5.7 5.6,27.7"
                    />
                    <polygon
                        id="XMLID_2_"
                        fill="#F49221"
                        points="28.2,27.7 28.2,0 35.2,2 35.2,13.4 41.4,13.2 43.5,5.7 56.5,5.7 50.8,27.7"
                    />
                    <polygon
                        fill={colorOne}
                        points="3.1,17.9 4.5,23.4 28.2,23.4 28.2,17.9"
                    />
                    <polygon
                        fill={colorTwo}
                        points="53.3,17.9 51.9,23.4 28.2,23.4 28.2,17.9"
                    />
                </g>
            </svg>
        );
    }

    getQueen(suit) {
        var colorOne,
            colorTwo,
            colorThree,
            colorFour,
            colorFive,
            colorSix,
            colorSeven,
            colorEight;

        if (suit === "Diamond" || suit === "Heart") {
            colorOne = "#F59090";
            colorTwo = "#F37B7B";
            colorThree = "#EB5451";
            colorFour = "#e43532";
            colorFive = "#F15753";
            colorSix = "#E14E4B";
            colorSeven = "#A81F23";
            colorEight = "#B62026";
        } else {
            colorOne = "#7DA3D5";
            colorTwo = "#6795CE";
            colorThree = "#3480C3";
            colorFour = "#0075BC";
            colorFive = "#3C82C4";
            colorSix = "#0A79BF";
            colorSeven = "#005490";
            colorEight = "#005A9A";
        }

        return (
            <svg
                version="1.1"
                x="0px"
                y="0px"
                width="96px"
                height="48px"
                viewBox="0 0 61.1 37.2"
                enableBackground="new 0 0 61.1 37.2"
            >
                <polygon
                    id="XMLID_16_"
                    fill="#E55125"
                    points="46.8,23 42.5,17 61.1,3.7"
                />
                <polygon id="XMLID_15_" fill="#F57E20" points="14.4,23 0,3.7 18.6,17" />
                <polygon
                    id="XMLID_14_"
                    fill="#FEBB18"
                    points="8.8,37.2 0,3.7 14.4,23 30.6,0 30.6,37.2"
                />
                <polygon
                    id="XMLID_13_"
                    fill="#F49221"
                    points="52.3,37.2 61.1,3.7 46.8,23 30.6,0 30.6,37.2"
                />
                <g>
                    <polygon
                        id="XMLID_12_"
                        fill={colorFive}
                        points="30.6,23 23.9,23 27.2,27.9"
                    />
                    <polygon
                        id="XMLID_11_"
                        fill={colorTwo}
                        points="23.9,23 30.6,23 27.2,18.1"
                    />
                    <polygon
                        id="XMLID_10_"
                        fill={colorOne}
                        points="27.2,18.1 30.6,23 30.6,18.1 30.6,13.1"
                    />
                    <polygon
                        id="XMLID_9_"
                        fill={colorThree}
                        points="30.6,13.1 30.6,18.1 30.6,23 33.9,18.1"
                    />
                    <polygon
                        id="XMLID_8_"
                        fill={colorEight}
                        points="37.3,23 30.6,23 33.9,27.9"
                    />
                    <polygon
                        id="XMLID_7_"
                        fill={colorFour}
                        points="30.6,23 37.3,23 33.9,18.1"
                    />
                    <polygon
                        id="XMLID_6_"
                        fill={colorSix}
                        points="27.2,27.9 30.6,32.9 30.6,27.9 30.6,23"
                    />
                    <polygon
                        id="XMLID_5_"
                        fill={colorSeven}
                        points="30.6,23 30.6,27.9 30.6,32.9 33.9,27.9"
                    />
                    <polygon
                        id="XMLID_3_"
                        fill="#E38825"
                        points="37.3,23 30.6,32.9 30.6,37.2 46.3,37.2"
                    />
                    <path
                        id="XMLID_2_"
                        fill="#FFFFFF"
                        d="M30.6,19.8c-1.8,0-3.3-1.5-3.3-3.3c0,1.8-1.5,3.3-3.3,3.3
            c1.8,0,3.3,1.5,3.3,3.3 C27.3,21.2,28.8,19.8,30.6,19.8z"
                    />
                </g>
            </svg>
        );
    }

    getKing(suit) {
        var colorOne,
            colorTwo,
            colorThree,
            colorFour,
            colorFive,
            colorSix,
            colorSeven,
            colorEight;

        if (suit === "Diamond" || suit === "Heart") {
            colorOne = "#F59090";
            colorTwo = "#F37B7B";
            colorThree = "#EB5451";
            colorFour = "#e43532";
            colorFive = "#F15753";
            colorSix = "#E14E4B";
            colorSeven = "#A81F23";
            colorEight = "#B62026";
        } else {
            colorOne = "#7DA3D5";
            colorTwo = "#6795CE";
            colorThree = "#3480C3";
            colorFour = "#0075BC";
            colorFive = "#3C82C4";
            colorSix = "#0A79BF";
            colorSeven = "#005490";
            colorEight = "#005A9A";
        }
        return (
            <svg
                version="1.1"
                x="0px"
                y="0px"
                width="96px"
                height="48px"
                viewBox="0 0 59.4 35.5"
                enableBackground="new 0 0 59.4 35.5"
            >
                <rect
                    id="XMLID_16_"
                    x="36.2"
                    y="10.9"
                    fill="#E55125"
                    width="9.1"
                    height="4"
                />
                <rect
                    id="XMLID_15_"
                    x="14.4"
                    y="10.9"
                    fill="#F57E20"
                    width="9.1"
                    height="4"
                />
                <polygon
                    id="XMLID_14_"
                    fill="#F49221"
                    points="51.5,35.5 59.4,4.8 46.7,6.8 43.6,14.4 36.7,14.6 36.7,2 29.7,0 29.7,35.5"
                />
                <polygon
                    id="XMLID_13_"
                    fill="#E38825"
                    points="36.4,22.4 29.7,32.3 29.7,35.5 45.3,35.5"
                />
                <polygon
                    id="XMLID_12_"
                    fill="#FEBB18"
                    points="8,35.5 0,4.8 12.8,6.8 15.8,14.4 22.8,14.6 22.8,2 29.7,0 29.7,35.5"
                />
                <g>
                    <polygon
                        id="XMLID_11_"
                        fill={colorFive}
                        points="29.8,22.4 23.1,22.4 26.4,27.4"
                    />
                    <polygon
                        id="XMLID_10_"
                        fill={colorTwo}
                        points="23.1,22.4 29.8,22.4 26.4,17.5"
                    />
                    <polygon
                        id="XMLID_9_"
                        fill={colorOne}
                        points="26.4,17.5 29.8,22.4 29.8,17.5 29.8,12.6"
                    />
                    <polygon
                        id="XMLID_8_"
                        fill={colorThree}
                        points="29.8,12.6 29.8,17.5 29.8,22.4 33.1,17.5"
                    />
                    <polygon
                        id="XMLID_7_"
                        fill={colorEight}
                        points="36.5,22.4 29.8,22.4 33.1,27.4"
                    />
                    <polygon
                        id="XMLID_6_"
                        fill={colorFour}
                        points="29.8,22.4 36.5,22.4 33.1,17.5"
                    />
                    <polygon
                        id="XMLID_5_"
                        fill={colorSix}
                        points="26.4,27.4 29.8,32.3 29.8,27.4 29.8,22.4"
                    />
                    <polygon
                        id="XMLID_4_"
                        fill={colorSeven}
                        points="29.8,22.4 29.8,27.4 29.8,32.3 33.1,27.4"
                    />
                    <path
                        id="XMLID_2_"
                        fill="#FFFFFF"
                        d="M29.8,19.2c-1.8,0-3.3-1.5-3.3-3.3c0,1.8-1.5,3.3-3.3,3.3c1.8,0,3.3,1.5,3.3,3.3 
            C26.5,20.7,28,19.2,29.8,19.2z"
                    />
                </g>
            </svg>
        );
    }
}
