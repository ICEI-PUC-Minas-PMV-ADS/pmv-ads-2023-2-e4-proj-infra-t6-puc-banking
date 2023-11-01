import React from "react";
import { AiOutlineUser, AiOutlineStar } from "react-icons/ai";
import { FiSend } from "react-icons/fi";
import '../Styles/RegisterSteps.css'


const RegisterSteps = ({ currentStep }) => {
    return (
        <div className='steps'>
            <div className='step active'>
                <AiOutlineUser />
                <p>Indentificação</p>
            </div>
            <div className={`step ${currentStep >= 1 ? "active" : ""}`}>
                <AiOutlineStar />
                <p>Cartão</p>
            </div>
            <div className={`step ${currentStep >= 2 ? "active" : ""}`}>
                <FiSend />
                <p>Envio</p>
            </div>
        </div>
    );
};
export default RegisterSteps;