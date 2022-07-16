import 'bootstrap/dist/css/bootstrap.min.css';
import React, { Component } from 'react'
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import Slider from "react-slick";
import './SLide.css';


export class SliderBox extends Component {
    render() {
        var settings = {
            dots: true,
            infinite: true,
            speed: 500,
            centerMode: true,
            slidesToShow: 1,
            slidesToScroll: 1
        };
        return (
            <div className='sliderbox'>

                <Slider>
                    <div className="wdt">
                        <img className="img"
                            src={'https://cdn.w600.comps.canstockphoto.com/special-offer-word-in-splashs-drawing_csp68216547.jpg'} />
                    </div>

                    <div className="wdt">
                        <img className="img"
                            src={'https://st2.depositphotos.com/1010735/12327/v/950/depositphotos_123270476-stock-illustration-special-offer-colour-backgrounds.jpg'} />
                    </div>
                </Slider>
            </div>
        );
    }
}

export default SliderBox  