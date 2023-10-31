import React from "react";
import { AiOutLineUser, AioutLineStar } from "react-icons/ai";
import { FiSend } from "react-icons/fi";
import '../RegisterSteps.css'


const RegisterSteps = ({currentStep}) => {
    return (
        <div className='steps'>Steps
            <div className='step'>
                <p>Indentificação</p>
            </div>
            <div className='steps'>Steps
            <div className='step'>
                <p>Cartão</p>
            </div>
        </div>
        <div className='steps'>Steps
            <div className='step'>
                <p>Envio</p>
            </div>
        </div>
        </div>
        
        
    )
};
export default RegisterSteps;