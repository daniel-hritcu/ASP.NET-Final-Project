import React, { Component } from "react";

export class Back extends Component {
    render() {
        return this.getBack();
    }

    getBack() {
        return (
            <div className="backFace">
                <svg
                    version="1.1"
                    id="BackSvg"
                    x="0px"
                    y="0px"
                    width="100%"
                    height="100%"
                    viewBox="0 0 72 72"
                >
                    <circle className="st0" cx="36" cy="36" r="36" />
                    <line className="st1" x1="13.5" y1="13.5" x2="58.5" y2="58.5" />
                    <line className="st1" x1="13.5" y1="58.5" x2="58.5" y2="13.5" />
                    <g>
                        <path
                            className="st2"
                            d="M40.4,55c-0.6,0-1.2,0.1-1.6,0.3c1.1-0.8,1.6-2,1.6-3.5c0-2.4-1.9-4.3-4.3-4.3c-2.4,0-4.4,2-4.4,4.4
		c0,1.4,0.7,2.6,1.6,3.5c-0.5-0.2-1-0.4-1.6-0.4c-2.4,0-4.3,2-4.3,4.4s1.9,4.3,4.3,4.3s4.3-1.9,4.3-4.3l0,0l0,0l0,0l0,0
		c0,2.4,1.9,4.3,4.3,4.3c2.4,0,4.3-1.9,4.3-4.3C44.7,57,42.9,55,40.4,55z"
                        />
                        <polygon className="st2" points="33.7,66 38.5,66 36.1,61.7 	" />
                    </g>
                    <g>
                        <polygon
                            className="st3"
                            points="56.7,26.3 48.5,36 56.7,45.8 64.9,36 	"
                        />
                    </g>
                    <g>
                        <path
                            className="st3"
                            d="M24.6,31.9c0-2.6-2-4.6-4.6-4.6s-4.6,2-4.6,4.6l0,0c-0.1-2.6-2.3-4.6-4.8-4.6S6,29.4,6,31.9
		c0,1.2,0.5,2.5,1.3,3.3l0,0l8,9.5l8-9.5l0,0C24.1,34.4,24.6,33.3,24.6,31.9z"
                        />
                    </g>
                    <g>
                        <path
                            className="st2"
                            d="M43.6,15.1L43.6,15.1l-7.5-9l-7.6,9l0,0c-0.8,0.8-1.2,1.9-1.2,3.1c0,2.5,2,4.4,4.4,4.4s4.4-2,4.4-4.4l0,0
		c0,2.4,2,4.4,4.4,4.4c2.5,0,4.4-2,4.4-4.4C44.9,16.9,44.3,15.8,43.6,15.1z"
                        />
                        <polygon className="st2" points="33.7,24.6 38.4,24.6 36.1,20.4 	" />
                    </g>
                    <circle className="st4" cx="36" cy="36" r="20.7" />
                </svg>
            </div>
        );
    }
}
